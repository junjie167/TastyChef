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
    public partial class CustomerSummary : System.Web.UI.Page
    {
        PagedDataSource pds = new PagedDataSource();


        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack == false)
            {
                //bind();
                if(Session["email"] != null)
                {
                    string email = Session["email"].ToString();
                    CustomerRegistrationClass register = new CustomerRegistrationClass();
                    List<CustomerRegistrationClass> cuslist = new List<CustomerRegistrationClass>();
                    cuslist = register.retrieveCustomer(email);
                    name.Text = cuslist[0].fname;

                    int number = 0;
                    protein.Text = number+" grams";
                    fat.Text = number + " grams";
                    carbohydrate.Text = number + " grams";
                    carlories.Text = number + " Kcal";
                   

                }
                
                
            }

        }

        

        //public void addcart(object sender, EventArgs e)
        //{
        //    if (Session["email"] != null)
        //    {
        //        Button addcart = (Button)sender;
        //        DataListItem ditem = (DataListItem)(addcart.NamingContainer);
        //        LinkButton recipes = (LinkButton)recommendrecipe.Items[ditem.ItemIndex].FindControl("recipename");
        //        string recipename = recipes.Text;

        //    }
        //}

        //public void recipedetails(object sender, EventArgs e)
        //{
        //    string date = string.Empty;
        //    DateTime todaydatess = DateTime.Today;
        //    date = todaydatess.DayOfWeek.ToString();
        //    Button recipedetails = (Button)sender;
        //    DataListItem ditem = (DataListItem)(recipedetails.NamingContainer);
        //    LinkButton recipes = (LinkButton)recommendrecipe.Items[ditem.ItemIndex].FindControl("recipename");
        //    string recipename = recipes.Text;
        //    List<string> list = new List<string>();
        //    list.Add("Recommended Menu");
        //    list.Add(date);
        //    Session["previous"] = list;
        //    Response.Redirect("CustomerRecipeDetails.aspx?RecipeName=" + recipename);
        //}

        //public void viewall_click(object sender, EventArgs e)
        //{
        //    Response.Redirect("CustomerRecipeRecommendation1.aspx");
        //}

        //public int CurrentPage
        //{
        //    get
        //    {
        //        if (this.ViewState["CurrentPage"] == null)
        //        {
        //            return 0;
        //        }else
        //        {
        //            return int.Parse(this.ViewState["CurrentPage"].ToString());
        //        }
        //    }set
        //    {
        //        this.ViewState["CurrentPage"] = value;
        //    }
        //}

        //protected void previous_click(object sender, EventArgs e)
        //{
        //    CurrentPage -= 1;
        //    bind();
        //}
        //protected void next_click(object sender, EventArgs e)
        //{
        //    CurrentPage += 1;
        //    bind();
        //}

        //protected void bind()
        //{
        //    string email = Session["email"].ToString();
        //    string date = string.Empty;
        //    DateTime todaydatess = DateTime.Today;
        //    date = todaydatess.DayOfWeek.ToString();

        //    CustomerViewRecipe recipe = new CustomerViewRecipe();
        //    List<CustomerViewRecipe> recipelist = new List<CustomerViewRecipe>();
        //    recipelist = recipe.retrieveRecipeByDate(date);
        //    recommendrecipe.DataSource = recipelist;
        //    recommendrecipe.DataBind();
        //    DataTable table = new DataTable();
        //    table.Columns.Add("recipeimage");
        //    table.Columns.Add("recipename");
        //    table.Columns.Add("recipecalories");
        //    table.Columns.Add("recipemedicalcondition");
        //    string url = string.Empty;
        //    string recipename = string.Empty;
        //    string ca = string.Empty;
        //    string con = string.Empty;
        //    for(int a = 0; a < recipelist.Count; a++)
        //    {
        //        url = recipelist[a].recipeimage;
        //        recipename = recipelist[a].recipename;
        //        ca = recipelist[a].recipecalories.ToString();
        //        con = recipelist[a].recipemedicalcondition;
        //        table.Rows.Add(url, recipename, ca, con);
        //    }          
        //    pds.DataSource = table.DefaultView;
        //    pds.AllowPaging = true;
        //    pds.PageSize = 2;
        //    pds.CurrentPageIndex = CurrentPage;
        //    next.Visible = !pds.IsLastPage;
        //    previous.Visible = !pds.IsFirstPage;
        //    recommendrecipe.DataSource = pds;
        //    recommendrecipe.DataBind();
        //}
    }
}