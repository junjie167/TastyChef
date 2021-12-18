using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TastyChef.DAL;

namespace TastyChef
{
    public partial class CustomerNutritionAssessment1 : System.Web.UI.Page
    {
        int count = 0;
        public static int allergynum = 0;
        public static int allergynumss = 0;
        public static int allergynumsss = 0;
        public static int allergynumssss = 0;
        public static int avoidnum = 0;
        public static int avoidnumss = 0;
        public static int avoidnumsss = 0;
        public static int avoidnumssss = 0;
        public static int number = 0;
        public static int numberss = 0;
        public static Boolean r = false;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.IsPostBack == false)
            {
                

                glu.Visible = false;
                glucose.Visible = false;
                unit.Visible = false;
                bloodpressure.Visible = false;
                gl.Visible = false;
                mmHg.Visible = false;
                otheravoid.Visible = false;
                load.Visible = false;

                if (Session["email"] != null)
                {
                    //Retrieve Customer Physical Profile information
                    string email = Session["email"].ToString();
                    CustomerNutrtionProfileClass nutritionprofile = new CustomerNutrtionProfileClass();
                    Boolean result = nutritionprofile.checkNutritionProfile(email);

                    allergies.DataSource = nutritionprofile.retrieveFoodAllergy();
                    allergies.DataBind();

                    if (result != false)
                    {
                        int focusnum = int.Parse(Session["num"].ToString());
                        
                        if(focusnum == 1)
                        {
                            Label13.Focus();

                        }else if(focusnum == 2)
                        {
                            snackfrequency.Focus();
                        }else
                        {
                            sub.Focus();
                        }

                        List<CustomerNutrtionProfileClass> nutritionlist = new List<CustomerNutrtionProfileClass>();
                        nutritionlist = nutritionprofile.retrieveNutritionProfile(email);
                        for (int z = 0; z < nutritionlist.Count; z++)
                        {
                            height.Text = Math.Round(nutritionlist[z].height, 0).ToString();
                            weight.Text = Math.Round(nutritionlist[z].weight, 0).ToString();
                            if (nutritionlist[z].activitylevel == "Sedentary")
                            {
                                sedentary.Checked = true;
                            }
                            else if (nutritionlist[z].activitylevel == "Lighty Active")
                            {
                                lightly.Checked = true;
                            }
                            else if (nutritionlist[z].activitylevel == "Moderately Active")
                            {
                                moderate.Checked = true;
                            }
                            else if (nutritionlist[z].activitylevel == "Very Active")
                            {
                                veryactive.Checked = true;
                            }
                            else
                            {
                                extreme.Checked = true;
                            }

                            //Retrieve Customer diet profile
                            int wordcount = 0;
                            List<CustomerNutrtionProfileClass> dietlist = new List<CustomerNutrtionProfileClass>();
                            dietlist = nutritionprofile.retrieveDietaryProfile(email);
                            diettype.SelectedValue = dietlist[z].diettype;
                            wordcount = countword(dietlist[z].allergy);
                            for (int t = 0; t < wordcount; t++)
                            {
                                for (int q = 0; q < allergies.Items.Count; q++)
                                {
                                    if (allergies.Items[q].Value == dietlist[z].allergy.Split(' ')[t])
                                    {
                                        allergies.Items[q].Selected = true;
                                    }
                                }
                            }
                            wordcount = countword(dietlist[z].avoid);
                            for (int u = 0; u < wordcount; u++)
                            {
                                for (int p = 0; p < avoid.Items.Count; p++)
                                {
                                    if (avoid.Items[p].Value == dietlist[z].avoid.Split(' ')[u])
                                    {
                                        avoid.Items[p].Selected = true;
                                    }
                                }
                            }
                            mealfrequency.Text = dietlist[z].meal.ToString();
                            snackfrequency.Text = dietlist[z].snack.ToString();

                            //Retrieve customer medical Condition
                            List<CustomerNutrtionProfileClass> medicallist = new List<CustomerNutrtionProfileClass>();
                            medicallist = nutritionprofile.retrieveMedicateProfile(email);
                            wordcount = countword(medicallist[z].medical);
                            for (int l = 0; l < wordcount; l++)
                            {
                                for (int m = 0; m < CBLMedicalCondition.Items.Count; m++)
                                {
                                    if (CBLMedicalCondition.Items[m].Value == medicallist[z].medical.Split(' ')[l])
                                        CBLMedicalCondition.Items[m].Selected = true;
                                }
                            }
                            if (medicallist[z].glucose != 0)
                            {
                                glu.Visible = true;
                                unit.Visible = true;
                                glucose.Visible = true;
                                glucose.Text = Math.Round(medicallist[z].glucose, 0).ToString();
                            }
                            sub.Text = "Update";
                            back.Text = "Cancel";
                            s1.Visible = false;
                            s2.Visible = false;
                            s3.Visible = false;
                            hrr.Visible = false;
                            subtitlehead.Visible = false;
                            if (r != false)
                            {
                                id01.Attributes["style"] = "display: block";
                                r = false;
                            }
                        }

                    }else
                    {
                        if (Session["nutriton"] != null)
                        {
                            CustomerNutrtionProfileClass nutritionlist1 = new CustomerNutrtionProfileClass();
                            nutritionlist1 = (CustomerNutrtionProfileClass)Session["nutriton"];
                            height.Text = Math.Round(nutritionlist1.height, 0).ToString();
                            weight.Text = Math.Round(nutritionlist1.weight, 0).ToString();
                            if (nutritionlist1.activitylevel == "Sedentary")
                            {
                                sedentary.Checked = true;
                            }
                            else if (nutritionlist1.activitylevel == "Lighty Active")
                            {
                                lightly.Checked = true;
                            }
                            else if (nutritionlist1.activitylevel == "Moderately Active")
                            {
                                moderate.Checked = true;
                            }
                            else if (nutritionlist1.activitylevel == "Very Active")
                            {
                                veryactive.Checked = true;
                            }
                            else
                            {
                                extreme.Checked = true;
                            }

                            CustomerNutrtionProfileClass dietlist1 = new CustomerNutrtionProfileClass();
                            dietlist1 = (CustomerNutrtionProfileClass)Session["diet"];
                            diettype.SelectedValue = dietlist1.diettype;
                            int wordcount = 0;
                            wordcount = countword(dietlist1.allengyies);
                            for (int a = 0; a < wordcount; a++)
                            {
                                for (int q = 0; q < allergies.Items.Count; q++)
                                {
                                    if (allergies.Items[q].Value == dietlist1.allengyies.Split(' ')[a])
                                    {
                                        allergies.Items[q].Selected = true;
                                    }
                                }
                            }
                            wordcount = countword(dietlist1.avoid);
                            for (int b = 0; b < wordcount; b++)
                            {
                                for (int p = 0; p < avoid.Items.Count; p++)
                                {
                                    if (avoid.Items[p].Value == dietlist1.avoid.Split(' ')[b])
                                    {
                                        avoid.Items[p].Selected = true;
                                    }
                                }
                            }
                            mealfrequency.Text = dietlist1.meal.ToString();
                            snackfrequency.Text = dietlist1.snack.ToString();

                            CustomerNutrtionProfileClass medicallist1 = new CustomerNutrtionProfileClass();
                            medicallist1 = (CustomerNutrtionProfileClass)Session["medical"];
                            wordcount = countword(medicallist1.medical);
                            for (int c = 0; c < wordcount; c++)
                            {
                                for (int m = 0; m < CBLMedicalCondition.Items.Count; m++)
                                {
                                    if (CBLMedicalCondition.Items[m].Value == medicallist1.medical.Split(' ')[c])
                                        CBLMedicalCondition.Items[m].Selected = true;
                                }
                            }
                            if (medicallist1.glucose != 0)
                            {
                                glu.Visible = true;
                                unit.Visible = true;
                                glucose.Visible = true;
                                glucose.Text = Math.Round(medicallist1.glucose, 0).ToString();
                            }
                            sub.Text = "Continue";

                        }
                    }


                }
                else
                {
                    sub.Text = "Continue";
                }

            }
        }


        protected void CBLMedicalCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int z = 0; z < CBLMedicalCondition.Items.Count; z++)
            {
                if (CBLMedicalCondition.Items[z].Selected)
                {
                    if (CBLMedicalCondition.Items[z].Value == "Diabetes")
                    {
                        if (CBLMedicalCondition.Items[z].Selected != false)
                        {

                            glu.Visible = true;
                            glucose.Visible = true;
                            unit.Visible = true;
                            number++;
                            CBLMedicalCondition.Items[0].Selected = false;
                        }
                        else
                        {

                            glu.Visible = false;
                            glucose.Visible = false;
                            unit.Visible = false;
                            number = 0;
                        }


                    }
                    if (CBLMedicalCondition.Items[z].Value == "Hypertension")
                    {
                        if (CBLMedicalCondition.Items[z].Selected != false)
                        {
                            bloodpressure.Visible = true;
                            gl.Visible = true;
                            mmHg.Visible = true;
                            numberss++;
                            CBLMedicalCondition.Items[0].Selected = false;
                        }
                        else
                        {
                            bloodpressure.Visible = false;
                            gl.Visible = false;
                            mmHg.Visible = false;
                            numberss = 0;
                        }

                    }
                    if (CBLMedicalCondition.Items[z].Value == "None")
                    {
                        if (number > 0 || numberss > 0)
                        {
                            CBLMedicalCondition.Items[1].Selected = false;
                            CBLMedicalCondition.Items[2].Selected = false;
                            glu.Visible = false;
                            glucose.Visible = false;
                            unit.Visible = false;
                            glucose.Text = string.Empty;
                            bloodpressure.Visible = false;
                            gl.Visible = false;
                            mmHg.Visible = false;
                            bloodpressure.Text = string.Empty;
                            number = 0;
                            numberss = 0;
                        }
                    }
                }
                else
                {
                    if (number > 0 && CBLMedicalCondition.Items[z].Value == "Diabetes")
                    {
                        glu.Visible = false;
                        glucose.Visible = false;
                        unit.Visible = false;
                        number = 0;
                    }
                    else
                    {
                        bloodpressure.Visible = false;
                        gl.Visible = false;
                        mmHg.Visible = false;
                        numberss = 0;
                    }

                }
            }

        }

        protected void sub_Click(object sender, EventArgs e)
        {
            if (sub.Text == "Continue")
            {
                //Get Physical Profile input from customer
                decimal heigh = Decimal.Parse(height.Text);
                decimal weigh = Decimal.Parse(weight.Text);
                string activitylevel = string.Empty;
                decimal activitynum = 0.0M;
                if (sedentary.Checked == true)
                {
                    activitylevel = "Sedentary";
                    activitynum = (decimal)1.2;

                }
                else if (lightly.Checked == true)
                {
                    activitylevel = "Lightly Active";
                    activitynum = (decimal)1.375;

                }
                else if (moderate.Checked == true)
                {
                    activitylevel = "Moderately Active";
                    activitynum = (decimal)1.55;

                }
                else if (veryactive.Checked == true)
                {
                    activitylevel = "Very Active";
                    activitynum = (decimal)1.725;

                }
                else
                {
                    activitylevel = "Extra Active";
                    activitynum = (decimal)1.9;
                }
                //Calculate BMI, weight status, BMR and TDEE
                TastyChefNutritionAssessmentWS.NutritionAssessmentSoapClient ws = new TastyChefNutritionAssessmentWS.NutritionAssessmentSoapClient();
                decimal bmi = ws.CalculateBMI(heigh, weigh);
                string weightstatus = ws.weightstatus(bmi);
                //Retrieve Customer Age and Gender
                string email = Session["email"].ToString();
                CustomerRegistrationClass register = new CustomerRegistrationClass();
                List<CustomerRegistrationClass> list1 = new List<CustomerRegistrationClass>();
                list1 = register.retrieveCustomer(email);
                int age = list1[0].age;
                string gender = list1[0].gender;
                decimal bmr = ws.CalculateBMR(heigh, weigh, age, gender);
                decimal calories = ws.CalculateCalories(bmr, activitynum, weightstatus);


                //Get Dietary input from user
                string diettyp = diettype.SelectedValue;
                string allergy = string.Empty;
                for (int z = 0; z < allergies.Items.Count; z++)
                {
                    if (allergies.Items[z].Selected)
                    {
                        allergy += allergies.Items[z].Value + " ";
                        count++;
                    }
                }
                string avoi = string.Empty;
                for (int w = 0; w < avoid.Items.Count; w++)
                {
                    if (avoid.Items[w].Selected)
                    {
                        avoi += avoid.Items[w].Value + " ";
                    }
                }
                int meal = int.Parse(mealfrequency.Text);
                int snack = int.Parse(snackfrequency.Text);


                //Get Medical Condition input from user
                string medical = string.Empty;
                for (int x = 0; x < CBLMedicalCondition.Items.Count; x++)
                {
                    if (CBLMedicalCondition.Items[x].Selected)
                    {
                        medical += CBLMedicalCondition.Items[x].Value + " ";
                    }
                }
                decimal glucos = 0.0M;
                if (glucose.Text != string.Empty)
                {
                    glucos = Math.Round(Decimal.Parse(glucose.Text), 2);
                }
                if (bloodpressure.Text != string.Empty)
                {
                    string bloodpres = bloodpressure.Text;
                }

                //Assign and Insert nutrition group and macronutrient range
                string levelcarbohydrate = ws.levelCarbohydrate(weightstatus, medical);
                string Proteinrange = ws.CalculateProteinRange(levelcarbohydrate, calories);
                string Carbohydraterange = ws.CalculateCarbohydrateRange(levelcarbohydrate, calories);
                string Fatrange = ws.CalculateFatRange(levelcarbohydrate, calories);
                //int id = matchnutritiongroup(medical, diettyp, allergy);
                CustomerNutrtionProfileClass nutritionprofile = new CustomerNutrtionProfileClass();
                CustomerNutrtionProfileClass nutritionlist = new CustomerNutrtionProfileClass(email, Carbohydraterange, Proteinrange, Fatrange, calories, activitylevel, bmi, bmr, heigh, weigh, weightstatus, levelcarbohydrate);
                Session["nutriton"] = nutritionlist;
                CustomerNutrtionProfileClass dietlist = new CustomerNutrtionProfileClass(diettyp, allergy, avoi, meal, snack, email);
                Session["diet"] = dietlist;
                CustomerNutrtionProfileClass medicallist = new CustomerNutrtionProfileClass(medical, glucos, email);
                Session["medical"] = medicallist;
                //nutritionprofile.createNutritionProfile(email, Carbohydraterange, Proteinrange, Fatrange, calories, activitylevel, bmi, bmr, heigh, weigh, weightstatus, levelcarbohydrate);
                //nutritionprofile.createDietProfile(diettyp, allergy, avoi, meal, snack, email);
                //nutritionprofile.createMedicalProfile(medical, glucos, email);
                Response.Redirect("CustomerNutritionAssessementAfter.aspx");

            }
            else
            {
                load.Visible = true;
                //Check if the customer nutrition profile exist
                string email = Session["email"].ToString();
                CustomerNutrtionProfileClass nutritionprofile = new CustomerNutrtionProfileClass();
                Boolean result = nutritionprofile.checkNutritionProfile(email);

                if (result != false)
                {
                    //Get Physical Profile input from customer
                    decimal heigh = Decimal.Parse(height.Text);
                    decimal weigh = Decimal.Parse(weight.Text);
                    string activitylevel = string.Empty;
                    decimal activitynum = 0.0M;
                    if (sedentary.Checked == true)
                    {
                        activitylevel = "Sedentary";
                        activitynum = (decimal)1.2;

                    }
                    else if (lightly.Checked == true)
                    {
                        activitylevel = "Lightly Active";
                        activitynum = (decimal)1.375;

                    }
                    else if (moderate.Checked == true)
                    {
                        activitylevel = "Moderately Active";
                        activitynum = (decimal)1.55;

                    }
                    else if (veryactive.Checked == true)
                    {
                        activitylevel = "Very Active";
                        activitynum = (decimal)1.725;

                    }
                    else
                    {
                        activitylevel = "Extra Active";
                        activitynum = (decimal)1.9;
                    }
                    //Calculate BMI, weight status, BMR and TDEE
                    TastyChefNutritionAssessmentWS.NutritionAssessmentSoapClient ws = new TastyChefNutritionAssessmentWS.NutritionAssessmentSoapClient();
                    decimal bmi = ws.CalculateBMI(heigh, weigh);
                    string weightstatus = ws.weightstatus(bmi);
                    //Retrieve Customer Age and Gender
                    CustomerRegistrationClass register = new CustomerRegistrationClass();
                    List<CustomerRegistrationClass> list1 = new List<CustomerRegistrationClass>();
                    list1 = register.retrieveCustomer(email);
                    int age = list1[0].age;
                    string gender = list1[0].gender;
                    decimal bmr = ws.CalculateBMR(heigh, weigh, age, gender);
                    decimal calories = ws.CalculateCalories(bmr, activitynum, weightstatus);


                    //Get Dietary input from user
                    string diettyp = diettype.SelectedValue;
                    string allergy = string.Empty;
                    for (int z = 0; z < allergies.Items.Count; z++)
                    {
                        if (allergies.Items[z].Selected)
                        {
                            allergy += allergies.Items[z].Value + " ";
                            count++;
                        }
                    }
                    string avoi = string.Empty;
                    for (int w = 0; w < avoid.Items.Count; w++)
                    {
                        if (avoid.Items[w].Selected)
                        {
                            avoi += avoid.Items[w].Value + " ";
                        }
                    }
                    int meal = int.Parse(mealfrequency.Text);
                    int snack = int.Parse(snackfrequency.Text);


                    //Get Medical Condition input from user
                    string medical = string.Empty;
                    for (int x = 0; x < CBLMedicalCondition.Items.Count; x++)
                    {
                        if (CBLMedicalCondition.Items[x].Selected)
                        {
                            medical += CBLMedicalCondition.Items[x].Value + " ";
                        }
                    }
                    decimal glucos = 0.0M;
                    if (glucose.Text != string.Empty)
                    {
                        glucos = Math.Round(Decimal.Parse(glucose.Text), 2);
                    }
                    if (bloodpressure.Text != string.Empty)
                    {
                        string bloodpres = bloodpressure.Text;
                    }

                    //Assign and Update nutrition group and macronutrient range
                    string levelcarbohydrate = ws.levelCarbohydrate(weightstatus, CBLMedicalCondition.SelectedValue);
                    string Proteinrange = ws.CalculateProteinRange(levelcarbohydrate, calories);
                    string Carbohydraterange = ws.CalculateCarbohydrateRange(levelcarbohydrate, calories);
                    string Fatrange = ws.CalculateFatRange(levelcarbohydrate, calories);
                    //int id = matchnutritiongroup(medical, diettyp, allergy);
                    nutritionprofile.updateNutritionProfile(email, Carbohydraterange, Proteinrange, Fatrange, calories, activitylevel, bmi, bmr, heigh, weigh, weightstatus, levelcarbohydrate);
                    nutritionprofile.updateDietprofile(diettyp, allergy, avoi, meal, snack, email);
                    nutritionprofile.updateMedicalCondition(medical, glucos, email);
                    r = true;
                    Response.AddHeader("REFRESH", "5;URL=CustomerNutritionAssessment1.aspx");
                }



            }
        }

        //private int matchnutritiongroup(string medical, string diet, string allergy)
        //{
        //    int id = 0;
        //    CustomerNutrtionProfileClass nutritionprofile = new CustomerNutrtionProfileClass();
        //    List<CustomerNutrtionProfileClass> Nutritiongrouplist = new List<CustomerNutrtionProfileClass>();
        //    Nutritiongrouplist = nutritionprofile.retrieveNutrition();
        //    string a = medical.Split(' ')[0];
        //    for (int z = 0; z < Nutritiongrouplist.Count; z++)
        //    {
        //        if(Nutritiongrouplist[z].nutritiongroupmedical == medical.Split(' ')[0])
        //        {
        //            if(Nutritiongrouplist[z].nutritiongroupdiettype == diet)
        //            {                                              
        //                if(allergy != "None")
        //                {

        //                    List<CustomerNutrtionProfileClass> NutritionGrouplist2 = new List<CustomerNutrtionProfileClass>();
        //                    NutritionGrouplist2 = nutritionprofile.retrieveNutritionGroupAllergy(Nutritiongrouplist[z].nutritiongroupid);
        //                    Boolean result = false;
        //                    if (NutritionGrouplist2.Count > 0)
        //                    {
        //                        if (NutritionGrouplist2.Count == count)
        //                        {

        //                            for (int w = 0; w < NutritionGrouplist2.Count; w++)
        //                            {

        //                                for (int x = 0; x < count; x++)
        //                                {
        //                                    if (allergy.Split(' ')[x] == NutritionGrouplist2[x].nutritiongroupallergy)
        //                                    {
        //                                        result = true;

        //                                    }else
        //                                    {
        //                                        result = false;
        //                                    }
        //                                }
        //                                if (result == true)
        //                                {
        //                                    id = NutritionGrouplist2[w].nutritiongroupid;
        //                                }
        //                            }

        //                        }
        //                    }

        //                }else
        //                {
        //                    id = Nutritiongrouplist[z].nutritiongroupid;
        //                }
        //            }
        //        }
        //    }
        //    return id;
        //}

        public int countword(string sentence)
        {

            string[] word = sentence.Split(' ');
            int wordCount = word.Count();
            return wordCount;
        }

        protected void allergies_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int a = 0; a < allergies.Items.Count; a++)
            {
                if (allergies.Items[a].Selected)
                {
                    if(allergies.Items[a].Value == "None")
                    {
                        if (allergynum != 0)
                        {
                            for (int b = 1; b < allergies.Items.Count; b++)
                            {
                                allergies.Items[b].Selected = false;
                            }
                            allergynum = 0;
                        }
                       
                    }else
                    {
                        allergies.Items[0].Selected = false;
                        allergynum++;
                    }
                }
            }


            //for (int z = 0; z < allergies.Items.Count; z++)
            //{
            //    if (allergies.Items[z].Selected)
            //    {
            //        if (allergies.Items[z].Value == "Fish")
            //        {
            //            if (allergies.Items[z].Selected != false)
            //            {
            //                allergynum++;
            //                allergies.Items[0].Selected = false;
            //            }
            //            else
            //            {

            //                allergynum = 0;

            //            }


            //        }
            //        if (allergies.Items[z].Value == "ShellFish")
            //        {
            //            if (allergies.Items[z].Selected != false)
            //            {
            //                allergynumss++;
            //                allergies.Items[0].Selected = false;
            //            }
            //            else
            //            {
            //                allergynumss = 0;
            //            }

            //        }
            //        else if (allergies.Items[z].Value == "Peanut")
            //        {
            //            if (allergies.Items[z].Selected != false)
            //            {
            //                allergynumsss++;
            //                allergies.Items[0].Selected = false;
            //            }
            //            else
            //            {
            //                allergynumsss = 0;
            //            }
            //        }
            //        else if (allergies.Items[z].Value == "Tree Nut")
            //        {
            //            if (allergies.Items[z].Selected != false)
            //            {
            //                allergynumssss++;
            //                allergies.Items[0].Selected = false;
            //            }
            //            else
            //            {
            //                allergynumssss = 0;
            //            }
            //        }
            //        if (allergies.Items[z].Value == "None")
            //        {
            //            if (allergynum > 0 || allergynumss > 0 || allergynumsss > 0 || allergynumssss > 0)
            //            {
            //                allergies.Items[1].Selected = false;
            //                allergies.Items[2].Selected = false;
            //                allergies.Items[3].Selected = false;
            //                allergies.Items[4].Selected = false;
            //                allergynum = 0;
            //                allergynumss = 0;
            //                allergynumsss = 0;
            //                allergynumssss = 0;

            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (allergynum > 0 && allergies.Items[z].Value == "Fish")
            //        {

            //            allergynum = 0;

            //        }
            //        else if (allergynumss > 0 && allergies.Items[z].Value == "ShellFish")
            //        {
            //            allergynumss = 0;

            //        }
            //        else if (allergynumsss > 0 && allergies.Items[z].Value == "Peanut")
            //        {
            //            allergynumsss = 0;

            //        }
            //        else if (allergynumssss > 0 && allergies.Items[z].Value == "Tree Nut")
            //        {
            //            allergynumssss = 0;
            //        }

            //    }
            //}
        }

        protected void avoid_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int z = 0; z < avoid.Items.Count; z++)
            {
                if (avoid.Items[z].Selected)
                {
                    if (avoid.Items[z].Value == "Beef")
                    {
                        if (avoid.Items[z].Selected != false)
                        {
                            avoidnum++;
                            avoid.Items[0].Selected = false;
                        }
                        else
                        {

                            avoidnum = 0;

                        }


                    }
                    if (avoid.Items[z].Value == "Cheese")
                    {
                        if (avoid.Items[z].Selected != false)
                        {
                            avoidnumss++;
                            avoid.Items[0].Selected = false;
                        }
                        else
                        {
                            avoidnumss = 0;
                        }

                    }
                    else if (avoid.Items[z].Value == "Mutton")
                    {
                        if (avoid.Items[z].Selected != false)
                        {
                            avoidnumsss++;
                            avoid.Items[0].Selected = false;
                        }
                        else
                        {
                            avoidnumsss = 0;
                        }
                    }
                    else if (avoid.Items[z].Value == "Onion")
                    {
                        if (avoid.Items[z].Selected != false)
                        {
                            avoidnumssss++;
                            avoid.Items[0].Selected = false;
                        }
                        else
                        {
                            avoidnumssss = 0;
                        }
                    }
                    if (avoid.Items[z].Value == "None")
                    {
                        if (avoidnum > 0 || avoidnumss > 0 || avoidnumsss > 0 || avoidnumssss > 0)
                        {
                            avoid.Items[1].Selected = false;
                            avoid.Items[2].Selected = false;
                            avoid.Items[3].Selected = false;
                            avoid.Items[4].Selected = false;
                            otherck.Checked = false;
                            otheravoid.Visible = false;
                            avoidnum = 0;
                            avoidnumss = 0;
                            avoidnumsss = 0;
                            avoidnumssss = 0;
                        }
                    }
                }
                else
                {
                    if (avoidnum > 0 && avoid.Items[z].Value == "Beef")
                    {

                        avoidnum = 0;

                    }
                    else if (avoidnumss > 0 && avoid.Items[z].Value == "Cheese")
                    {
                        avoidnumss = 0;

                    }
                    else if (avoidnumsss > 0 && avoid.Items[z].Value == "Mutton")
                    {
                        avoidnumsss = 0;

                    }
                    else if (avoidnumssss > 0 && avoid.Items[z].Value == "Onion")
                    {
                        avoidnumssss = 0;
                    }

                }
            }
        }

        public void otherck_CheckedChanged(object sender, EventArgs e)
        {
            if (otherck.Checked)
            {
                otheravoid.Visible = true;
                avoid.Items[0].Selected = false;
                avoidnum++;
            }else
            {
                otheravoid.Visible = false;
            }
           
        }
        
        protected void back_click(object sender, EventArgs e)
        {
            if(back.Text == "Back")
            {
                Response.Redirect("CustomerNutritionAssessmentDetails.aspx");
            }
            else
            {
                Response.Redirect("CustomerPersonalDetails1.aspx");
            }
            
        }

        protected void viewrecommend_Clik(object sender, EventArgs e)
        {
            Response.Redirect("CustomerRecipeRecommendation1.aspx");
        }
    }
}