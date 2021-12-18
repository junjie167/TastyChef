using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using TastyChef.DAL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;

namespace TastyChef
{
    public partial class CustomerNutritionProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                string email = Session["email"].ToString();
                //CustomerRegistrationClass register = new CustomerRegistrationClass();
                //List<CustomerRegistrationClass> list = new List<CustomerRegistrationClass>();
                //list = register.retrieveCustomer(email);
                //age.Text = list[0].age.ToString();
                //gender.Text = list[0].gender;
                CustomerNutrtionProfileClass nutritionprofile = new CustomerNutrtionProfileClass();
                List<CustomerNutrtionProfileClass> nutrition = new List<CustomerNutrtionProfileClass>();
                List<CustomerNutrtionProfileClass> dietprofile = new List<CustomerNutrtionProfileClass>();
                List<CustomerNutrtionProfileClass> medicalprofile = new List<CustomerNutrtionProfileClass>();

                ////Display physical and macronutrient profile
                nutrition = nutritionprofile.retrieveNutritionProfile(email);
                for (int z = 0; z < nutrition.Count; z++)
                {
                    //{
                    //    height.Text = Math.Round(nutrition[z].height, 0).ToString();
                    //    weight.Text = Math.Round(nutrition[z].weight, 0).ToString();
                    //    activity.Text = nutrition[z].activitylevel;
                    //    decimal bm = nutrition[z].bmi;
                    //    bmi.Text = bm.ToString();
                    //    if (bm < (decimal)18.5)
                    //    {
                    //        risk.ForeColor = System.Drawing.Color.Red;
                    //        risk.Text = "(Lack of nutrition risk)";

                    //    }
                    //    else if (bm >= (decimal)18.5 && bm < (decimal)23.9)
                    //    {
                    //        risk.ForeColor = System.Drawing.Color.Green;
                    //        risk.Text = "(Low Risk)";

                    //    }
                    //    else if (bm >= (decimal)23.9 && bm < (decimal)27.5)
                    //    {
                    //        risk.ForeColor = System.Drawing.Color.OrangeRed;
                    //        risk.Text = "(Moderate Risk)";

                    //    }
                    //    else
                    //    {
                    //        risk.ForeColor = System.Drawing.Color.Red;
                    //        risk.Text = "(High Risk)";
                    //    }
                    //    weightstatus.Text = nutrition[z].weightstatus;

                    //macronutrient
                    calories.Text = Math.Round(nutrition[z].calories, 0).ToString();
                    protein.Text = nutrition[z].proteinrange;
                    carbohydrate.Text = nutrition[z].carbohydraterange;
                    fats.Text = nutrition[z].fatsrange;


                    //PieChart
                    List<CustomerNutrtionProfileClass> macronutrientpercent = new List<CustomerNutrtionProfileClass>();
                    macronutrientpercent = nutritionprofile.retrievemacronutrient(nutrition[z].levelcarbohydrate);
                    Chart1.Series["ChartArea1"].LegendText = "#VALX";
                    Chart1.Legends["Default"].AutoFitMinFontSize = 50;
                    Chart1.Legends["Default"].MaximumAutoSize = 100;
                    for (int o = 0; o < macronutrientpercent.Count; o++)
                    {
                        Chart1.Series["ChartArea1"].Points.AddXY(macronutrientpercent[o].macronutrient, macronutrientpercent[o].percent);

                    }
                }
            

            ////Display diet profile
            //dietprofile = nutritionprofile.retrieveDietaryProfile(email);
            //int countwords = 0;
            //for (int w = 0; w < dietprofile.Count; w++)
            //{
            //    diettype.Text = dietprofile[w].diettype;
            //    countwords = countword(dietprofile[w].allergy);
            //    int num = 1;
            //    for (int x = 0; x < countwords; x++)
            //    {

