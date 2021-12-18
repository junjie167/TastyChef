using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TastyChef.DAL;

namespace TastyChef
{
    public partial class AdminInsertRecipeStep1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Step1"] != null )
            {
                Recipe r = new Recipe();

                r = (Recipe)Session["Step1"];
                string recipeName = r.RecipeName.ToString();
               TbRecipeName.Text = recipeName;

                string recipeType = r.Type.ToString();
               DDLType.Text = recipeType;

                string cookingType = r.CookingType.ToString();
                DDLCookingType.Text = cookingType;

                string recipeServes = r.Portion.ToString();
                TbServes.Text = recipeServes;

                string cookingTime = r.CookingTime.ToString();
                TbCookingTime.Text = cookingTime;

                string recipeImage = r.Image.ToString();
                ImgRecipe.ImageUrl = recipeImage;

                string founder = r.RecipeFounder.ToString();
                TbRecipeFounder.Text = founder;
                LblFileName.Visible = true;
                LblFileName.Text = recipeImage;
             
            }
       
        }

        protected void BtnStep1Next_Click(object sender, EventArgs e)
        {
            if (Session["Step1"] != null)
            {
                if (DDLCookingType.Text != "Please Select")
                {
                   
                        string recipeName = TbRecipeName.Text;
                        string type = DDLType.Text;
                        string cookingType = DDLCookingType.Text;
                        int portion = Convert.ToInt32(TbServes.Text);
                        int cookingTime = Convert.ToInt32(TbCookingTime.Text);
                        string founder = TbRecipeFounder.Text;
                    string image = "";
                    if (LblFileName.Text!="")
                    {
                      image = LblFileName.Text;
                    }
                    else
                    {
                        image = "Recipe images/" + FileUploadRecipeImage.FileName;
                    }
                   
                        Recipe step1 = new Recipe(recipeName, image, type, portion, cookingTime, founder, cookingType);
                        Session["Step1"] = step1;
                        Response.Redirect("AdminInsertRecipeStep2.aspx");
                    
                }
            }
            else
            {
                if (DDLCookingType.Text != "Please Select")
                {
                    if (FileUploadRecipeImage.HasFile == true)
                    {
                        string recipeName = TbRecipeName.Text;
                        string type = DDLType.Text;
                        string cookingType = DDLCookingType.Text;
                        int portion = Convert.ToInt32(TbServes.Text);
                        int cookingTime = Convert.ToInt32(TbCookingTime.Text);
                        string founder = TbRecipeFounder.Text;
                        string image = "Recipe images/" + FileUploadRecipeImage.FileName;
                        Recipe step1 = new Recipe(recipeName, image, type, portion, cookingTime, founder, cookingType);
                        Session["Step1"] = step1;
                        Response.Redirect("AdminInsertRecipeStep2.aspx");
                    }
                }
            }
        }

        protected void TbRecipeName_TextChanged(object sender, EventArgs e)
        {
           
            Recipe r = new Recipe();
            int result = 0;
            result = r.checkRecipeName(TbRecipeName.Text);
            if (result > 0)
            {
                LblErrorMessage.Text = "Name Exists";
                TbRecipeName.Text = "";
            }
            else
            {
                LblErrorMessage.Text = "Name Available";
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHomePage.aspx");
        }
    }
}