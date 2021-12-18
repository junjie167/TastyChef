using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TastyChef.DAL;

namespace TastyChef
{
    public partial class AdminInsertRecipeConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Basic Details
                Recipe r = new Recipe();

                r = (Recipe)Session["Step1"];
                string recipeName = r.RecipeName.ToString();
                LblRecipeName.Text = recipeName;

                string recipeType = r.Type.ToString();
                LblRecipeType.Text = recipeType;

                string cookingType = r.CookingType.ToString();
                LblCookingType.Text = cookingType;

                string recipeServes = r.Portion.ToString();
                LblServes.Text = recipeServes;

                string cookingTime = r.CookingTime.ToString();
                LblDuration.Text = cookingTime;

                string recipeImage = r.Image.ToString();
                ImgRecipe.ImageUrl = recipeImage;

                string founder = r.RecipeFounder.ToString();
                LblFounder.Text = founder;

                //List of Ingredients and its  Nutrition Facts
                List<ListOfIngredients> loiList = new List<ListOfIngredients>();
                loiList = (List<ListOfIngredients>)Session["Step2"];
                GVSelectedIngredient.DataSource = loiList;
                GVSelectedIngredient.DataBind();

                //Nutrition Facts
                decimal newCarbohydrates = 0;
                decimal newProteins = 0;
                decimal newSugar = 0;
                decimal newDietaryFiber = 0;
                decimal newTransFat = 0;
                decimal newSaturatedFat = 0;
                decimal newTotalFat = 0;
                decimal newSodium = 0;
                decimal newCholesterol = 0;
                decimal newCalories = 0;
                Ingredients i = new Ingredients();
                foreach (GridViewRow row in GVSelectedIngredient.Rows)
                {
                    //Get Ingredient Name
                    string ingredientName = GVSelectedIngredient.DataKeys[row.RowIndex].Value.ToString();

                    //get quantity 
                    int qty = Convert.ToInt32(row.Cells[0].Text);
                    //get measurement
                    string measurement = row.Cells[1].Text;
                    Ingredients details = new Ingredients();
                    details = i.RetriveOneIngredientsDetailsByName(ingredientName);

                    newCarbohydrates += Convert.ToDecimal(details.Carbohydrates.ToString()) * qty;
                    newProteins += Convert.ToDecimal(details.Proteins.ToString()) * qty;
                    newSugar += Convert.ToDecimal(details.Sugar.ToString()) * qty;
                    newDietaryFiber += Convert.ToDecimal(details.DietaryFiber.ToString()) * qty;
                    newTransFat += Convert.ToDecimal(details.TransFat.ToString()) * qty;
                    newSaturatedFat += Convert.ToDecimal(details.SaturatedFat.ToString()) * qty;
                    newTotalFat += Convert.ToDecimal(details.TotalFat.ToString()) * qty;
                    newSodium += Convert.ToDecimal(details.Sodium.ToString()) * qty;
                    newCholesterol += Convert.ToDecimal(details.Cholesterol.ToString()) * qty;
                    newCalories += Convert.ToDecimal(details.Calories.ToString()) * qty;
                }
                LblCarbohydrates.Text = Convert.ToString(newCarbohydrates) ;
                LblProteins.Text = Convert.ToString(newProteins) ;
                LblSugar.Text = Convert.ToString(newSugar) ;
                LblDietaryFiber.Text = Convert.ToString(newDietaryFiber);
                LblTransFat.Text = Convert.ToString(newTransFat) ;
                LblSaturatedFat.Text = Convert.ToString(newSaturatedFat);
                LblTotalFat.Text = Convert.ToString(newTotalFat);
                LblSodium.Text = Convert.ToString(newSodium) ;
                LblCholesterol.Text = Convert.ToString(newCholesterol);
                LblTotalCalories.Text = Convert.ToString(newCalories) ;

