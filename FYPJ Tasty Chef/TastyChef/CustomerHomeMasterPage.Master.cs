using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TastyChef.DAL;
using System.Text;

namespace TastyChef
{
    public partial class CustomerHomeMasterPage : System.Web.UI.MasterPage
    {
        public static Boolean recommendreciperesult = false;
        public static Boolean shoppingcartresult = false;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void signup_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerRegistration.aspx");

        }


        protected void login(object sender, EventArgs e)
        {
            string user = username.Text;
            string pass = Encrypt(password.Text);
            CustomerRegistrationClass register = new CustomerRegistrationClass();
            CustomerNutrtionProfileClass profile = new CustomerNutrtionProfileClass();

            if (register.checkuser(user, pass) == true)
            {
                Session["email"] = user;

                if (profile.checkNutritionProfile(user) == false)
                {
                    Response.Redirect("CustomerNutritionAssessmentDetails.aspx");

                }else{

                    if (shoppingcartresult)
                    {
                        Response.Redirect("CustomerShoppingCart.aspx");
                    }
                    else
                    {
                        Response.Redirect("CustomerSummary.aspx");
                    }
                }               
            }
            else
            {
                Response.Write("<script>alert('Please enter valid Username and Password')</script>");
                id01.Attributes["style"] = "display:block";
            }

        }





        private string Encrypt(string passwordd)
        {
            string msg = string.Empty;
            byte[] encode = new byte[passwordd.Length];
            encode = Encoding.UTF8.GetBytes(passwordd);
            msg = Convert.ToBase64String(encode);
            return msg;
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            if(Session["email"] == null)
            {
                id01.Attributes["style"] = "display:block";
                shoppingcartresult = true;
            }
        }

    }
}