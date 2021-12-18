using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TastyChef.DAL;

namespace TastyChef
{
    public partial class AdminInsertRecipeStep5 : System.Web.UI.Page
    {
        Recipe r = new Recipe();
        protected void Page_Load(object sender, EventArgs e)
        {
            r = (Recipe)Session["Step1"];
            string recipeName = r.RecipeName.ToString();
            LblRecipeName.Text = recipeName;


            LblErrorMessage1.Visible = false;
            BtnStep1Next.Focus();
            if (!IsPostBack)
            {
                LblErrorMessage1.Visible = false; 
                PopulateAllergens();
            }
        }
      

        protected void BtnStep1Next_Click(object sender, EventArgs e)
        {
            r = (Recipe)Session["Step1"];
            string recipeName = r.RecipeName.ToString();
            List<FoodAllergens> faList = new List<FoodAllergens>();
            List<TailoredMadeRecipes>tmrList = new List<TailoredMadeRecipes>();
            if (DDLRecipeSchedule.SelectedItem.Text != "Please Select")
            {
                Session["RecipeDay"] = DDLRecipeSchedule.SelectedItem.Text;
                foreach(ListItem items in CBLAllergens.Items)
                {
                    if (items.Selected) {
                       
                        string foodAllergy = items.Value;
                        FoodAllergens fa = new FoodAllergens(foodAllergy,recipeName);
                        faList.Add(fa);
                    }

                }
                Session["FoodAllergens"] = faList;
                foreach(ListItem items in CBLMedicalCondition.Items)
                {
                    if (items.Selected)
                    {
                        string medicalCondition = items.Value;
                        TailoredMadeRecipes tmr = new TailoredMadeRecipes(medicalCondition);
                        tmrList.Add(tmr);
                    }
                }
                Session["MedicalCondition"] = tmrList;

                Response.Redirect("AdminInsertRecipeConfirmation.aspx");
            }
            else
            {
                LblErrorMessage1.Visible = true;
                BtnStep1Next.Focus();
            }
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminInsertRecipeStep4.aspx");
        }
        private void PopulateAllergens()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["TastyChefContext"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Select * From FoodAllergies ";
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            ListItem item = new ListItem();
                            item.Text = sdr["FoodAllergyName"].ToString();
                            
                            CBLAllergens.Items.Add(item);
                        }
                    }
                    conn.Close();
                }
            }
        }
    }
}