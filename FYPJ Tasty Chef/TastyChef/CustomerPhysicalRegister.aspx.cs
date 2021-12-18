using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TastyChef.DAL;

namespace TastyChef
{
    public partial class CustomerPhysicalRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack == false)
            {
                //if(Session["PhysicalRegister"] != null)
                //{
                //    CustomerPhysicalRegisterClass p = (CustomerPhysicalRegisterClass)Session["PhysicalRegister"];
                //    height.Text = p.height.ToString();
                //    weight.Text = p.weight.ToString();
                //    level.SelectedValue = p.activity;

                //}
            }

        }

       

     

        protected void Next_Click(object sender, EventArgs e)
        {
            decimal h = Decimal.Parse(height.Text);
            decimal w = Decimal.Parse(weight.Text);
            decimal a = 0.0M;
            decimal bmr = 0.0M;
            decimal calories = 0.0M;
            decimal bmi = 0.0M;

            //if(level.SelectedValue == "Sedentary")
            //{
            //    a = (decimal)1.2;
            //}else if(level.SelectedValue == "Lightly Active")
            //{
            //    a = (decimal)1.375;
            //}else if(level.SelectedValue == "Moderately Active")
            //{
            //    a = (decimal)1.55;
            //}else if(level.SelectedValue == "Very Active")
            //{
            //    a = (decimal)1.725;
            //}else
            //{
            //    a = (decimal)1.9;
            //}

            //string email = Session["email"].ToString();
            //CustomerRegistrationClass register = new CustomerRegistrationClass();
            //List<CustomerRegistrationClass> registerlist = new List<CustomerRegistrationClass>();
            //registerlist = register.retrieveCustomer(email);
            //int age = registerlist[0].age;
            //string gender = registerlist[0].gender;

            //CustomerPhysicalRegisterClass p = new CustomerPhysicalRegisterClass();
            //CustomerPhysicalRegisterClass PhysicalRegister = new CustomerPhysicalRegisterClass(h, w, level.SelectedValue, calories, bmi, bmr);
            //Session["PhysicalRegister"] = PhysicalRegister;
            //Response.Redirect("CustomerFoodQuestionnaire.aspx");
        }
    }
}