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
    public partial class CustomerAllRecipe1 : System.Web.UI.Page
    {
        public static int count = 0;
        PagedDataSource pds = new PagedDataSource();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                this.MasterPageFile = "~/CustomerMasterPage.Master";

            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {

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
                bind();
            }
            
        }

        public int CurrentPage
        {
            get
            {
                if (this.ViewState["CurrentPage"] == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(this.ViewState["CurrentPage"].ToString());
                }
            }
            set
            {
                this.ViewState["CurrentPage"] = value;
            }
        }

        protected void previous_click(object sender, EventArgs e)
        {
            CurrentPage -= 1;
            bind();
        }
        protected void next_click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            bind();
        }

        protected void bind()
        {
            string date = string.Empty;
            DateTime todaydatess = DateTime.Today;
            date = todaydatess.DayOfWeek.ToString();

            CustomerViewRecipe recipe = new CustomerViewRecipe();
            List<CustomerViewRecipe> recipelist = new List<CustomerViewRecipe>();
            recipelist = recipe.retrieveRecipeByDate(sc.SelectedValue);
            //Recipe.DataSource = recipelist;
            //Recipe.DataBind();
            DataTable table = new DataTable();
            table.Columns.Add("recipeimage");
            table.Columns.Add("recipename");
            string url = string.Empty;
            string recipename = string.Empty;
            string ca = string.Empty;
            string con = string.Empty;
            for (int a = 0; a < recipelist.Count; a++)
            {
                url = recipelist[a].recipeimage;
                recipename = recipelist[a].recipename;
                table.Rows.Add(url, recipename);
            }
            pds.DataSource = table.DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = 6;
            pds.CurrentPageIndex = CurrentPage;
            nexts.Visible = !pds.IsLastPage;
            previouss.Visible = !pds.IsFirstPage;
            //next.Visible = !pds.IsLastPage;
            //previous.Visible = !pds.IsFirstPage;
            Recipe.DataSource = pds;
            Recipe.DataBind();
        }

        public void addcart(object sender, EventArgs e)
        {
            if (Session["email"] != null)
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
            list.Add("All Recipe");
            list.Add(sc.SelectedValue);
            Session["previous"] = list;
            Response.Redirect("CustomerRecipeDetails.aspx?RecipeName=" + recipename);
        }

        public void recipe_linkbutton(object sender, EventArgs e)
        {
            LinkButton link = (LinkButton)sender;
            string linktext = link.Text;
            Response.Redirect("CustomerRecipeDetails.aspx?RecipeName=" + linktext);
        }


        public void sched_SelectedIndexChanged(object sender, EventArgs e)
        {

            //CustomerViewRecipe recipe = new CustomerViewRecipe();
            //Recipe.DataSource = recipe.retrieveRecipeByDate(sc.SelectedValue);
            //Recipe.DataBind();
            bind();
        }

        public void sc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}