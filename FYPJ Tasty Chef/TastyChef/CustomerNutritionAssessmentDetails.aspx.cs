using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TastyChef
{
    public partial class CustomerNutritionAssessmentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void continue_click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerNutritionAssessment1.aspx");
        }
    }
}