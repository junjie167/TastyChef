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
    public partial class AdminNutritionGroupInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateFoodAllergyType();
            }
        }

        protected void CBMCNone_CheckedChanged(object sender, EventArgs e)
        {
            if (CBMCNone.Checked == true)
            {
                CBMCDiabetes.Enabled = false;
            }
            else
            {
                CBMCDiabetes.Enabled = true;
            }

        }

        protected void CBMCDiabetes_CheckedChanged(object sender, EventArgs e)
        {
            if (CBMCDiabetes.Checked == true)
            {
                CBMCNone.Enabled = false;
            }
            else
            {
                CBMCNone.Enabled = true;
            }
        }

        protected void CBDTNone_CheckedChanged(object sender, EventArgs e)
        {
            if (CBDTNone.Checked == true)
            {
                CBDTAsian.Enabled = false;
            }
            else
            {
                CBDTAsian.Enabled = true;
            }
        }

        protected void CBDTAsian_CheckedChanged(object sender, EventArgs e)
        {
            if (CBDTAsian.Checked == true)
            {
                CBDTNone.Enabled = false;
            }
            else
            {
                CBDTNone.Enabled = true;
            }
        }
        //Populate all the food allergy type into Check Box List
        private void PopulateFoodAllergyType()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["TastyChefContext"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Select * from FoodAllergies";
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            ListItem item = new ListItem();
                            item.Text = sdr["FoodAllergyName"].ToString();
                            item.Value = sdr["FoodAllergyName"].ToString();
                            //  item.Selected = Convert.ToBoolean(sdr["IsSelected"]);
                            CBLFoodAllergy.Items.Add(item);
                        }
                    }
                    conn.Close();
                }
            }
        }

        protected void CBFANone_CheckedChanged(object sender, EventArgs e)
        {
            if (CBFANone.Checked == true)
            {
                CBLFoodAllergy.Enabled = false;
              
            }
            else
            {
                CBLFoodAllergy.Enabled = true;
            }
        }

        protected void BtnSubmits_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            if (DDLGroupName.SelectedItem.Text != "Please Select")
            {
                string medicalCondition;
                string dietType;
                NutritionGroup ng = new NutritionGroup();
                string groupName = DDLGroupName.SelectedItem.Text;
               

                if (CBMCNone.Checked == true && CBDTNone.Checked == true)
                {
                    medicalCondition = "None";
                    dietType = "None";

                    //Check NutritionGroup Condition
                    Boolean result = false;
                    result = ng.checkNutritionGroupCondition(groupName, medicalCondition,dietType);

                    if (result == false)
                    {

                        int result1 = 0;
                        result1 = ng.InsertNutritionGroup(groupName, medicalCondition,dietType);

                        foreach (ListItem items in CBLFoodAllergy.Items)
                        {
                            if (items.Selected)
                            {
                                string FoodAllergyName = items.Value;
                                int nutritionGroupID = ng.RetriveLatestNutritionGroupID();

                                ng.InsertNutritionGroup_FoodAllergies(nutritionGroupID, FoodAllergyName);
                               // Response.Redirect("AdminNutritionGroupInsert.aspx");
                            }

                        }
                    }
                    //Same NutritionGroup condition
                    else if (result == true)
                    {
                        Response.Write("<script>alert('NutritionGroup Condition Exists');</script>");
                       // Response.Redirect("AdminNutritionGroupInsert.aspx");
                        //Check NutritionGroup_Allergies condition
                        //Boolean result2 = false; 

                    }

                }






                else if (CBMCDiabetes.Checked == true && CBDTNone.Checked == true)
                {
                    medicalCondition = "Diabetes";
                    dietType = "None";
                    //Check NutritionGroup Condition
                    Boolean result = false;
                    result = ng.checkNutritionGroupCondition(groupName, medicalCondition,dietType);

                    if (result == false)
                    {

                        int result1 = 0;
                        result1 = ng.InsertNutritionGroup(groupName, medicalCondition, dietType);

                        foreach (ListItem items in CBLFoodAllergy.Items)
                        {
                            if (items.Selected)
                            {
                                string FoodAllergyName = items.Value;
                                int nutritionGroupID = ng.RetriveLatestNutritionGroupID();

                                ng.InsertNutritionGroup_FoodAllergies(nutritionGroupID, FoodAllergyName);
                              //  Response.Redirect("AdminNutritionGroupInsert.aspx");
                            }

                        }
                    }
                    //Same NutritionGroup condition
                    else if (result == true)
                    {
                        Response.Write("<script>alert('NutritionGroup Condition Exists');</script>");
                        //Check NutritionGroup_Allergies condition
                        //Boolean result2 = false; 

                    }
                }
                else if (CBMCDiabetes.Checked == true && CBDTAsian.Checked == true)
                {
                    medicalCondition = "Diabetes";
                    dietType = "Asian";
                    //Check NutritionGroup Condition
                    Boolean result = false;
                    result = ng.checkNutritionGroupCondition(groupName, medicalCondition, dietType);

                    if (result == false)
                    {

                        int result1 = 0;
                        result1 = ng.InsertNutritionGroup(groupName, medicalCondition,dietType);

                        foreach (ListItem items in CBLFoodAllergy.Items)
                        {
                            if (items.Selected)
                            {
                                string FoodAllergyName = items.Value;
                                int nutritionGroupID = ng.RetriveLatestNutritionGroupID();

                                ng.InsertNutritionGroup_FoodAllergies(nutritionGroupID, FoodAllergyName);
                               // Response.Redirect("AdminNutritionGroupInsert.aspx");
                            }

                        }
                    }
                    //Same NutritionGroup condition
                    else if (result == true)
                    {
                        Response.Write("<script>alert('NutritionGroup Condition Exists');</script>");
                        //Check NutritionGroup_Allergies condition
                        //Boolean result2 = false; 

                    }
                }
                else if (CBMCNone.Checked == true && CBDTAsian.Checked == true)
                {
                    medicalCondition = "None";
                    dietType = "Asian";
                    //Check NutritionGroup Condition
                    Boolean result = false;
                    result = ng.checkNutritionGroupCondition(groupName, medicalCondition, dietType);

                    if (result == false)
                    {

                        int result1 = 0;
                        result1 = ng.InsertNutritionGroup(groupName, medicalCondition,dietType);

                        foreach (ListItem items in CBLFoodAllergy.Items)
                        {
                            if (items.Selected)
                            {
                                string FoodAllergyName = items.Value;
                                int nutritionGroupID = ng.RetriveLatestNutritionGroupID();

                                ng.InsertNutritionGroup_FoodAllergies(nutritionGroupID, FoodAllergyName);
                               // Response.Redirect("AdminNutritionGroupInsert.aspx");
                            }

                        }
                    }
                    //Same NutritionGroup condition
                    else if (result == true)
                    {
                        Response.Write("<script>alert('NutritionGroup Condition Exists');</script>");
                        //Check NutritionGroup_Allergies condition
                        //Boolean result2 = false; 

                    }
                }

            
            }
            else
            {
                Response.Write("<script>alert('Make a selection');</script>");
            }
        }
    }
}