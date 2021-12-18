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
    public partial class CustomerRecipeRecommendation1 : System.Web.UI.Page
    {
        public static int count = 0;
        PagedDataSource pds = new PagedDataSource();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {

                string date = string.Empty;
                DateTime todaydatess = DateTime.Today;
                date = todaydatess.DayOfWeek.ToString();

                sc.SelectedValue = date;

                string email = Session["email"].ToString();

                //CustomerViewRecipe recipe = new CustomerViewRecipe();
                //RecommendRecipe.DataSource = recipe.retrieveRecommendRecipe(sc.SelectedValue, email);
                //RecommendRecipe.DataBind();
                bind();

            }

        }

       

        public void addcart(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Button addcart = (Button)sender;
                DataListItem ditem = (DataListItem)(addcart.NamingContainer);
                LinkButton recipes = (LinkButton)RecommendRecipe.Items[ditem.ItemIndex].FindControl("recipename");
                string recipename = recipes.Text;

            }
        }

        public void recipe_linkbutton(object sender, EventArgs e)
        {
            LinkButton link = (LinkButton)sender;
            string linktext = link.Text;
            Response.Redirect("CustomerRecipeDetails.aspx?RecipeName=" + linktext);
        }

        public void recipedetails(object sender, EventArgs e)
        {
            Button recipedetails = (Button)sender;
            DataListItem ditem = (DataListItem)(recipedetails.NamingContainer);
            LinkButton recipes = (LinkButton)RecommendRecipe.Items[ditem.ItemIndex].FindControl("recipename");
            string recipename = recipes.Text;
            List<string> list = new List<string>();
            list.Add("Recommended Recipe");
            list.Add(sc.SelectedValue);
            Session["previous"] = list;
            Response.Redirect("CustomerRecipeDetails.aspx?RecipeName=" + recipename);
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
            string email = Session["email"].ToString();
            string date = string.Empty;
            DateTime todaydatess = DateTime.Today;
            date = todaydatess.DayOfWeek.ToString();
            
            CustomerViewRecipe recipe = new CustomerViewRecipe();
            List<CustomerViewRecipe> recipelist = new List<CustomerViewRecipe>();
            recipelist = recipe.retrieveRecommendRecipe(sc.SelectedValue,email);
            RecommendRecipe.DataSource = recipelist;
            RecommendRecipe.DataBind();
            DataTable table = new DataTable();
            table.Columns.Add("recipeimage");
            table.Columns.Add("recipename");
            table.Columns.Add("recipecalories");
            table.Columns.Add("recipemedicalcondition");
            string url = string.Empty;
            string recipename = string.Empty;
            string ca = string.Empty;
            string con = string.Empty;
            for (int a = 0; a < recipelist.Count; a++)
            {
                url = recipelist[a].recipeimage;
                recipename = recipelist[a].recipename;
                ca = recipelist[a].recipecalories.ToString();
                con = recipelist[a].recipemedicalcondition;
                table.Rows.Add(url, recipename, ca, con);
            }
            pds.DataSource = table.DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = 6;
            pds.CurrentPageIndex = CurrentPage;
            next.Visible = !pds.IsLastPage;
            previous.Visible = !pds.IsFirstPage;
            RecommendRecipe.DataSource = pds;
            RecommendRecipe.DataBind();
        }

        public void sched_SelectedIndexChanged(object sender, EventArgs e)
        {
            string email = Session["email"].ToString();
            //CustomerViewRecipe recipe = new CustomerViewRecipe();
            //RecommendRecipe.DataSource = recipe.retrieveRecommendRecipe(sc.SelectedValue, email);
            //RecommendRecipe.DataBind();
            bind();
        }


        //Recommend recipe method
        //public List<CustomerViewRecipe> recommendRecipe(string email, string day)
        //{
        //    CustomerViewRecipe viewrecipe = new CustomerViewRecipe();
        //    CustomerNutrtionProfileClass nutrition = new CustomerNutrtionProfileClass();

        //    List<CustomerViewRecipe> recommendrecipelist = new List<CustomerViewRecipe>();
        //    List<CustomerViewRecipe> recipelist = new List<CustomerViewRecipe>();
        //    List<CustomerNutrtionProfileClass> customermedical = new List<CustomerNutrtionProfileClass>();

        //    recipelist = viewrecipe.retrieveRecipeByDate(day);
        //    customermedical = nutrition.retrieveMedicateProfile(email);

        //    for(int a = 0; a < customermedical.Count; a++)
        //    {
        //        for(int b = 0; b < recipelist.Count; b++)
        //        {
        //            if(customermedical[a].medical == recipelist[b].recipemedicalcondition)
        //            {
        //                CustomerViewRecipe recipe = (CustomerViewRecipe)viewrecipe.retrieveRecipeByName(recipelist[b].recipename);
        //                recommendrecipelist.Add();
        //            }
        //        }
        //    }

        //    return recommendrecipelist;
        //}

        public int countword(string sentence)
        {

            string[] word = sentence.Split(' ');
            int wordCount = word.Count() - 1;
            return wordCount;
        }


    }
}