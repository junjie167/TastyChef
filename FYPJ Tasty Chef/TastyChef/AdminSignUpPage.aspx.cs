using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TastyChef.DAL;

namespace TastyChef
{
    public partial class AdminSignUpPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLoginPage.aspx");
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            //Check is Login ID Exists
            string loginID = TbLoginID.Text;
            Admin a = new Admin();
            int result = 0;
            result = a.checkLoginID(loginID);
            if (result > 0)
            {
                LblErrorMessage.Visible = true;
                LblErrorMessage.Text = "Login ID Exist!";
                TbLoginID.Text = "";
            }
            else
            {
                string password = EncryptPassword(TbPassword.Text);
                string name = TbName.Text;

                Admin a1 = new Admin(loginID, password, name);
                int results = 0;
                results = a1.InsertAdmin();
                if (results > 0)
                {
                    Response.Redirect("AdminHomePage.aspx");
                }
                else
                {
                    Response.Write("Failed to Create Account");
                }
            }
            
          
        }
        public static string EncryptPassword(string passwordd)
        {
            string msg = string.Empty;
            byte[] encode = new byte[passwordd.Length];
            encode = Encoding.UTF8.GetBytes(passwordd);
            msg = Convert.ToBase64String(encode);
            return msg;
        }

        protected void TbLoginID_TextChanged(object sender, EventArgs e)
        {
            //Check is Login ID Exists
            string loginID = TbLoginID.Text;
            Admin a = new Admin();
            int result = 0;
            result = a.checkLoginID(loginID);
            if (result == 1)
            {
                LblErrorMessage.Visible = true;
                LblErrorMessage.Text = "Login ID Exist!";
                TbLoginID.Text = "";
            }
            else
            {
                LblErrorMessage.Visible = true;
                LblErrorMessage.Text = "Login ID is available";
               
            }

        }
    }

}