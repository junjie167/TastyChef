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
    public partial class AdminLoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminSignUpPage.aspx");
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            Admin a = new Admin();
            string loginID = TbLoginID.Text;
            string password = EncryptPassword(TbPassword.Text);
            Boolean result = false;
            result = a.checkAdminUser(loginID, password);
            if (result == true)
            {

                Session["LoginID"] = loginID;
                Response.Redirect("AdminHomePage.aspx");
            }
            else
            {
                Response.Write("<script>alert('Please enter valid Username and Password')</script>");
                TbPassword.Text = "";
                TbLoginID.Text = "";
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
    }
}