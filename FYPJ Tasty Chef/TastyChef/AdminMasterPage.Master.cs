using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TastyChef
{
    public partial class AdminMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLoginPage.aspx");
        }

    
        protected void BtnRecipe_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminInsertRecipeStep1.aspx");
        }

        protected void BtnNutritionGroup_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminNutritionGroupInsert.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHomePage.aspx");
        }
    }
}