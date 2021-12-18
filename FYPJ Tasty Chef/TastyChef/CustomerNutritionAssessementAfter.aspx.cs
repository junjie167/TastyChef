using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TastyChef.DAL;

namespace TastyChef
{
    public partial class CustomerNutritionAssessementAfter : System.Web.UI.Page
    {
        public static Boolean results = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                load.Visible = false;

                if (results != false)
                {
                    CustomerNutrtionProfileClass nutritionprofile = new CustomerNutrtionProfileClass();
                    string email = Session["email"].ToString();
                    Boolean result = nutritionprofile.checkNutritionProfile(email);
                    if (result != false)
                    {
                        id01.Attributes["style"] = "display: block";
                    }
                }

                if(Session["email"] != null)
                {
                   

                    CustomerNutrtionProfileClass nutritionlist = new CustomerNutrtionProfileClass();
                    nutritionlist = (CustomerNutrtionProfileClass)Session["nutriton"];
                    height.Text = Math.Round(nutritionlist.height,0).ToString() + " cm";
                    weight.Text = Math.Round(nutritionlist.weight,0).ToString() + " kg";
                    activity.Text = nutritionlist.activitylevel;
                    decimal bm = nutritionlist.bmi;
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
                    weightstatus.Text = nutritionlist.weightstatus;

                    CustomerNutrtionProfileClass dietlist = new CustomerNutrtionProfileClass();
                    dietlist = (CustomerNutrtionProfileClass)Session["diet"];
                    diet.Text = dietlist.diettype;
                    int countwords = 0;
                    countwords = countword(dietlist.allengyies);
                    int num = 1;
                    for(int a = 0; a < countwords; a++)
                    {
                        if (countwords != 1)
                        {
                            allergy.Text += num + " ) " + dietlist.allengyies.Split(' ')[a] + "<br/>";
                            num++;
                        }else
                        {
                            allergy.Text = dietlist.allengyies.Split(' ')[a];
                        }
                        
                    }
                    countwords = countword(dietlist.avoid);
                    int number = 1;
                    for(int b = 0; b < countwords; b++)
                    {
                        if (countwords != 1)
                        {
                            avoid.Text += number + " ) " + dietlist.avoid.Split(' ')[b] + "<br/>";
                            number++;
                        }else
                        {
                            avoid.Text = dietlist.avoid.Split(' ')[b];
                        }
                        
                    }
                    meal.Text = dietlist.meal.ToString() + " times";
                    snack.Text = dietlist.snack.ToString() + " times";


                    CustomerNutrtionProfileClass medicallist = new CustomerNutrtionProfileClass();
                    medicallist = (CustomerNutrtionProfileClass)Session["medical"];
                    countwords = countword(medicallist.medical);
                    int n = 1;
                    for(int c = 0; c < countwords; c++)
                    {
                        if (countwords != 1)
                        {
                            medical.Text += n + " ) " + medicallist.medical.Split(' ')[c] + "<br/>";
                            n++;
                        }else
                        {
                            medical.Text = medicallist.medical.Split(' ')[c];
                        }
                      
                    }
                    if(dietlist.glucose != 0.0M)
                    {
                        glu.Visible = true;
                        glucose.Visible = true;
                        glucose.Text = Math.Round(medicallist.glucose, 0).ToString() + "mmol/L";
                    }else
                    {
                        glu.Visible = false;
                        glucose.Visible = false;
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

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerNutritionAssessment1.aspx");
        }

        protected void generate_Click(object sender, EventArgs e)
        {
            //HtmlMeta meta = new HtmlMeta();
            //meta.HttpEquiv = "Refresh";
            //meta.Content = "5;url=CustomerRecipeRecommendation1.aspx";
            //this.Page.Controls.Add(meta);
            // Add Fake Delay to simulate long running process.
            //System.Threading.Thread.Sleep(5000);
            //Response.Redirect("CustomerRecipeRecommendation1.aspx");
            string email = Session["email"].ToString();
            load.Visible = true;
            CustomerNutrtionProfileClass nutritionprofile = new CustomerNutrtionProfileClass();
            CustomerNutrtionProfileClass nutritionlist = new CustomerNutrtionProfileClass();
            nutritionlist = (CustomerNutrtionProfileClass)Session["nutriton"];
            nutritionprofile.createNutritionProfile(email, nutritionlist.carbohydraterange, nutritionlist.proteinrange, nutritionlist.fatsrange, nutritionlist.calories, nutritionlist.activitylevel, nutritionlist.bmi, nutritionlist.bmr, nutritionlist.height, nutritionlist.weight, nutritionlist.weightstatus, nutritionlist.levelcarbohydrate);
            CustomerNutrtionProfileClass dietlist = new CustomerNutrtionProfileClass();
            dietlist = (CustomerNutrtionProfileClass)Session["diet"];
            nutritionprofile.createDietProfile(dietlist.diettype, dietlist.allengyies, dietlist.avoid, dietlist.meal, dietlist.snack, email);
            CustomerNutrtionProfileClass medicallist = new CustomerNutrtionProfileClass();
            medicallist = (CustomerNutrtionProfileClass)Session["medical"];
            nutritionprofile.createMedicalProfile(medicallist.medical, medicallist.glucose, email);
            results = true;
            Response.AddHeader("REFRESH", "5;URL=CustomerNutritionAssessementAfter.aspx");
            //Response.AddHeader("REFRESH", "7;URL=CustomerRecipeRecommendation1.aspx");

        }

        protected void viewrecommend_Clik(object sender, EventArgs e)
        {
            Response.Redirect("CustomerRecipeRecommendation1.aspx");
        }
    }
}