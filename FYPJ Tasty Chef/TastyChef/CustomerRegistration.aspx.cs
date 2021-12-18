using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using TastyChef.DAL;
using System.Web.UI.HtmlControls;

namespace TastyChef
{
    public partial class CustomerRegistration : System.Web.UI.Page
    {

        public static Boolean r = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack == false)
            {
                load.Visible = false;
                DateTime date = DateTime.Today;
                string today = date.ToString("dd/MM/yyyy");
                regDOB.MaximumValue = today;
                emailholder.Visible = true;
                personalholder.Visible = false;
                deliveryholder.Visible = false;
                confirmationholder.Visible = false;
                if(r != false)
                {
                    id02.Attributes["style"] = "display: block";
                    r = false;
                }

            }

        }

        protected void Next_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("CustomerSummary.aspx");
        }


        protected void continue_Click(object sender, EventArgs e)
        {
            CustomerRegistrationClass register = new CustomerRegistrationClass();
            Boolean result = register.checkEmail(email.Text);
            if (result != false)
            {
                emailerror.Visible = true;
                emailerror.Text = "Email Address is already exist";
            }else
            {
                emailholder.Visible = false;
                personalholder.Visible = true;
                s2.Attributes.Add("style", "color:white;background-color:#4DB6AC;");
                password.Attributes.Add("onkeypress", "Passstrength()");
                string emails = email.Text;
                Session["email1"] = emails;
            }
         
        }

        protected void continue2_Click(object sender, EventArgs e)
        {
            if(password.Text != retypePass.Text)
            {
                retypeerror.Visible = true;
                retypeerror.Text = "Your password does not match with retype password";
                password.Focus();
            }else
            {
                personalholder.Visible = false;
                deliveryholder.Visible = true;
                s3.Attributes.Add("style", "color:white;background-color:#4DB6AC;");
                DateTime dob = Convert.ToDateTime(DOB.Text);
                DateTime today = DateTime.Today;
                int year = today.Year;
                int dobyear = dob.Year;
                int age = year - dobyear;
                string passwordd = Encrypt(password.Text);
                string email = Session["email1"].ToString();
                CustomerRegistrationClass register = new CustomerRegistrationClass(firstname.Text, lastname.Text, gender.SelectedValue, dob, age, mobilenumber.Text, housenumber.Text, email, passwordd);
                Session["personal"] = register;
            }

           
        }

        protected void continue3_Click(object sender, EventArgs e)
        {
            add.Text = Request.Form[hfName.UniqueID];
            CustomerRegistrationClass register0 = new CustomerRegistrationClass(Postalcode.Text, add.Text, UnitNumber.Text);
            Session["delivery"] = register0;
            deliveryholder.Visible = false;
            confirmationholder.Visible = true;
            s4.Attributes.Add("style", "color:white;background-color:#4DB6AC;");
            string email = Session["email1"].ToString();
            conemail.Text = email;
            CustomerRegistrationClass register1 = (CustomerRegistrationClass)Session["personal"];
            confname.Text = register1.fname;
            conlast.Text = register1.lname;
            congender.Text = register1.gender;
            condob.Text = register1.dob.ToString("dd/MM/yyyy");
            conmobile.Text = register1.mobile + "(Hp)";
            if (register1.house != string.Empty)
            {
                conhouse.Text = register1.house + "(Home)";
            }else
            {
                conhouse.Visible = false;
            }    
            CustomerRegistrationClass register00 = (CustomerRegistrationClass)Session["delivery"];
            conadd.Text = register00.add + " #" + register00.unitnumber + " Singapore(" + register00.postal + ")"; 

        }

        protected void back_Click(object sender, EventArgs e)
        {
            personalholder.Visible = false;
            emailholder.Visible = true;
            email.Text = Session["email1"].ToString();
        }

        protected void back2_Click(object sender, EventArgs e)
        {
            deliveryholder.Visible = false;
            personalholder.Visible = true;
            CustomerRegistrationClass register = (CustomerRegistrationClass)Session["personal"];
            firstname.Text = register.fname;
            lastname.Text = register.lname;
            gender.SelectedValue = register.gender;
            DOB.Text = register.dob.ToString("dd/MM/yyyy");
            mobilenumber.Text = register.mobile;
            housenumber.Text = register.house;
        }

        protected void back3_Click(object sender, EventArgs e)
        {
            confirmationholder.Visible = false;
            deliveryholder.Visible = true;
            CustomerRegistrationClass register = (CustomerRegistrationClass)Session["delivery"];
            Postalcode.Text = register.postal;
            address.Text = register.add;
            UnitNumber.Text = register.unitnumber;
        }

        private string Encrypt(string passwordd)
        {
            string msg = string.Empty;
            byte[] encode = new byte[passwordd.Length];
            encode = Encoding.UTF8.GetBytes(passwordd);
            msg = Convert.ToBase64String(encode);
            return msg;
        }

        protected void CreateAccount_Click(object sender, EventArgs e)
        {
            load.Visible = true;
            string email = Session["email1"].ToString();
            CustomerRegistrationClass register0 = (CustomerRegistrationClass)Session["delivery"];
            string addresss = register0.add;
            string postal = register0.postal;
            string unitnumber = register0.unitnumber;
            CustomerRegistrationClass register1 = (CustomerRegistrationClass)Session["personal"];
            string fname = register1.fname;
            string lname = register1.lname;
            string gende = register1.gender;
            DateTime dob = register1.dob;
            int age = register1.age;
            string mobileNum = register1.mobile;
            string houseNum = register1.house;
            string emailaddress = email;
            string passwordd = register1.password;
            CustomerRegistrationClass register = new CustomerRegistrationClass();
            register.createCustomer(emailaddress, fname, lname, gende, dob, postal, addresss, unitnumber, mobileNum, houseNum, passwordd, age);
            register.createDeliveryAddress(emailaddress, postal, addresss, unitnumber);
            r = true;
            Response.AddHeader("REFRESH", "2;URL=CustomerRegistration.aspx");
        }

        protected void login_click(object sender, EventArgs e)
        {
            id02.Attributes["style"] = "display: none";
            ((HtmlGenericControl)this.Page.Master.FindControl("id01")).Style.Add("display", "block");
        }

        protected void home_click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerHomePage.aspx");
        }

        //protected void password_TextChanged(object sender, EventArgs e)
        //{
        //    int word = 0;
        //    word = password.Text.Length;
        //    if(word < 4)
        //    {
        //        passstrength.Text = "Strength: Weak";

        //    }else if(word >= 4 && word < 6)
        //    {
        //        passstrength.Text = "Strength: Moderate";

        //    }else
        //    {
        //        passstrength.Text = "Strength: Strong";
        //    }
        //}
    }
}