                //Cooking Instruction 
                List<CookingInstruction> ciList = new List<CookingInstruction>();
                ciList = (List<CookingInstruction>)Session["CookingInstruction"];
                //DLCookingInstruction.DataSource = ciList;
                //DLCookingInstruction.DataBind();
                GVCookingInstruction.DataSource = ciList;
                GVCookingInstruction.DataBind();

                //Cookware 
                List<Cookware> cList = new List<Cookware>();
                cList = (List<Cookware>)Session["Step4"];
                GVCookingEquipmentSelection.DataSource = cList;
                GVCookingEquipmentSelection.DataBind();

                //Assignments 
                //FoodAllergens
                List<FoodAllergens> faList = new List<FoodAllergens>();
                faList = (List<FoodAllergens>)Session["FoodAllergens"];
                GVAllergens.DataSource = faList;
                GVAllergens.DataBind();
                int num = 0;
                if (faList.Count > 0)
                {
                    for (int b = 0; b < faList.Count; b++)
                    {
                        num++;
                        if (num != faList.Count)
                        {
                            LblAllergen.Text += faList[b].FoodAllergyName + ", ";
                        }
                        else
                        {
                            LblAllergen.Text += faList[b].FoodAllergyName;
                        }

                    }

                }
                else
                {
                    LblAllergen.Text = "None";
                }

                //MedicalCondition
                List<TailoredMadeRecipes> tmrList = new List<TailoredMadeRecipes>();
                tmrList = (List<TailoredMadeRecipes>)Session["MedicalCondition"];
                GVMedicalCondition.DataSource = tmrList;
                GVMedicalCondition.DataBind();
                int num1 = 0;
                if (tmrList.Count > 0)
                {
                    for (int b = 0; b < tmrList.Count; b++)
                    {
                        num1++;
                        if (num1 != tmrList.Count)
                        {
                            LblMedicalCondition.Text += tmrList[b].TagsMedicalCondition + ", ";
                        }
                        else
                        {
                            LblMedicalCondition.Text += tmrList[b].TagsMedicalCondition;
                        }

                    }

                }
                else
                {
                    LblMedicalCondition.Text = "None";
                }