            //        allergy.Text += num + ") " + dietprofile[w].allergy.Split(' ')[x] + "<br/>";
            //        num++;
            //    }
            //    countwords = countword(dietprofile[w].avoid);
            //    num = 1;
            //    for (int r = 0; r < countwords; r++)
            //    {
            //        avoid.Text += num + ") " + dietprofile[w].avoid.Split(' ')[r] + "<br/>";
            //        num++;
            //    }
            //    meal.Text = dietprofile[w].meal.ToString();
            //    snack.Text = dietprofile[w].snack.ToString();
            //}

            ////Display medicate profile
            //medicalprofile = nutritionprofile.retrieveMedicateProfile(email);
            //for (int q = 0; q < medicalprofile.Count; q++)
            //{
            //    int number = 1;
            //    countwords = countword(medicalprofile[q].medical);
            //    for (int y = 0; y < countwords; y++)
            //    {
            //        medical.Text += number + ") " + medicalprofile[q].medical.Split(' ')[y] + "<br/>";
            //        number++;
            //    }

            //    if (medicalprofile[q].glucose != 0.0M)
            //    {
            //        glu.Visible = true;
            //        glucose.Visible = true;
            //        glucose.Text = Math.Round(medicalprofile[q].glucose, 0).ToString();
            //    }
            //    else
            //    {
            //        glu.Visible = false;
            //        glucose.Visible = false;
            //    }

            //}

