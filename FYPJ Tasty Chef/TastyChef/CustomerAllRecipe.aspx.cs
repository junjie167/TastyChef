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
    public partial class CustomerAllRecipe : System.Web.UI.Page
    {
        public static int count = 0;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if(Session["email"] != null)
            {
                this.MasterPageFile = "~/CustomerMasterPage.Master";
                
            }
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                filter.Visible = false;

                if (Session["email"] != null)
                {
                    he.Attributes["style"] = "margin-top:0px;";
                }

                string date = string.Empty;
                DateTime todaydatess = DateTime.Today;
                date = todaydatess.DayOfWeek.ToString();

                sc.SelectedValue = date;
                  
                        //count--;
                        //DateTime todaydates = DateTime.Today;
                        //DateTime previousdate = todaydates.AddDays(-count);
                        //date = previousdate.DayOfWeek.ToString();

                CustomerViewRecipe recipe = new CustomerViewRecipe();
                Recipe.DataSource = recipe.retrieveRecipeByDate(sc.SelectedValue);
                Recipe.DataBind();

            }
        }

        public void addcart(object sender, EventArgs e)
        {
            if(Session["email"] != null)
            {
                Button addcart = (Button)sender;
                DataListItem ditem = (DataListItem)(addcart.NamingContainer);
                LinkButton recipes = (LinkButton)Recipe.Items[ditem.ItemIndex].FindControl("recipename");
                string recipename = recipes.Text;

            }
            else
            {
                System.Web.UI.HtmlControls.HtmlGenericControl logindiv = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("id01");
                logindiv.Style.Add("display", "block");
            }
        }

        public void recipedetails(object sender, EventArgs e)
        {
            Button recipedetails = (Button)sender;
            DataListItem ditem = (DataListItem)(recipedetails.NamingContainer);
            LinkButton recipes = (LinkButton)Recipe.Items[ditem.ItemIndex].FindControl("recipename");
            string recipename = recipes.Text;
            List<string> list = new List<string>();
            list.Add("Menu");
            list.Add(sc.SelectedValue);
            Session["previous"] = list;
            Response.Redirect("CustomerRecipeDetails.aspx?RecipeName="+recipename);
        }

        public void recipe_linkbutton(object sender, EventArgs e)
        {
            LinkButton link = (LinkButton)sender;
            string linktext = link.Text;
            Response.Redirect("CustomerRecipeDetails.aspx?RecipeName=" + linktext);
        }

        public void filter_click(object sender, EventArgs e)
        {
            filter.Visible = true;
        }

        public void sched_SelectedIndexChanged(object sender, EventArgs e)
        {

            CustomerViewRecipe recipe = new CustomerViewRecipe();
            Recipe.DataSource = recipe.retrieveRecipeByDate(sc.SelectedValue);
            Recipe.DataBind();
        }

        public void sc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}