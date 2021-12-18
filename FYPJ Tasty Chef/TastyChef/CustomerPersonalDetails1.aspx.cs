using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TastyChef.DAL;

namespace TastyChef
{
    public partial class CustomerPersonalDetails1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                editpanel.Visible = false;
                //deliveryaddtion.Visible = false;
                //deliverypanel.Visible = true;
                nothealthpanel.Visible = false;
                //delivery.Visible = false;
                //DateTime date = DateTime.Today;
                //string today = date.ToString("dd/MM/yyyy");
                //regDOB.MaximumValue = today;

                if (Session["email"] != null)
                {
                    string email = Session["email"].ToString();

                    //Retrieve Customer Profile
                    CustomerRegistrationClass register = new CustomerRegistrationClass();
                    List<CustomerRegistrationClass> list = new List<CustomerRegistrationClass>();
                    

                    list = register.retrieveCustomer(email);
                   
                    for (int y = 0; y < list.Count; y++)
                    {
                        string fname = list[y].fname;
                        string lname = list[y].lname;
                        name.Text = fname + " " + lname;
                        age.Text = list[y].age.ToString();
                        dob.Text = list[y].dob.ToString("dd/MM/yyyy");
                        gender.Text = list[y].gender;
                        mobile.Text = list[y].mobile + " (HP)";
                        if (list[y].house != null)
                        {
                            home.Text = list[y].house + " (Home)";
                        }
                        else
                        {
                            home.Text = "None (Home)";
                        }
                        billingadd.Text = list[y].add + " #" + list[y].unitnumber + " Singapore(" + list[y].postal + ")";
                        emails.Text = email;
                    }

                    //List<CustomerRegistrationClass> deliverylist = new List<CustomerRegistrationClass>();
                    //deliverylist = register.retrieveCustomerDelivery(email);

                    //if(deliverylist.Count > 1)
                    //{
                    //    DataTable dt = new DataTable();
                    //    dt.Columns.Add("Address");
                    //    dt.Columns.Add("UnitNumber");
                    //    dt.Columns.Add("PostalCode");
                    //    dt.Columns.Add("Id");
                    //    string deliveraddress = string.Empty;
                    //    string unitnum = string.Empty;
                    //    string posta = string.Empty;
                    //    string id = string.Empty;
                    //    for (int w = 0; w < deliverylist.Count; w++)
                    //    {
                    //        deliveraddress = deliverylist[w].add;
                    //        unitnum = deliverylist[w].unitnumber;
                    //        posta = deliverylist[w].postal;
                    //        id = deliverylist[w].deliveryid.ToString();
                    //        dt.Rows.Add(deliveraddress, unitnum, posta, id);
                    //    }
                    //    GridView1.DataSource = dt;
                    //    GridView1.DataBind();


                    //}
                    //else
                    //{
                        
                        
                    //    //DataTable dt = new DataTable();
                    //    //dt.Columns.Add("Address");
                    //    //dt.Columns.Add("UnitNumber");
                    //    //dt.Columns.Add("PostalCode");
                    //    //dt.Columns.Add("Id");
                    //    //string deliveraddress = string.Empty;
                    //    //string unitnum = string.Empty;
                    //    //string posta = string.Empty;
                    //    //string id = string.Empty;
                    //    //for (int w = 0; w < deliverylist.Count; w++)
                    //    //{
                    //    //    deliveraddress = deliverylist[w].add;
                    //    //    unitnum = deliverylist[w].unitnumber;
                    //    //    posta = deliverylist[w].postal;
                    //    //    id = deliverylist[w].deliveryid.ToString();
                    //    //    dt.Rows.Add(deliveraddress, unitnum, posta, id);
                    //    //}
                    //    //GridView1.DataSource = dt;
                    //    //GridView1.DataBind();
                    //    //for (int c = 0; c < GridView1.Rows.Count; c++)
                    //    //{
                    //    //    ImageButton re = new ImageButton();
                    //    //    re = (ImageButton)GridView1.Rows[c].FindControl("addressremove");
                    //    //    re.Visible = false;
                    //    //}
                    //}

                    
                    CustomerNutrtionProfileClass nutritionprofile = new CustomerNutrtionProfileClass();
                    List<CustomerNutrtionProfileClass> nutrition = new List<CustomerNutrtionProfileClass>();
                    List<CustomerNutrtionProfileClass> dietprofile = new List<CustomerNutrtionProfileClass>();
                    List<CustomerNutrtionProfileClass> medicalprofile = new List<CustomerNutrtionProfileClass>();

                    //Display physical and macronutrient profile
                    nutrition = nutritionprofile.retrieveNutritionProfile(email);
                    
                    if(nutrition.Count > 0)
                    {
                        for (int z = 0; z < nutrition.Count; z++)
                        {
                            height.Text = Math.Round(nutrition[z].height, 0).ToString() + " cm";
                            weight.Text = Math.Round(nutrition[z].weight, 0).ToString() + " kg";
                            activity.Text = nutrition[z].activitylevel;
                            decimal bm = nutrition[z].bmi;
                            bmi.Text = bm.ToString();
                            if (bm < (decimal)18.5)
                            {
                                risk.ForeColor = System.Drawing.Color.Red;
                                risk.Text = "(Lack of nutrition risk)";

                            }
                            else if (bm >= (decimal)18.5 && bm < (decimal)23.9)
                            {
                                risk.ForeColor = System.Drawing.Color.Green;
                                risk.Text = "(Low Risk)";

                            }
                            else if (bm >= (decimal)23.9 && bm < (decimal)27.5)
                            {
                                risk.ForeColor = System.Drawing.Color.OrangeRed;
                                risk.Text = "(Moderate Risk)";

                            }
                            else
                            {
                                risk.ForeColor = System.Drawing.Color.Red;
                                risk.Text = "(High Risk)";
                            }
                            weightstatus.Text = nutrition[z].weightstatus;
                        }


                        //Display diet profile
                        dietprofile = nutritionprofile.retrieveDietaryProfile(email);
                        int countwords = 0;
                        for (int w = 0; w < dietprofile.Count; w++)
                        {
                            diet.Text = dietprofile[w].diettype;
                            countwords = countword(dietprofile[w].allergy);
                            int num = 1;
                            for (int x = 0; x < countwords; x++)
                            {
                                if (countwords != 1)
                                {
                                    allergy.Text += num + ") " + dietprofile[w].allergy.Split(' ')[x] + "<br/>";
                                    num++;
                                }else
                                {
                                    allergy.Text = dietprofile[w].allergy.Split(' ')[x];
                                }
                                
                            }
                            countwords = countword(dietprofile[w].avoid);
                            num = 1;
                            for (int r = 0; r < countwords; r++)
                            {
                                if (countwords != 1)
                                {
                                    avoid.Text += num + ") " + dietprofile[w].avoid.Split(' ')[r] + "<br/>";
                                    num++;
                                }else
                                {
                                    avoid.Text = dietprofile[w].avoid.Split(' ')[r];
                                }
                                
                            }
                            meal.Text = dietprofile[w].meal.ToString() + " times";
                            snack.Text = dietprofile[w].snack.ToString() + " times";
                        }

                        //Display medicate profile
                        medicalprofile = nutritionprofile.retrieveMedicateProfile(email);
                        for (int q = 0; q < medicalprofile.Count; q++)
                        {
                            int number = 1;
                            countwords = countword(medicalprofile[q].medical);
                            for (int y = 0; y < countwords; y++)
                            {
                                if(countwords != 1)
                                {
                                    medical.Text += number + ") " + medicalprofile[q].medical.Split(' ')[y] + "<br/>";
                                    number++;
                                }else
                                {
                                    medical.Text = medicalprofile[q].medical.Split(' ')[y];
                                }
                              
                            }

                            if (medicalprofile[q].glucose != 0.0M)
                            {
                                glu.Visible = true;
                                glucose.Visible = true;
                                glucose.Text = Math.Round(medicalprofile[q].glucose, 0).ToString() + " mmol/L";
                            }
                            else
                            {
                                glu.Visible = false;
                                glucose.Visible = false;
                            }
                        }


                    }else
                    {
                        healthpanel.Visible = false;
                        nothealthpanel.Visible = true;
                        //db.Attributes.Add( "style","clear:both; margin-top:525px;");
                      
                    }

                }


            }

        }
        public int countword(string sentence)
        {

            string[] word = sentence.Split(' ');
            int wordCount = word.Count() - 1;
            return wordCount;
        }

        protected void edit_Click(object sender, EventArgs e)
        {

            if(edit.Text == "Save")
            {
                string first = firstname.Text;
                string last = lastname.Text;
                DateTime dob = Convert.ToDateTime(dateofbirth.Text);
                DateTime today = DateTime.Today;
                int year = today.Year;
                int dobyear = dob.Year;
                int age = year - dobyear;
                string g = gende.SelectedValue;
                string handphone = moo.Text;
                string homephone = hoo.Text;
                string postal = postalcode.Text;
                add.Text = Request.Form[hfName.UniqueID];
                string address = add.Text;
                string u = unitnumber.Text;
                CustomerRegistrationClass register = new CustomerRegistrationClass();
                register.updateCusstomerdetails(first, last, dob, g, handphone, homephone, age, emailaddress.Text,postal,address,u);
                ScriptManager.RegisterStartupScript(this, this.GetType(),"alert", "alert('Update Successfully');window.location ='CustomerPersonalDetails1.aspx';", true); 
                edit.Text = "Edit";
                edit.Attributes.Add("style", "background:#4DB6AC;");
                editpanel.Visible = false;
                notedit.Visible = true;
                //db.Attributes.Add("style", "margin-top:385px;");

            }
            else
            {
                //db.Attributes.Add("style", "margin-top:585px;");

                if (Session["email"] != null)
                {
                    string email = Session["email"].ToString();

                    //Retrieve Customer Profile
                    CustomerRegistrationClass register = new CustomerRegistrationClass();
                    List<CustomerRegistrationClass> list = new List<CustomerRegistrationClass>();
                    list = register.retrieveCustomer(email);
                    for (int y = 0; y < list.Count; y++)
                    {
                        firstname.Text = list[y].fname;
                        lastname.Text = list[y].lname;
                        dateofbirth.Text = list[y].dob.ToString("dd/MM/yyyy");
                        if (list[y].gender == "Female")
                        {
                            gende.SelectedValue = list[y].gender;
                        }
                        else
                        {
                            gende.SelectedValue = list[y].gender;
                        }
                        moo.Text = list[y].mobile;
                        if (list[y].house != null)
                        {
                            hoo.Text = list[y].house;
                        }
                        else
                        {
                            hoo.Text = "None";
                        }
                        postalcode.Text = list[y].postal;
                        add.Text = list[y].add;
                        hfName.Value = add.Text;
                        unitnumber.Text = list[y].unitnumber;
                        emailaddress.Text = email;
                        emailaddress.Enabled = false;
                    }
                }
                editpanel.Visible = true;
                notedit.Visible = false;
                edit.Text = "Save";
                edit.Attributes.Add("style", "background: Red;");
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            edit.Text = "Edit";
            edit.Attributes.Add("style", "background:#4DB6AC;");
            editpanel.Visible = false;
            notedit.Visible = true;
            //db.Attributes.Add("style", "margin-top:485px;");

        }

        //protected void adddelivery_Click(object sender, EventArgs e)
        //{
        //    if(adddelivery.Text == "Save")
        //    {
        //        if(addresshead.InnerText == "Edit Address")
        //        {
        //            string email = Session["email"].ToString();
        //            CustomerRegistrationClass register = new CustomerRegistrationClass();
        //            string po = postalcode.Text;
        //            newaddress.Text = Request.Form[hfName.UniqueID];
        //            string addresss = newaddress.Text;
        //            string uni = unitnumber.Text;
        //            string id = delivery.Text;
        //            int deliveryid = int.Parse(id);
        //            register.updatedelivery(email, po, addresss, uni, deliveryid);
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You have Successfully updated your delivery address');window.location ='CustomerPersonalDetails1.aspx';", true);
        //            deliverypanel.Visible = true;
        //            deliveryaddtion.Visible = false;
        //            addresshead.InnerText = "Add New Address";
        //        }
        //        else
        //        {
        //            string email = Session["email"].ToString();
        //            CustomerRegistrationClass register = new CustomerRegistrationClass();
        //            string p = postalcode.Text;
        //            newaddress.Text = hfName.Value;
        //            string addresss = newaddress.Text;
        //            string uni = unitnumber.Text;
        //            register.createDeliveryAddress(email, p, addresss, uni);
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You have Successfully add new delivery address');window.location ='CustomerPersonalDetails1.aspx';", true);
        //            deliverypanel.Visible = true;
        //            deliveryaddtion.Visible = false;
        //            addresshead.InnerText = "Add New Address";
        //        }
        //    }
        //    else
        //    {
        //        deliveryaddtion.Visible = true;
        //        headline.Visible = true;
        //        adddelivery.Text = "Save";
        //        adddelivery.Attributes.Add("style", "background:red; margin-top:0px;");
        //    }
        //}


        //protected void addressedit_Click(object sender, ImageClickEventArgs e)
        //{
        //    deliverypanel.Visible = false;
        //    deliveryaddtion.Visible = true;
        //    headline.Visible = false;
        //    addresshead.InnerText = "Edit Address";
        //    adddelivery.Text = "Save";
        //    adddelivery.Attributes.Add("style", "background:Red; margin-top:0px;");
        //    GridViewRow clickedRow = (GridViewRow)((ImageButton)sender).NamingContainer;
        //    Label lbladdress = (Label)clickedRow.FindControl("address8");
        //    string addressss = lbladdress.Text;
        //    newaddress.Text = lbladdress.Text;
        //    hfName.Value = newaddress.Text;
        //    Label lblunitnumber = (Label)clickedRow.FindControl("unitnumber");
        //    string unitnum = lblunitnumber.Text;
        //    unitnumber.Text = unitnum;
        //    Label lblpostal = (Label)clickedRow.FindControl("postall");
        //    string post = lblpostal.Text;
        //    postalcode.Text = post;
        //    Label lblid = (Label)clickedRow.FindControl("deliveryid");
        //    string id = lblid.Text;
        //    delivery.Text = id;
        //}

        //protected void removeaddress(object sender, ImageClickEventArgs e)
        //{
        //    GridViewRow clickedRow = (GridViewRow)((ImageButton)sender).NamingContainer;
        //    string email = Session["email"].ToString();
        //    CustomerRegistrationClass register = new CustomerRegistrationClass();
        //    Label lblid = (Label)clickedRow.FindControl("deliveryid");
        //    string id = lblid.Text;
        //    int deliveryid = int.Parse(id);
        //    register.removeAddress(email, deliveryid);
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You have Successfully remove your delivery address');window.location ='CustomerPersonalDetails1.aspx';", true);

        //}

        //protected void addcancel_Click(object sender, EventArgs e)
        //{
           
        //        deliveryaddtion.Visible = false;
        //        deliverypanel.Visible = true;
        //        headline.Visible = true;
        //        adddelivery.Text = "Add New Address";
        //        adddelivery.Attributes.Add("style", "background:#4DB6AC");
            
       
        //}

        protected void proceed_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerNutritionAssessment1.aspx");
        }

        protected void edit2_click(object sender, EventArgs e)
        {
            Session["num"] = 1;
            Response.Redirect("CustomerNutritionAssessment1.aspx");
            
        }

        protected void edit3_click(object sender, EventArgs e)
        {
            Session["num"] = 2;
            Response.Redirect("CustomerNutritionAssessment1.aspx");
            
        }
        protected void edit4_click(object sender, EventArgs e)
        {
            Session["num"] = 3;
            Response.Redirect("CustomerNutritionAssessment1.aspx");
            
        }
    }

        
    }
