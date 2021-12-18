using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TastyChef.DAL;

namespace TastyChef
{
    public partial class CustomerRecipeDetails : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                this.MasterPageFile = "~/CustomerMasterPage.Master";

            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack == false)
            {
                if (Session["email"] != null)
                {
                    back.Attributes["style"] = "margin-top:0px;";
                    he.Attributes["style"] = "margin-top:0px;";
                }

                List<string> list = new List<string>();
                list = (List<string>)Session["previous"];
                back.Text = "< "+ list[0];

                //Get Recipe Name
                string rname = Request.QueryString["RecipeName"].ToString();
                recipename.Text = rname;

                //Get Recipe Information
                CustomerViewRecipe viewrecipe = new CustomerViewRecipe();
                List<CustomerViewRecipe> recipelist = new List<CustomerViewRecipe>();
                recipelist = viewrecipe.retrieveRecipeByName(rname);
                for(int a = 0; a < recipelist.Count; a++)
                {
                    image.ImageUrl = recipelist[a].recipeimage;
                    schedule.Text = recipelist[a].recipeday;
                    mealtype.Text = recipelist[a].recipetype;
                    medical.Text = recipelist[a].recipemedicalcondition;
                    cookingtime.Text = recipelist[a].recipecookingtime.ToString()+" mins";
                    serving.Text = recipelist[a].recipeportion.ToString();
                    cookingtype.Text = recipelist[a].recipecookingtype;
                    founder.Text = recipelist[a].recipefounder;

                    //nutrition facts
                    sodium.Text = recipelist[a].recipesodium.ToString() + " mg";
                    sugar.Text = recipelist[a].recipesugar.ToString()+ " grams";
                    fibre.Text = recipelist[a].recipefibre.ToString() + " grams";
                    cholsterol.Text = recipelist[a].recipecholesterol.ToString() + " mg";
                    satfat.Text = recipelist[a].recipesatfat.ToString() + " grams";
                    tranfat.Text = recipelist[a].recipetransfat.ToString() + " grams";
                    protein.Text = recipelist[a].recipeprotein.ToString() + " grams";
                    fat.Text = recipelist[a].recipetotalfat.ToString() + " grams";
                    carbs.Text = recipelist[a].recipecarbohydrate.ToString() + " grams";
                    calories.Text = recipelist[a].recipecalories.ToString() + " Kcal";
                }

                //Retrieve Recipe ingredient
                Ingredient.DataSource = viewrecipe.retrieveRecipeIngredient(rname);
                Ingredient.DataBind();
                List<CustomerViewRecipe> allergenlist = new List<CustomerViewRecipe>();
                allergenlist = viewrecipe.retrieveRecipeAllergies(rname);
                int num = 0;
                if (allergenlist.Count > 0)
                {
                    for (int b = 0; b < allergenlist.Count; b++)
                    {
                        num++;
                        if(num != allergenlist.Count)
                        {
                            allergy.Text += allergenlist[b].recipeallergy + ", ";
                        }else
                        {
                            allergy.Text += allergenlist[b].recipeallergy;
                        }
                        
                    }

                }else
                {
                    allergy.Text = "None";
                }

                List<CustomerViewRecipe> equipmentlist = new List<CustomerViewRecipe>();
                equipmentlist = viewrecipe.retrieveCookingEquipment(rname);
                int number = 1;
                for(int c = 0; c < equipmentlist.Count; c++)
                {
                    
                        recipeequipment.Text += number+") "+equipmentlist[c].recipeequipment + "<br/> ";
                    number++;
                   
                }

                instructioncontent.DataSource = viewrecipe.retrieveInstruction(rname);
                instructioncontent.DataBind();          

            }
        }

        protected void addcart_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                string rname = recipename.Text;

            }
            else
            {
                System.Web.UI.HtmlControls.HtmlGenericControl logindiv = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("id01");
                logindiv.Style.Add("display", "block");
            }
        }

        protected void back_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            list = (List<string>)Session["previous"];

            if(back.Text == "< Recommended Recipe")
            {
                Response.Redirect("CustomerRecipeRecommendation1.aspx");
            }else
            {
                Response.Redirect("CustomerAllRecipe1.aspx");
            }
        }
    }
}