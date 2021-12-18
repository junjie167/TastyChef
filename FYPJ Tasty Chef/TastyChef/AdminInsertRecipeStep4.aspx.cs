using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TastyChef.DAL;

namespace TastyChef
{
    public partial class AdminInsertRecipeStep4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Recipe r = new Recipe();
            if (!IsPostBack)
            {

                if (Session["Step4"] == null)
                    r = (Recipe)Session["Step1"];
                string recipeName = r.RecipeName.ToString();
                LblRecipeName.Text = recipeName;

                Cookware ce = new Cookware();
                List<Cookware> ceList = new List<Cookware>();
                ceList = ce.RetriveAllCooking();
                GVCookingEquipmentSelection.DataSource = ceList;
                GVCookingEquipmentSelection.DataBind();
                LblErrorMessage.Visible = false;

            }
           
        }

        protected void BtnStep2Next_Click(object sender, EventArgs e)
        {

            List<Cookware> cList = new List<Cookware>();
            if (Session["Step4"] != null)
            {

                foreach (GridViewRow row in GVCookingEquipmentSelection.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[2].FindControl("CBSelect") as CheckBox);
                        if (chkRow.Checked)
                        {

                            string name = row.Cells[1].Text;
                            Cookware c = new Cookware(name);
                            cList.Add(c);
                            //Store into Session Step 4
                            Session["Step4"] = cList;
                            Response.Redirect("AdminInsertRecipeConfirmation.aspx");

                        }
                        else
                        {
                            LblErrorMessage.Visible = true;
                            BtnStep2Next.Focus();
                        }
                    }
                }


            }
            else
            {
                foreach (GridViewRow row in GVCookingEquipmentSelection.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[2].FindControl("CBSelect") as CheckBox);
                        if (chkRow.Checked)
                        {

                            string name = row.Cells[1].Text;
                            Cookware c = new Cookware(name);
                            cList.Add(c);
                            //Store into Session Step 4
                            Session["Step4"] = cList;
                            Response.Redirect("AdminInsertRecipeStep5.aspx");

                        }
                        else
                        {
                            LblErrorMessage.Visible = true;
                            BtnStep2Next.Focus();
                        }
                    }
                }

            }

        }
    }
}