using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TastyChef.DAL;

namespace TastyChef
{
    public partial class AdminRecipeDetials : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                bind();
            }
        }
        private void bind()
        {
            string recipeName = Request.QueryString["RecipeName"].ToString();
            Recipe rMethod = new Recipe();
            Recipe r = new Recipe();
            r = rMethod.GetRecipeDetailsByRecipeName(recipeName);
            
            string day = r.Day.ToString();
            if (day=="Monday")
            {
                DDLSchedule.SelectedValue = "1";
            }
            else if (day == "Tuesday")
            {
                DDLSchedule.SelectedValue = "2";
            }
            else if (day == "Wednesday")
            {
                DDLSchedule.SelectedValue = "3";
            }
            else if (day == "Thursday")
            {
                DDLSchedule.SelectedValue = "4";
            }
            else if (day == "Friday")
            {
                DDLSchedule.SelectedValue = "5";
            }
            else if (day == "Saturday")
            {
                DDLSchedule.SelectedValue = "6";
            }
            else if (day == "Sunday")
            {
                DDLSchedule.SelectedValue = "7";
            }
            LblRecipeName.Text = r.RecipeName;
            LblRecipeType.Text = r.Type;
            LblCookingType.Text = r.CookingType;
            LblDuration.Text = Convert.ToString(r.CookingTime);
            LblServes.Text = Convert.ToString(r.Portion);
            LblFounder.Text = Convert.ToString(r.RecipeFounder);
            ImgRecipe.ImageUrl = r.Image;
            LblCarbohydrates.Text = Convert.ToString(r.TotalCarbohydrates);
            LblCholesterol.Text = Convert.ToString(r.TotalCholesterol);
            LblDietaryFiber.Text = Convert.ToString(r.TotalDietaryFiber);
            LblProteins.Text = Convert.ToString(r.TotalProteins);
            LblSaturatedFat.Text = Convert.ToString(r.TotalProteins);
            LblTransFat.Text = Convert.ToString(r.TotalTransFat);
            LblTotalFat.Text = Convert.ToString(r.TotalFat);
            LblTotalCalories.Text = Convert.ToString(r.TotalCalories);
            LblSodium.Text = Convert.ToString(r.TotalSodium);
            LblSugar.Text = Convert.ToString(r.TotalSugar);

            ListOfIngredients loiMethod = new ListOfIngredients();
            List<ListOfIngredients> loiList = new List<ListOfIngredients>();
            loiList = loiMethod.RetrieveListOfIngredientsByRecipeName(recipeName);
            GVSelectedIngredient.DataSource = loiList;
            GVSelectedIngredient.DataBind();

            CookingInstruction ciMethod = new CookingInstruction();
            List<CookingInstruction> ciList = new List<CookingInstruction>();
            ciList = ciMethod.RetrieveCookingInstructionByRecipeName(recipeName);
            GVCookingInstruction.DataSource = ciList;
            GVCookingInstruction.DataBind();

            Cookware cMethod = new Cookware();
            List<Cookware> cList= new List<Cookware>();
            cList = cMethod.RetrieveCookWareByRecipeName(recipeName);
            GVCookingEquipmentSelection.DataSource = cList;
            GVCookingEquipmentSelection.DataBind();

            TailoredMadeRecipes tmr = new TailoredMadeRecipes();
            List<TailoredMadeRecipes> tmrList = new List<TailoredMadeRecipes>();
            tmrList = tmr.RetrieveMedicalConditionByRecipeName(recipeName);
         
            GVMedicalCondition.DataSource = tmrList;
            GVMedicalCondition.DataBind();
            int num1 = 0;
            if (tmrList.Count > 0)
            {
                for (int b = 0; b < tmrList.Count; b++)
                {
                    num1++;
                    if (num1 != tmrList.Count)
                    {
                        LblMedicalCondition.Text += tmrList[b].TagsMedicalCondition + ", ";
                    }
                    else
                    {
                        LblMedicalCondition.Text += tmrList[b].TagsMedicalCondition;
                    }

                }

            }
            else
            {
                LblMedicalCondition.Text = "None";
            }



            FoodAllergens fa = new FoodAllergens();
            List<FoodAllergens> faList = new List<FoodAllergens>();
            faList = fa.RetrieveFoodAllergensByRecipeName(recipeName);
            GVAllergens.DataSource = faList;
            GVAllergens.DataBind();
            int num = 0;
            if (faList.Count > 0)
            {
                for (int b = 0; b < faList.Count; b++)
                {
                    num++;
                    if (num != faList.Count)
                    {
                        LblAllergen.Text += faList[b].FoodAllergyName + ", ";
                    }
                    else
                    {
                        LblAllergen.Text += faList[b].FoodAllergyName;
                    }

                }

            }
            else
            {
                LblAllergen.Text = "None";
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminRecipeManage.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string recipeName = Request.QueryString["RecipeName"].ToString();
            Response.Redirect("AdminUpdateRecipeStep1.aspx?RecipeName=" + recipeName);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string recipeName = Request.QueryString["RecipeName"].ToString();
            Response.Redirect("AdminUpdateRecipeStep2.aspx?RecipeName=" + recipeName);
        }

        protected void BtnStep5_Click(object sender, EventArgs e)
        {
            Button1.Focus();
        }

        protected void BtnConfirmation_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminRecipeManage.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string recipeName = Request.QueryString["RecipeName"].ToString();
           string aDay= DDLSchedule.SelectedItem.Text;
            Recipe rMethod = new Recipe();
            int result = 0;
            result = rMethod.UpdateRecipeAvailableDay(recipeName, aDay);
            if (result > 0)
            {
           
               
                LblSchedule.Text = "*Update Successfully!";
                LblSchedule.ForeColor = System.Drawing.Color.DarkBlue;
                Button1.Focus();
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("AdminRecipeManage.aspx");
        }
    }
}