            //List<string> liststring = new List<string>();
            //liststring = advicemethod(risk.Text);
            //int numb = 1;
            //string add = string.Empty;
            //for(int m =0; m < liststring.Count; m++)
            //{
            //    add += numb + ") " + liststring[m]+"<br/>";
            //    numb++;
            //}
            //advice.Text = add;



        }
    

        }

        protected void edit_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerNutritionAssessment.aspx");
        }

        public int countword(string sentence)
        {

            string[] word = sentence.Split(' ');
            int wordCount = word.Count() - 1;
            return wordCount;
        }

        protected void downloadpdf_Click(object sender, EventArgs e)
        {
            string email = Session["email"].ToString();
            CustomerRegistrationClass register = new CustomerRegistrationClass();
            List<CustomerRegistrationClass> list = new List<CustomerRegistrationClass>();
            list = register.retrieveCustomer(email);
            string name = list[0].lname + " " + list[0].fname;
            int age = list[0].age;
            string dob = list[0].dob.ToString("dd/MM/yyyy");
            string gender = list[0].gender;
            string mobile = list[0].mobile;
            string home = list[0].house;
            Chart1.BackColor = System.Drawing.Color.White;
            Chart1.ChartAreas["ChartArea1"].BackColor = System.Drawing.Color.White;
            Chart1.Legends[0].BackColor = System.Drawing.Color.White;

            Document Doc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            PdfWriter.GetInstance(Doc, Response.OutputStream);
            Doc.Open();
            iTextSharp.text.Image addLogo = default(iTextSharp.text.Image);
            addLogo = iTextSharp.text.Image.GetInstance(Server.MapPath("img/TastyChefLogo.png"));
            addLogo.ScalePercent(25f);
            addLogo.Alignment = iTextSharp.text.Image.TEXTWRAP;
            iTextSharp.text.pdf.draw.LineSeparator line1 = new iTextSharp.text.pdf.draw.LineSeparator(0f, 100f, BaseColor.BLACK, Element.ALIGN_LEFT, 1);
            iTextSharp.text.Image addDivider = default(iTextSharp.text.Image);
            addDivider = iTextSharp.text.Image.GetInstance(Server.MapPath("img/divder2.PNG"));
            addDivider.ScalePercent(90f);
            using (MemoryStream memoryStream = new MemoryStream())
            {

                Chart1.SaveImage(memoryStream, ChartImageFormat.Png);
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(memoryStream.GetBuffer());
                img.ScalePercent(20f);
                Font titleFont = FontFactory.GetFont("Arial", 30, Font.BOLD);
                Font contentFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
                Font subtitle = FontFactory.GetFont("Arial", 15, Font.BOLD);
                Font logotext = FontFactory.GetFont("Arial", 20, Font.BOLD);
                subtitle.SetStyle(Font.UNDERLINE);

                Paragraph head = new Paragraph("Nutrition Profile", titleFont);
                head.Alignment = Element.ALIGN_CENTER;

                PdfPTable personal = new PdfPTable(2);
                personal.HorizontalAlignment = 1;
                personal.SpacingBefore = 20f;
                personal.SpacingAfter = 30f;
                personal.DefaultCell.Border = 0;
                personal.SetWidths(new float[] { 1.2f, 3.5f });
                personal.AddCell(new Phrase("Personal Details", subtitle));
                personal.AddCell(" ");
                personal.AddCell("\n");
                personal.AddCell(" ");
                personal.AddCell(new Phrase("Name: ", contentFont));
                personal.AddCell(name);
                personal.AddCell(new Phrase("Age: ", contentFont));
                personal.AddCell(age.ToString());
                personal.AddCell(new Phrase("Date of birth: ", contentFont));
                personal.AddCell(dob);
                personal.AddCell(new Phrase("Gender: ", contentFont));
                personal.AddCell(gender);
                personal.AddCell(new Phrase("Mobile: ", contentFont));
                personal.AddCell(mobile);
                personal.AddCell(new Phrase("Home: ", contentFont));
                personal.AddCell(home);
                personal.AddCell(new Phrase("Email Address: ", contentFont));
                personal.AddCell(email);


                PdfPTable macrotable = new PdfPTable(2);
                macrotable.HorizontalAlignment = 1;
                macrotable.SpacingAfter = 20;
                macrotable.SpacingBefore = 20;
                macrotable.DefaultCell.Border = 0;
                macrotable.DefaultCell.Padding = 4;
                macrotable.SetWidths(new float[] { 1.5f, 3f });
                macrotable.AddCell(new Phrase("Macronutrients", subtitle));
                macrotable.AddCell(" ");
                macrotable.AddCell(new Phrase("\n"));
                macrotable.AddCell(" ");
                macrotable.AddCell(new Phrase("Daily Calories: ", contentFont));
                macrotable.AddCell(calories.Text + " Kcal");
                macrotable.AddCell(new Phrase("Daily Protein: ", contentFont));
                macrotable.AddCell(protein.Text + " Grams");
                macrotable.AddCell(new Phrase("Daily Fats: ", contentFont));
                macrotable.AddCell(fats.Text + " Grams");
                macrotable.AddCell(new Phrase("Daily Carbohydrate: ", contentFont));
                macrotable.AddCell(carbohydrate.Text + " Grams");

                PdfPTable chart = new PdfPTable(1);
                chart.HorizontalAlignment = 1;
                chart.SpacingAfter = 30f;
                chart.SpacingBefore = 20f;
                chart.DefaultCell.Border = 0;
                chart.SetWidths(new float[] { 1f });
                chart.AddCell(new Phrase("Macronutriens Percentage", subtitle));
                chart.AddCell(img);



                Paragraph brea = new Paragraph("\n");
                Paragraph foot = new Paragraph("Thank you for visting Tasty Chef. If you have any question about our product, you can contact us at +65-67894512 or send email to tastychef@gmail.com");
                Doc.Add(addLogo);
                Doc.Add(brea);
                Doc.Add(head);
                Doc.Add(brea);
                Doc.Add(addDivider);
                Doc.Add(personal);
                Doc.Add(brea);
                Doc.Add(macrotable);
                Doc.Add(brea);
                Doc.Add(brea);
                Doc.Add(brea);
                Doc.Add(brea);
                Doc.Add(brea);
                Doc.Add(brea);
                Doc.Add(brea);
                Doc.Add(brea);
                Doc.Add(brea);
                Doc.Add(brea);
                Doc.Add(brea);
                Doc.Add(brea);
                Doc.Add(brea);
                Doc.Add(brea);
                Doc.Add(brea);
                Doc.Add(brea);
                Doc.Add(brea);
                Doc.Add(brea);
                Doc.Add(chart);
                Doc.Add(brea);
                Doc.Add(addDivider);
                Doc.Add(foot);
                Doc.Close();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=TCNutritionProfile.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(Doc);
                Response.End();

            }
        }

    }
}