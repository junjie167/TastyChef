using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TastyChef.DAL;

namespace TastyChef
{
    public partial class CustomerFoodQuestionnaire : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                allergyother.Visible = false;
                otheravoid.Visible = false;

                //if (Session["FoodQuestionaire"] != null)
                //{
                //    CustomerFoodQuestionnaireClass b = (CustomerFoodQuestionnaireClass)Session["FoodQuestionaire"];
                //    diettype.SelectedValue = b.diet;
                //    string a = b.allergies;
                //    int count = a.Split(' ').Length;
                //    for(int z = 0; z < allergies.Items.Count; z++)
                //    {
                //        for(int x = 0; x < count; x++)
                //        {
                //            if(allergies.Items[z].Value != a.Split(',')[x])
                //            {
                //                allergies.Items[z].Selected = false;
                //            }
                //            else
                //            {
                //                allergies.Items[z].Selected = true;
                //            }
                            
                //        }
                        
                //    }
                //    mealfrequency.Text = b.meal.ToString();
                //    snackfrequency.Text = b.snack.ToString();

                //    //for (int w = 0; w < count; w++)
                //    //{
                //    //    for (int q = 0; q < allergies.Items.Count; q++) 
                //    //    {
                //    //        if (allergies.Items[q].Value == a.Split(',')[w])
                //    //        {
                //    //            allergies.Items[q].Selected = true;
                //    //        }
                //    //    }
                //    //}




                //}
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerPhysicalRegister.aspx");
        }

        protected void Next_Click(object sender, EventArgs e)
        {
            string diet = diettype.SelectedValue;

            string text = string.Empty;
            for(int z = 0; z < allergies.Items.Count; z++)
            {
                if (allergies.Items[z].Selected)
                {
                    text += allergies.Items[z].Value+", ";
                }
            }

            string avo = string.Empty;
            for(int x = 0; x < avoid.Items.Count; x++)
            {
                if (avoid.Items[x].Selected)
                {
                    avo += avoid.Items[x].Value+", ";
                }
            }
            int meal = int.Parse(mealfrequency.Text);
            int snack = int.Parse(snackfrequency.Text);

            CustomerFoodQuestionnaireClass FoodQuestionnaire = new CustomerFoodQuestionnaireClass(diet, text, avo,meal,snack);
            Session["FoodQuestionaire"] = FoodQuestionnaire;

            Response.Redirect("CustomerMedicateCondition1.aspx");
        }

        protected void other_CheckedChanged(object sender, EventArgs e)
        {
            if(other.Checked == true)
            {
                allergyother.Visible = true;
            }
        }

        protected void otheravoidance_CheckedChanged(object sender, EventArgs e)
        {
            if(otheravoidance.Checked == true)
            {
                otheravoid.Visible = true;
            }
        }
    }
}