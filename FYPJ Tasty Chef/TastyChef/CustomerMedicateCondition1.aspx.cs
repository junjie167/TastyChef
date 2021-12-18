using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TastyChef.DAL;

namespace TastyChef
{
    public partial class CustomerMedicateCondition1 : System.Web.UI.Page
    {

        

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack == false)
            {
             
                unit.Visible = false;
                gl.Visible = false;
                bloodpressure.Visible = false;
                mmHg.Visible = false;

            }
        }


        //protected void CBLMedicalCondition_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    for(int z=0; z<CBLMedicalCondition.Items.Count; z++)
        //    {
                
        //            if (CBLMedicalCondition.Items[z].Selected)
        //            {
        //            if (count <= 0)
        //            {
        //                if (CBLMedicalCondition.Items[z].Value == "Diabetes")
        //                {
        //                    glu.Visible = true;
        //                    glu.Text = "Glucose Level: ";
        //                    glucose.Visible = true;
        //                    unit.Visible = true;
        //                    unit.Text = "mmol/L";
        //                    count++;

        //                }
        //                else if (CBLMedicalCondition.Items[z].Value == "Hypertension")
        //                {
        //                    gl.Visible = true;
        //                    gl.Text = "Blood Pressure: ";
        //                    bloodpressure.Visible = true;
        //                    mmHg.Visible = true;
        //                    mmHg.Text = "mmHg";
        //                    count++;
        //                }
                        

        //            }
        //            else
        //            {
        //                if (CBLMedicalCondition.Items[z].Value == "Diabetes")
        //                {
        //                    glu.Visible = true;
        //                    glu.Text = "Glucose Level: ";
        //                    glucose.Visible = true;
        //                    unit.Visible = true;
        //                    unit.Text = "mmol/L";
        //                    count++;

        //                }
        //                else if (CBLMedicalCondition.Items[z].Value == "Hypertension")
        //                {
        //                    gl.Visible = true;
        //                    gl.Text = "Blood Pressure: ";
        //                    bloodpressure.Visible = true;
        //                    mmHg.Visible = true;
        //                    mmHg.Text = "mmHg";
        //                    count++;
        //                }
        //                else
        //                {
        //                    CBLMedicalCondition.Items[0].Selected = false;
        //                    CBLMedicalCondition.Items[1].Selected = false;
        //                    int done = count - count;
        //                    count = done;
        //                }

        //            }
                   
                      
        //            }
        
                  
        //        }
        //    }

            
        

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerFoodQuestionnaire.aspx");
        }

        protected void Sub_Click(object sender, EventArgs e)
        {
            string disease = CBLMedicalCondition.SelectedValue;
            string level = glucose.Text;
            string pressure = bloodpressure.Text;
            Response.Redirect("CustomerNutritionProfile.aspx");
        }
    }
}