using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TastyChef.DAL;


namespace TastyChef
{
    public partial class AdminInsertRecipeStep3 : System.Web.UI.Page
    {
        Recipe r = new Recipe();
        List<CookingInstruction> ciList = new List<CookingInstruction>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            
                    r = (Recipe)Session["Step1"];
                    string recipeName = r.RecipeName.ToString();
                    LblRecipeName.Text = recipeName;

                    int sessionStepNumber = 1;
                    List<CookingInstruction> stepNumberList = new List<CookingInstruction>();
                    CookingInstruction stepNumber = new CookingInstruction(sessionStepNumber);
                    stepNumberList.Add(stepNumber);
                    Session["StepNumberList"] = stepNumberList;
                    DDlStep.Items.Add(Convert.ToString(sessionStepNumber));
                
            }
        }

      

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminInsertRecipeStep2.aspx");
        }
    
        protected void DDlStep_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Clear Editor Content
            Editor1.Content = "";
            
            BtnSave.Visible = true;
            BtnUpdate.Visible = false;
            // Retrieve the selected Item "StepNumber"
            int selectedStepNumber = Convert.ToInt32(DDlStep.SelectedItem.Text);
            List<CookingInstruction> stepNumberList = new List<CookingInstruction>();
            stepNumberList = (List<CookingInstruction>)Session["StepNumberList"];
            for (int i = 0; i < stepNumberList.Count; i++)
            {
                int sessionStepNumber = stepNumberList[i].StepNumber;
                if (sessionStepNumber == selectedStepNumber)
                {
                    List<CookingInstruction> cookingInstuctionList = new List<CookingInstruction>();
                    cookingInstuctionList = (List<CookingInstruction>)Session["CookingInstruction"];
                    for (int a = 0; a < cookingInstuctionList.Count; a++)
                    {
                        int cookingInstuctionStepNumber = cookingInstuctionList[a].StepNumber;
                        if (selectedStepNumber == cookingInstuctionStepNumber)
                        {
                            string editorContent = cookingInstuctionList[a].StepInstruction;
                            Editor1.Content = editorContent;
                           
                            if (Editor1.Content != "")
                            {
                                BtnSave.Visible = false;
                                BtnUpdate.Visible = true;
                                BtnStep3Next.Focus();
                            }
                            BtnStep3Next.Focus();
                        }
                        BtnStep3Next.Focus();
                    }
                    BtnStep3Next.Focus();
                }
                BtnStep3Next.Focus();
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            int stepNumber = Convert.ToInt32(DDlStep.SelectedItem.Text);
            string stepInstruction = Editor1.Content;

            //Editor Content is empty?
            if (Editor1.Content != "")
            {
                LblErrorMessage.Visible = false;
                //Check Session is null
                if (Session["CookingInstruction"] != null)
                {

                    //Retrieve and assign session data into arrayList
                    ciList = (List<CookingInstruction>)Session["CookingInstruction"];
                    CookingInstruction ci = new CookingInstruction(stepNumber, stepInstruction);
                    ciList.Add(ci);
                    Session["CookingInstruction"] = ciList;

                    //Clear Editor Content
                    Editor1.Content = "";

                    //Add step+1 = newStep to StepNumberList
                    int sessionStepNumber = stepNumber + 1;

                    //Add and Bind StepNumberList to DDL
                    List<CookingInstruction> stepNumberList = new List<CookingInstruction>();
                    stepNumberList = (List<CookingInstruction>)Session["StepNumberList"];
                    CookingInstruction ci1 = new CookingInstruction(sessionStepNumber);
                    stepNumberList.Add(ci1);
                    Session["StepNumberList"] = stepNumberList;
                    DDlStep.Items.Add(Convert.ToString(sessionStepNumber));

                    //Display the next StepNumber

                    DDlStep.SelectedValue = Convert.ToString(sessionStepNumber);

                    BtnStep3Next.Focus();
                }//Check Session is null

                else
                {
                    //Save newStep and EditorContent into Session
                    List<CookingInstruction> ciList1 = new List<CookingInstruction>();
                    CookingInstruction ci = new CookingInstruction(stepNumber, stepInstruction);
                    ciList1.Add(ci);
                    Session["CookingInstruction"] = ciList1;

                    //Clear Editor Content
                    Editor1.Content = "";

                    //Add step+1 = newStep to StepNumberList
                    int sessionStepNumber = stepNumber + 1;

                    //Add and Bind StepNumberList to DDL
                    List<CookingInstruction> stepNumberList = new List<CookingInstruction>();
                    stepNumberList = (List<CookingInstruction>)Session["StepNumberList"];
                    CookingInstruction ci1 = new CookingInstruction(sessionStepNumber);
                    stepNumberList.Add(ci1);
                    Session["StepNumberList"] = stepNumberList;
                    DDlStep.Items.Add(Convert.ToString(sessionStepNumber));

                    //Display the next StepNumber

                    DDlStep.SelectedValue = Convert.ToString(sessionStepNumber);
                    BtnStep3Next.Focus();
                }
            }//Editor Content is empty?
            else
            {
                LblErrorMessage.Text = "Please enter the cooking intruction";
                LblErrorMessage.Visible = true;
                BtnStep3Next.Focus();
            }

        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            int stepNumber = Convert.ToInt32(DDlStep.SelectedItem.Text);
            string stepInstruction = Editor1.Content;

            List<CookingInstruction> cookingInstuctionList = new List<CookingInstruction>();
            cookingInstuctionList = (List<CookingInstruction>)Session["CookingInstruction"];
            for (int i = 0; i < cookingInstuctionList.Count; i++)
            {
                int sessionStepNumber = cookingInstuctionList[i].StepNumber;
                if (sessionStepNumber == stepNumber)
                {
                    cookingInstuctionList.RemoveAt(i);
                    CookingInstruction ci = new CookingInstruction(stepNumber,stepInstruction);
                    cookingInstuctionList.Add(ci);
                   
                    
                }
            }
            Session["CookingInstruction"] = cookingInstuctionList;
        }

        protected void BtnStep3Next_Click(object sender, EventArgs e)
        {
            Session["Step3"]= Session["CookingInstruction"];
            Response.Redirect("AdminInsertRecipeStep4.aspx");
        }
    }
}