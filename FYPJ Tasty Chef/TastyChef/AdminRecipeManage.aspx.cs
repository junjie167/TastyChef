using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TastyChef.DAL;

namespace TastyChef
{
    public partial class AdminRecipeManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            mainContent2.Visible = false;
            recordMessage.Visible = false;
            
        }
        private void bind()
        {
            Recipe r = new Recipe();
            List<Recipe> rList = new List<Recipe>();
            rList = r.RetriveAllRecipe();
            DLRecipe.DataSource = rList;
            DLRecipe.DataBind();
            foreach (DataListItem item in DLRecipe.Items)
            {
                //Get RecipeName 

                Label Label7 = (Label)item.Controls[3];
                string recipeName = Label7.Text;
                //Retrieve Method 
                TailoredMadeRecipes tmrMethod = new TailoredMadeRecipes();
                TailoredMadeRecipes tmrList = new TailoredMadeRecipes();
                tmrList = tmrMethod.RetrieveMedicalCondition(recipeName);
                string medicalCondition;

                if (tmrList == null)
                {
                    medicalCondition = "Non-Diabetes";
                }
                else
                {
                    medicalCondition = tmrList.TagsMedicalCondition.ToString();
                }
                //Assign to LblTailorMade
                Label lbl = item.FindControl("LblTailorMade") as Label;
                lbl.Text = medicalCondition;
            }

        }
        private void bindByRecipeName()
        {
            string recipe1Name = TbSearchIngredientName.Text;
            Recipe r = new Recipe();
            Recipe rMethod = new Recipe();
            List<Recipe> rList = new List<Recipe>();
            if (DDLSchedule.SelectedValue == "0" && DDLTailorMade.SelectedValue == "0")
            {
                rList = r.SearchRecipeByName(recipe1Name);
                DLRecipe.DataSource = rList;
                DLRecipe.DataBind();
                if (rList.Count == 0)
                {
                    mainContent2.Visible = false;
                    //No Record Found Message Displayed
                    recordMessage.Visible = true;
                }
                else
                {
                    mainContent2.Visible = true;
                }
            }
            else if (DDLSchedule.SelectedValue == "0" && DDLTailorMade.SelectedValue != "0")
            {
                string tailorMade = DDLTailorMade.SelectedItem.Text;
                // Where medicalCondition and RecipeName
                TailoredMadeRecipes tmrMethod = new TailoredMadeRecipes();
                List<TailoredMadeRecipes> tmrList = new List<TailoredMadeRecipes>();
                tmrList = tmrMethod.RetrieveRecipeNameByMedicalCondition(tailorMade);
                //rList = r.SearchRecipeByName(recipe1Name);
                for (int i = 0; i < tmrList.Count; i++)
                {
                    string rName = tmrList[i].RecipeName.ToString();
                }
            }
            else if (DDLSchedule.SelectedValue != "0" && DDLTailorMade.SelectedValue == "0")
            {
                // Where day and RecipeName
            }
            else if (DDLSchedule.SelectedValue != "0" && DDLTailorMade.SelectedValue != "0")
            {
                //Where medicalCondition and day and RecipeName
            }
            foreach (DataListItem item in DLRecipe.Items)
            {
                //Get RecipeName 

                Label Label7 = (Label)item.Controls[3];
                string recipeName = Label7.Text;
                //Retrieve Method 
                TailoredMadeRecipes tmrMethod = new TailoredMadeRecipes();
                TailoredMadeRecipes tmrList = new TailoredMadeRecipes();
                tmrList = tmrMethod.RetrieveMedicalCondition(recipeName);
                string medicalCondition;

                if (tmrList == null)
                {
                    medicalCondition = "Non-Diabetes";
                    //Assign to LblTailorMade
                    Label lbl = item.FindControl("LblTailorMade") as Label;
                    lbl.Text = medicalCondition;
                    lbl.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    medicalCondition = tmrList.TagsMedicalCondition.ToString();
                    //Assign to LblTailorMade
                    Label lbl = item.FindControl("LblTailorMade") as Label;
                    lbl.Text = medicalCondition;
                }

            }
        }
        private void bindByRecipeSchdule()
        {
            string day = DDLSchedule.SelectedItem.Text;
            Recipe r = new Recipe();
            Recipe rMethod = new Recipe();
            List<Recipe> rList = new List<Recipe>();
            List<Recipe> raList = new List<Recipe>();
            if (DDLTailorMade.SelectedValue == "0" && TbSearchIngredientName.Text == "")
            {
                rList = r.SearchRecipeByDay(day);
                DLRecipe.DataSource = rList;
                DLRecipe.DataBind();
                if (rList.Count == 0)
                {
                    mainContent2.Visible = false;
                    //No Record Found Message Displayed
                    recordMessage.Visible = true;
                }
                else
                {
                    mainContent2.Visible = true;

                }
            }
            else
            {
                if (DDLSchedule.SelectedValue != "0")
                {
                    string tailorMade = DDLTailorMade.SelectedItem.Text;
                    TailoredMadeRecipes tmr = new TailoredMadeRecipes();
                    List<TailoredMadeRecipes> tmrList = new List<TailoredMadeRecipes>();
                    if (TbSearchIngredientName.Text == "")
                    {
                        tmrList = tmr.RetrieveRecipeNameByMedicalCondition(tailorMade);
                        raList = r.SearchRecipeByDay(day);
                        for (int i = 0; i < tmrList.Count; i++)
                        {
                            string recipeName = tmrList[i].RecipeName.ToString();
                            for (int a = 0; a < raList.Count; a++)
                            {
                                string recipeDayName = raList[a].RecipeName.ToString();
                                if (recipeName == recipeDayName)
                                {
                                    r = rMethod.SearchRecipeByDayReturnRecipe(day, recipeName);
                                    rList.Add(r);
                                }
                            }
                        }
                    }
                    else if (TbSearchIngredientName.Text != "")
                    {
                        string sRecipeName = TbSearchIngredientName.Text;
                        rList = r.SearchRecipeByNameAndDayAvailable(sRecipeName, day);
                    }
                    DLRecipe.DataSource = rList;
                    DLRecipe.DataBind();
                    if (rList.Count == 0)
                    {
                        mainContent2.Visible = false;
                        //No Record Found Message Displayed
                        recordMessage.Visible = true;
                    }
                    else
                    {
                        mainContent2.Visible = true;

                    }
                }
                //Validation
            }
            foreach (DataListItem item in DLRecipe.Items)
            {
                //Get RecipeName 

                Label Label7 = (Label)item.Controls[3];
                string recipeName = Label7.Text;
                //Retrieve Method 
                TailoredMadeRecipes tmrMethod = new TailoredMadeRecipes();
                TailoredMadeRecipes tmrList = new TailoredMadeRecipes();
                tmrList = tmrMethod.RetrieveMedicalCondition(recipeName);
                string medicalCondition;

                if (tmrList == null)
                {
                    medicalCondition = "Non-Diabetes";
                    //Assign to LblTailorMade
                    Label lbl = item.FindControl("LblTailorMade") as Label;
                    lbl.Text = medicalCondition;
                    lbl.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    medicalCondition = tmrList.TagsMedicalCondition.ToString();
                    //Assign to LblTailorMade
                    Label lbl = item.FindControl("LblTailorMade") as Label;
                    lbl.Text = medicalCondition;

                }

            }
        }
        //private void bindByRecipeType()
        //{
        //    string type = DDLCuisineType.SelectedItem.Text;
        //    Recipe r = new Recipe();
        //    List<Recipe> rList = new List<Recipe>();
        //    rList = r.SearchRecipeByType(type);
        //    DLRecipe.DataSource = rList;
        //    DLRecipe.DataBind();
        //    foreach (DataListItem item in DLRecipe.Items)
        //    {
        //        Get RecipeName

        //        Label Label7 = (Label)item.Controls[3];
        //        string recipeName = Label7.Text;
        //        Retrieve Method
        //        TailoredMadeRecipes tmrMethod = new TailoredMadeRecipes();
        //        TailoredMadeRecipes tmrList = new TailoredMadeRecipes();
        //        tmrList = tmrMethod.RetrieveMedicalCondition(recipeName);
        //        string medicalCondition;

        //        if (tmrList == null)
        //        {
        //            medicalCondition = "None";
        //        }
        //        else
        //        {
        //            medicalCondition = tmrList.TagsMedicalCondition.ToString();
        //        }
        //        Assign to LblTailorMade
        //        Label lbl = item.FindControl("LblTailorMade") as Label;
        //        lbl.Text = medicalCondition;
        //    }
        //}
        private void bindByRecipeTailorMade()
        {
            List<Recipe> rList = new List<Recipe>();
            List<Recipe> rList1 = new List<Recipe>();
            Recipe r = new Recipe();
            Recipe rMethod = new Recipe();
            List<Recipe> raList = new List<Recipe>();
            string tailorMade = DDLTailorMade.SelectedItem.Text;
            TailoredMadeRecipes tmr = new TailoredMadeRecipes();
            List<TailoredMadeRecipes> tmrList = new List<TailoredMadeRecipes>();
            if (DDLSchedule.SelectedValue == "0" && TbSearchIngredientName.Text == "")
            {
                tmrList = tmr.RetrieveRecipeNameByMedicalCondition(tailorMade);
                for (int i = 0; i < tmrList.Count; i++)
                {
                    string recipeName = tmrList[i].RecipeName.ToString();
                    r = rMethod.SearchRecipe(recipeName);
                    rList.Add(r);
                }
                DLRecipe.DataSource = rList;
                DLRecipe.DataBind();
                if (rList.Count == 0)
                {
                    mainContent2.Visible = false;
                    //No Record Found Message Displayed
                    recordMessage.Visible = true;
                }
                else
                {
                    mainContent2.Visible = true;

                }
            }
            else if (DDLSchedule.SelectedValue != "0" && TbSearchIngredientName.Text == "")
            {
                string day = DDLSchedule.SelectedItem.Text;
                tmrList = tmr.RetrieveRecipeNameByMedicalCondition(tailorMade);
                raList = r.SearchRecipeByDay(day);
                for (int i = 0; i < tmrList.Count; i++)
                {
                    string recipeName = tmrList[i].RecipeName.ToString();
                    for (int a = 0; a < raList.Count; a++)
                    {
                        string recipeDayName = raList[a].RecipeName.ToString();
                        if (recipeName == recipeDayName)
                        {
                            r = rMethod.SearchRecipeByDayReturnRecipe(day, recipeName);
                            rList.Add(r);
                        }
                    }

                }
                DLRecipe.DataSource = rList;
                DLRecipe.DataBind();
                if (rList.Count == 0)
                {
                    mainContent2.Visible = false;
                    //No Record Found Message Displayed
                    recordMessage.Visible = true;
                }
                else
                {
                    mainContent2.Visible = true;

                }
            }
            else if (DDLSchedule.SelectedValue == "0" && TbSearchIngredientName.Text != "")
            {
                string mc = DDLTailorMade.SelectedItem.Text;
                string sRecipeName = TbSearchIngredientName.Text;
                tmrList = tmr.RetrieveRecipeNameByMedicalCondition(mc);

                rList1 = r.SearchRecipeByName(sRecipeName);
                for (int i=0; i<tmrList.Count; i++)
                {
                    string dbMCRecipeName = tmrList[i].RecipeName.ToString();
                    for (int a=0; a < rList1.Count; a++)
                    {
                        string name = rList1[a].RecipeName.ToString();
                        if (name == dbMCRecipeName)
                        {
                            rList.Add(rList1[a]);
                        }
                    }
                }
                DLRecipe.DataSource = rList;
                DLRecipe.DataBind();
                if (rList.Count == 0)
                {
                    mainContent2.Visible = false;
                    //No Record Found Message Displayed
                    recordMessage.Visible = true;
                }
                else
                {
                    mainContent2.Visible = true;

                }
            }
            else if(DDLSchedule.SelectedValue != "0" && TbSearchIngredientName.Text != "")
            {
                string mc = DDLTailorMade.SelectedItem.Text;
                string sRecipeName = TbSearchIngredientName.Text;
                string day = DDLSchedule.SelectedItem.Text;
             
                tmrList = tmr.RetrieveRecipeNameByMedicalCondition(mc);

                rList1 = r.SearchRecipeByName(sRecipeName);
                for (int i = 0; i < tmrList.Count; i++)
                {
                    string dbMCRecipeName = tmrList[i].RecipeName.ToString();
                    for (int a = 0; a < rList1.Count; a++)
                    {
                        string name = rList1[a].RecipeName.ToString();
                        if (name == dbMCRecipeName)
                        {
                            rList.Add(rList1[a]);
                        }
                    }
                  
                }
                for (int o = 0; o < rList.Count; o++)
                {
                    string recipeDayName = rList[o].RecipeName.ToString();

                    r = rMethod.SearchRecipeByDayReturnRecipe(day, recipeDayName);
                    if (r == null)
                    {

                    }
                    else
                    {
                        raList.Add(r);
                    }
                }
                DLRecipe.DataSource = raList;
                DLRecipe.DataBind();
                if (raList.Count == 0)
                {
                    mainContent2.Visible = false;
                    //No Record Found Message Displayed
                    recordMessage.Visible = true;
                }
                else
                {
                    mainContent2.Visible = true;

                }

            }
            foreach (DataListItem item in DLRecipe.Items)
            {
                //Get RecipeName 

                Label Label7 = (Label)item.Controls[3];
                string recipeName = Label7.Text;
                //Retrieve Method 
                TailoredMadeRecipes tmrMethod = new TailoredMadeRecipes();
                TailoredMadeRecipes tmrList1 = new TailoredMadeRecipes();
                tmrList1 = tmrMethod.RetrieveMedicalCondition(recipeName);
                string medicalCondition;

                if (tmrList1 == null)
                {
                    medicalCondition = "Non-Diabetes";
                    //Assign to LblTailorMade
                    Label lbl = item.FindControl("LblTailorMade") as Label;
                    lbl.Text = medicalCondition;
                    lbl.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    medicalCondition = tmrList1.TagsMedicalCondition.ToString();
                    //Assign to LblTailorMade
                    Label lbl = item.FindControl("LblTailorMade") as Label;
                    lbl.Text = medicalCondition;
                }

            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {


            bindByRecipeName();
        }

        protected void DDLSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {

            bindByRecipeSchdule();
        }



        protected void DDLTailorMade_SelectedIndexChanged(object sender, EventArgs e)
        {


            bindByRecipeTailorMade();
        }

        protected void BtnViewDetails_Click(object sender, EventArgs e)
        {
            Button item = (Button)sender;
            DataListItem dlItem = (DataListItem)(item.NamingContainer);
            Label Label7 = (Label)DLRecipe.Items[dlItem.ItemIndex].Controls[3];

            string recipeName = Label7.Text;
            Response.Redirect("AdminRecipeDetials.aspx?RecipeName=" + recipeName);
        }
    }
}