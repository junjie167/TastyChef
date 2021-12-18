using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using TastyChef.DAL;

namespace TastyChef
{
    public partial class AdminInsertRecipeStep2 : System.Web.UI.Page
    {
       
        Ingredients i = new Ingredients();
        Recipe r = new Recipe();
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                //Retrieve Recipe Name using session method from the Step 1
                r = (Recipe)Session["Step1"];
                string recipeName = r.RecipeName.ToString();
                LblRecipeName.Text = recipeName;
                LblClick.Text = "Enter the Name or Select the category to search for ingredients";
                LblClick.Visible = true;
                Lblingredient.Visible = false;

                BtnStep2Next.Text = "Proceed to Step 3";
                if (Session["Step2"] != null)
                {
                    List<ListOfIngredients> loiList = new List<ListOfIngredients>();
                    loiList = (List<ListOfIngredients>)Session["Step2"];
                    GVSelectedIngredient.DataSource = loiList;
                    GVSelectedIngredient.DataBind();
                    BtnStep2Next.Focus();
                    BtnStep2Next.Text = "Return To Confirmation";
                }
                if (Session["IngredientName&Quantity"] != null)
                {
                    List<ListOfIngredients> save2 = new List<ListOfIngredients>();
                    save2 = (List<ListOfIngredients>)Session["IngredientName&Quantity"];
                    //foreach (var name in (List<ListOfIngredients>)Session["IngredientName&Quantity"])
                    //{

                    //    string ingredientName1 = name.ToString();


                    //    iList.Add(i.RetriveOneIngredientsDetailsByName(ingredientName1));


                    //}//ForEach

                    GVSelectedIngredient.DataSource = save2;
                    GVSelectedIngredient.DataBind();
                }
          
            }
        }

        protected void BtnStep1Next_Click(object sender, EventArgs e)
        {
            string a = "a";
            if (Session["Step2"] != null)
            {
                List<ListOfIngredients> step2List = new List<ListOfIngredients>();
                foreach (GridViewRow gr in GVSelectedIngredient.Rows)
                {
                    string ingredientName = gr.Cells[2].Text;
                    string measurement = gr.Cells[1].Text;
                    TextBox tb = gr.Cells[0].FindControl("TbIngredientQty") as TextBox;
                    int quantity = Convert.ToInt32(tb.Text);

                    r = (Recipe)Session["Step1"];
                    string recipeName = r.RecipeName.ToString();

                    ListOfIngredients loi = new ListOfIngredients(recipeName, quantity, ingredientName, measurement);
                    step2List.Add(loi);

                }//Foreach
                Session["Step2"] = step2List;

                Response.Redirect("AdminInsertRecipeConfirmation.aspx");
            }
            else
            {
                List<ListOfIngredients> step2List = new List<ListOfIngredients>();
                foreach (GridViewRow gr in GVSelectedIngredient.Rows)
                {
                    string ingredientName = gr.Cells[2].Text;
                    string measurement = gr.Cells[1].Text;
                    TextBox tb = gr.Cells[0].FindControl("TbIngredientQty") as TextBox;
                    int quantity = Convert.ToInt32(tb.Text);

                    r = (Recipe)Session["Step1"];
                    string recipeName = r.RecipeName.ToString();

                    ListOfIngredients loi = new ListOfIngredients(recipeName, quantity, ingredientName, measurement);
                    step2List.Add(loi);

                }//Foreach
                Session["Step2"] = step2List;

                Response.Redirect("AdminInsertRecipeStep3.aspx");
            }
        }

        protected void BtnAddNewIngredients_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminIngredientInsertPage.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminInsertRecipeStep1.aspx");

        }
 

        protected void BtnFindIngredients_Click(object sender, EventArgs e)
        {
            LblNoRecordFound.Visible = false;
            string ingredientName = TbSearchIngredientName.Text;
            string ingredientCategory = DDlIngredientsCategory.SelectedItem.Text;

            List<Ingredients> iList = new List<Ingredients>();

            //If both Textbox and Drop Down List is selected 
            if (TbSearchIngredientName.Text != "" && DDlIngredientsCategory.SelectedItem.Text != "Please Select")
            {
                iList = i.SearchIngredients(ingredientName, ingredientCategory);
                if (iList.Count > 0)
                {

                    GVIngredientSelection.DataSource = iList;
                    GVIngredientSelection.DataBind();
                    BtnContinue.Visible = false;
                   
                    LblNoRecordFound.Visible = false;
                    LblClick.Visible = false;
                    LblClick2.Visible = false;
                    LBAddNewIngredient.Visible = false;

                    TbSearchIngredientName.Text = "";
                    DDlIngredientsCategory.SelectedValue = "0";


                }
                else
                {
                    GVIngredientSelection.DataSource = null;
                    GVIngredientSelection.DataBind();
                    LblNoRecordFound.Visible = true;
                    
                    LblClick.ForeColor = System.Drawing.Color.Black;
                    LblClick.Text = "Click ";
                    LblClick.Visible = true;
                 
                    LBAddNewIngredient.Visible = true;
                    BtnContinue.Visible = true;
                    TbSearchIngredientName.ReadOnly = true;
                    DDlIngredientsCategory.EnableViewState = true;
                    BtnFindIngredients.Enabled = false;

                }
            }
            else if (TbSearchIngredientName.Text != "")
            {
                iList = i.SearchIngredientsNameOnly(ingredientName);
                if (iList.Count > 0)
                {

                    GVIngredientSelection.DataSource = iList;
                    GVIngredientSelection.DataBind();
                    BtnContinue.Visible = false;

                   

                    LblNoRecordFound.Visible = false;
                    LblClick.Visible = false;
                    LblClick2.Visible = false;
                    LBAddNewIngredient.Visible = false;

                    TbSearchIngredientName.Text = "";
                    DDlIngredientsCategory.SelectedValue = "0";


                }
                else
                {
                    GVIngredientSelection.DataSource = null;
                    GVIngredientSelection.DataBind();
                    LblNoRecordFound.Visible = true;
                    LblClick.Text = "Click ";
                    LblClick.Visible = true;
                    
                    LBAddNewIngredient.Visible = true;
                    BtnContinue.Visible = true;
                    TbSearchIngredientName.ReadOnly = true;
                    DDlIngredientsCategory.EnableViewState = true;
                    BtnFindIngredients.Enabled = false;

                }
            }
       
            
        }


        protected void GVIngredientSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GVIngredientSelection.SelectedRow;
            string ingredientName = row.Cells[1].Text;
            TextBox tb = row.Cells[2].FindControl("TbIngredientQty") as TextBox;
            if (tb.Text == "")
            {
                Response.Write("<script language=javascript>alert('Enter the amount needed');</script>");
            }
            else
            {
                int quantity = Convert.ToInt32(tb.Text);
                Label lnl = row.Cells[2].FindControl("LblMeasurement") as Label;
                string measurement = lnl.Text;

                //Save ingredientName into session
                if (Session["IngredientName&Quantity"] != null)
                {

                    List<ListOfIngredients> save1 = new List<ListOfIngredients>();
                    save1 = (List<ListOfIngredients>)Session["IngredientName&Quantity"];
                    ListOfIngredients details = new ListOfIngredients(quantity, ingredientName, measurement);
                    save1.Add(details);


                    GVIngredientSelection.DataSource = null;
                    GVIngredientSelection.DataBind();
                    LblNoRecordFound.ForeColor = System.Drawing.Color.Black;
                    LblNoRecordFound.Text = "Successfully added ";
                    LblNoRecordFound.Visible = true;



                    LblClick.Text = ingredientName;
                    Lblingredient.Visible = true;

                    LblClick.Visible = true;



                    BtnContinue.Visible = true;

                    LblClick2.Visible = false;
                    LBAddNewIngredient.Visible = false;
                    TbSearchIngredientName.ReadOnly = true;
                    DDlIngredientsCategory.EnableViewState = true;
                    BtnFindIngredients.Enabled = false;


                    List<ListOfIngredients> save2 = new List<ListOfIngredients>();
                    save2 = (List<ListOfIngredients>)Session["IngredientName&Quantity"];

                    GVSelectedIngredient.DataSource = save2;
                    GVSelectedIngredient.DataBind();

                }
                else
                {
                    //Save current ingredientName and quantity into Session

                    List<ListOfIngredients> save1 = new List<ListOfIngredients>();
                    ListOfIngredients details = new ListOfIngredients(quantity, ingredientName, measurement);
                    save1.Add(details);
                    Session["IngredientName&Quantity"] = save1;


                    GVIngredientSelection.DataSource = null;
                    GVIngredientSelection.DataBind();

                    LblNoRecordFound.ForeColor = System.Drawing.Color.Black;
                    LblNoRecordFound.Text = "Successfully added ";
                    LblNoRecordFound.Visible = true;
                    LblClick.Text = ingredientName;
                    LblClick.Visible = true;
                    BtnContinue.Visible = true;
                    Lblingredient.Visible = true;
                    List<ListOfIngredients> save2 = new List<ListOfIngredients>();
                    save2 = (List<ListOfIngredients>)Session["IngredientName&Quantity"];
                    //foreach (var name in (List<ListOfIngredients>)Session["IngredientName&Quantity"])
                    //{

                    //    string ingredientName1 = name.ToString();


                    //    iList.Add(i.RetriveOneIngredientsDetailsByName(ingredientName1));


                    //}//ForEach

                    GVSelectedIngredient.DataSource = save2;
                    GVSelectedIngredient.DataBind();


                }
            }
            

          
            TbSearchIngredientName.ReadOnly = true;
            DDlIngredientsCategory.EnableViewState = true;
            BtnFindIngredients.Enabled = false;
        }

        protected void BtnContinue_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminInsertRecipeStep2.aspx");
        }

        protected void LBAddNewIngredient_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminIngredientInsertPage.aspx");
        }

     

        protected void GVSelectedIngredient_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            GridViewRow row = GVSelectedIngredient.SelectedRow;
            string GVingredientName = row.Cells[2].Text;
      
            List<ListOfIngredients> save1 = new List<ListOfIngredients>();
            save1 = (List<ListOfIngredients>)Session["IngredientName&Quantity"];
            for (int i = 0; i < save1.Count; i++)
            {
               string ingredientName = save1[i].IngredientName;
                int quantity = Convert.ToInt32(save1[i].Quantity);
                string measurement = save1[i].Measurement;


                if (GVingredientName == ingredientName)
                {

                    save1.Remove(save1[i]);
                  
                }
                //else

                //{


                //    ListOfIngredients details = new ListOfIngredients(quantity, ingredientName, measurement);
                //    save1.Add(details);


                //}
                Session["IngredientName&Quantity"] = save1;
            }
            //List<Ingredients> iList = new List<Ingredients>();
            //foreach (var name in (ArrayList)Session["IngredientName&Quantity"])
            //{

            //    string ingredientName1 = name.ToString();

            //    iList.Add(i.RetriveOneIngredientsDetailsByName(ingredientName1));


            //}//ForEach
            List<ListOfIngredients> iList = new List<ListOfIngredients>();
            iList = (List<ListOfIngredients>)Session["IngredientName&Quantity"];
            GVSelectedIngredient.DataSource = iList;
            GVSelectedIngredient.DataBind();
            BtnStep2Next.Focus();
        }
    }
}