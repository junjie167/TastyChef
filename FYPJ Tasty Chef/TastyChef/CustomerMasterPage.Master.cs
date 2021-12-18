using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TastyChef.DAL;

namespace TastyChef
{
    public partial class CustomerMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Control id = Master.FindControl("ContentPlaceHolder1").FindControl("printpdf");

        }

        protected void yes(object sender, EventArgs e)
        {
            Response.Redirect("CustomerNutritionAssessmentDetails.aspx");
        }

        protected void no(object sender, EventArgs e)
        {
            id01.Attributes["style"] = "display: none";
        }

        protected void nutritionprofile(object sender, EventArgs e)
        {
            CustomerNutrtionProfileClass nutritionprofile = new CustomerNutrtionProfileClass();
            string email = Session["email"].ToString();
            Boolean result = nutritionprofile.checkNutritionProfile(email);
            if(result == false)
            {
                label79.Text = " Nutrition Profile.";
                id01.Attributes["style"] = "display: block";
            }else
            {
                Response.Redirect("CustomerNutritionProfile.aspx");
            }
        }

        protected void recommendrecipe(object sender, EventArgs e)
        {
            CustomerNutrtionProfileClass nutritionprofile = new CustomerNutrtionProfileClass();
            string email = Session["email"].ToString();
            Boolean result = nutritionprofile.checkNutritionProfile(email);
            if (result == false)
            {
                label79.Text = " Recommended Recipe.";
                id01.Attributes["style"] = "display: block";
            }
            else
            {
                Response.Redirect("CustomerRecipeRecommendation1.aspx");
            }
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("CustomerHomePage.aspx");
        }
    }
}