                //RecipeDay 
                string recipeDay = (string)Session["RecipeDay"];
                LblSchedule.Text = recipeDay;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminInsertRecipeStep2.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminInsertRecipeStep3.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminInsertRecipeStep4.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminInsertRecipeStep5.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminInsertRecipeStep5.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminInsertRecipeStep1.aspx");
        }

        protected void BtnStep1Next_Click(object sender, EventArgs e)
        {
            //Insert into Recipe Table
            Recipe r = new Recipe();

            r = (Recipe)Session["Step1"];
            string recipeName = r.RecipeName.ToString();


            string recipeType = r.Type.ToString();


            string cookingType = r.CookingType.ToString();


            string recipeServes = r.Portion.ToString();
            int portion = Convert.ToInt32(recipeServes);


            string cookingTime = r.CookingTime.ToString();
            int CTime = Convert.ToInt32(cookingTime);

            string recipeImage = r.Image.ToString();


            string founder = r.RecipeFounder.ToString();
            decimal newCarbohydrates = 0;
            decimal newProteins = 0;
            decimal newSugar = 0;
            decimal newDietaryFiber = 0;
            decimal newTransFat = 0;
            decimal newSaturatedFat = 0;
            decimal newTotalFat = 0;
            decimal newSodium = 0;
            decimal newCholesterol = 0;
            decimal newCalories = 0;
            Ingredients q = new Ingredients();
            foreach (GridViewRow row in GVSelectedIngredient.Rows)
            {
                //Get Ingredient Name
                string ingredientName = GVSelectedIngredient.DataKeys[row.RowIndex].Value.ToString();

                //get quantity 
                int qty = Convert.ToInt32(row.Cells[0].Text);
                //get measurement
                string measurement = row.Cells[1].Text;
                Ingredients details = new Ingredients();
                details = q.RetriveOneIngredientsDetailsByName(ingredientName);

                newCarbohydrates += Convert.ToDecimal(details.Carbohydrates.ToString()) * qty;
                newProteins += Convert.ToDecimal(details.Proteins.ToString()) * qty;
                newSugar += Convert.ToDecimal(details.Sugar.ToString()) * qty;
                newDietaryFiber += Convert.ToDecimal(details.DietaryFiber.ToString()) * qty;
                newTransFat += Convert.ToDecimal(details.TransFat.ToString()) * qty;
                newSaturatedFat += Convert.ToDecimal(details.SaturatedFat.ToString()) * qty;
                newTotalFat += Convert.ToDecimal(details.TotalFat.ToString()) * qty;
                newSodium += Convert.ToDecimal(details.Sodium.ToString()) * qty;
                newCholesterol += Convert.ToDecimal(details.Cholesterol.ToString()) * qty;
                newCalories += Convert.ToDecimal(details.Calories.ToString()) * qty;
            }

           
            string day = LblSchedule.Text;
            string caloriesType = "No Type";
            if (newCalories > 150 && newCalories <= 400)
            {
                caloriesType = "Low";
            }
            else if (newCalories > 400 && newCalories <= 600)
            {
                caloriesType = "Medium";
            }
            else if (newCalories > 600 && newCalories <= 800)
            {
                caloriesType = "MediumHigh";
            }
            else if (newCalories > 800 && newCalories <= 1000)
            {
                caloriesType = "High";
            }
            
            //Insert Statement
            Recipe rMethod = new Recipe();
            int result = 0;
            result = rMethod.InsertRecipe(recipeName, recipeImage, recipeType, portion, CTime, cookingType, founder, newCalories, newCalories, newSugar, newDietaryFiber, newCholesterol, newCarbohydrates, newProteins, newSaturatedFat, newTransFat, newTotalFat, day, caloriesType);

            //Insert into Recipe_CookingEquipments Table
            foreach (GridViewRow row in GVCookingEquipmentSelection.Rows)
            {
                //Get cookwareName
                string cookwareName = row.Cells[0].Text;
                //Insert Statement
                Cookware cMethod = new Cookware();
                int result1 = 0;
                result1 = cMethod.InsertCookware(recipeName, cookwareName);
            }

            //Insert into Recipe_CookingInstruction Table
            List<CookingInstruction> ciList = new List<CookingInstruction>();
            ciList = (List<CookingInstruction>)Session["CookingInstruction"];
            for (int i = 0; i < ciList.Count; i++)
            {
                //string 
                int stepNumber = ciList[i].StepNumber;
                string stepInstruction = ciList[i].StepInstruction;
                //recipeName
                //Insert Statement
                CookingInstruction ciMethod = new CookingInstruction();
                int result2 = 0;
                result2 = ciMethod.InsertCookingInstruction(recipeName, stepNumber, stepInstruction);
            }
            //Insert into Recipe_FoodAllergens Table
            foreach (GridViewRow row in GVAllergens.Rows)
            {
                //Get cookwareName
                string allergensName = row.Cells[0].Text;
                //Insert Statement
                FoodAllergens faMethod = new FoodAllergens();
                   int result3= faMethod.InsertFoodAllergens(recipeName, allergensName);
            }
            //Insert into Recipe_MedicalCondition Table
            foreach(GridViewRow row in GVMedicalCondition.Rows)
            {
                string medicalCondition = row.Cells[0].Text;
                //Insert Statement
                TailoredMadeRecipes tmpMethod = new TailoredMadeRecipes();
                int result4 = tmpMethod.InsertRecipe_MedicalCondition(recipeName, medicalCondition);

            }

            //Insert into List of Ingredient Table
            foreach(GridViewRow row in GVSelectedIngredient.Rows)
            {
                int quantity = Convert.ToInt32(row.Cells[0].Text);
                string measurement = row.Cells[1].Text;
                string ingredientName = row.Cells[2].Text;
                ListOfIngredients loiMethod = new ListOfIngredients();
                int result5 = loiMethod.InsertListofIngredients(recipeName, quantity, ingredientName, measurement);
            }
            Session.Clear();
            Response.Redirect("AdminRecipeManage.aspx");
        }
    }
}