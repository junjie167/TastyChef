using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Configuration;

namespace TastyChef.DAL
{
    public class CustomerViewRecipe
    {
        //Recipe
        public string recipename { get; set; }
        public string recipeimage { get; set; }
        public string recipetype { get; set; }
        public int recipeportion { get; set; }
        public int recipecookingtime { get; set; }
        public string recipecookingtype { get; set; }
        public string recipefounder { get; set; }
        public decimal recipecalories { get; set; }
        public decimal recipesodium { get; set; }
        public decimal recipesugar { get; set; }
        public decimal recipefibre { get; set; }
        public decimal recipecholesterol { get; set; }
        public decimal recipecarbohydrate { get; set; }
        public decimal recipeprotein { get; set; }
        public decimal recipesatfat { get; set; }
        public decimal recipetransfat { get; set; }
        public decimal recipetotalfat { get; set; }
        public string recipeday { get; set; }
        public string recipecaloriestype { get; set; }

        //Recipe Cooking equipment
        public string recipeequipment { get; set;}

        //Recipe Cooking Instruction
        public int recipesteps { get; set; }
        public string recipeinstruction { get; set; }

        //Recipe Medical Condition
        public string recipemedicalcondition { get; set; }

        //Recipe food allergy
        public string recipeallergy { get; set; }

        //Recipe Ingredient
        public int ingretientquantity { get; set; }
        public string ingredientname { get; set; }
        public string ingredientmeasurement { get; set; }
        public string ingredientimage { get; set; }


        public CustomerViewRecipe()
        {

        }

        public CustomerViewRecipe(string name, string image, string type, int portion, int time, string cooktype, string founder, decimal calories, decimal soduim, decimal sugar, decimal fibre, decimal cholesterol, decimal carbohydrate, decimal protein, decimal satfat, decimal tranfat, decimal totalfat, string day)
        {
            this.recipename = name;
            this.recipeimage = image;
            this.recipetype = type;
            this.recipeportion = portion;
            this.recipecookingtime = time;
            this.recipecookingtype = cooktype;
            this.recipefounder = founder;
            this.recipecalories = calories;
            this.recipesodium = soduim;
            this.recipesugar = sugar;
            this.recipefibre = fibre;
            this.recipecholesterol = cholesterol;
            this.recipeprotein = protein;
            this.recipesatfat = satfat;
            this.recipetransfat = tranfat;
            this.recipetotalfat = totalfat;
            this.recipeday = day;
        }

        public CustomerViewRecipe(string name, string image, string type, int portion, int time, string cooktype, string founder, decimal calories, decimal soduim, decimal sugar, decimal fibre, decimal cholesterol, decimal carbohydrate, decimal protein, decimal satfat, decimal tranfat, decimal totalfat)
        {
            this.recipename = name;
            this.recipeimage = image;
            this.recipetype = type;
            this.recipeportion = portion;
            this.recipecookingtime = time;
            this.recipecookingtype = cooktype;
            this.recipefounder = founder;
            this.recipecalories = calories;
            this.recipesodium = soduim;
            this.recipesugar = sugar;
            this.recipefibre = fibre;
            this.recipecholesterol = cholesterol;
            this.recipeprotein = protein;
            this.recipesatfat = satfat;
            this.recipetransfat = tranfat;
            this.recipetotalfat = totalfat;
        }



        //Retrieve Recipe By Day
        public List<CustomerViewRecipe> retrieveRecipeByDate(string day)
        {

            List<CustomerViewRecipe> list = new List<CustomerViewRecipe>();
            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;

            DataTable tdTable = new DataTable();
            DataSet ds = new DataSet();

            StringBuilder sqlcom = new StringBuilder();
            sqlcom.AppendLine("SELECT * FROM Recipe");
            sqlcom.AppendLine("WHERE Day = @paraday");


            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlDataAdapter da;
                da = new SqlDataAdapter(sqlcom.ToString(), myConn);
                da.SelectCommand.Parameters.AddWithValue("@paraday", day);



                da.Fill(ds, "tdTable");

                int rec_cnt = ds.Tables["tdTable"].Rows.Count;
                int num = rec_cnt;
                if (num > 0)
                {
                    for (int z = 0; z < num; z++)
                    {
                        DataRow row = ds.Tables["tdTable"].Rows[z];
                        CustomerViewRecipe recipe = new CustomerViewRecipe();
                        recipe.recipename = row["RecipeName"].ToString();
                        recipe.recipemedicalcondition = retrieveRecipeMedicalCondition(recipe.recipename);
                        recipe.recipeimage = row["Image"].ToString();
                        recipe.recipetype = row["Type"].ToString();
                        recipe.recipeportion = int.Parse(row["Portion"].ToString());
                        recipe.recipecookingtime = int.Parse(row["CookingTime"].ToString());
                        recipe.recipecookingtype = row["CookingType"].ToString();
                        recipe.recipefounder = row["RecipeFounder"].ToString();
                        recipe.recipecalories = Decimal.Parse(row["TotalCalories"].ToString());
                        recipe.recipesodium = Decimal.Parse(row["TotalSodium"].ToString());
                        recipe.recipesugar = Decimal.Parse(row["TotalSugar"].ToString());
                        recipe.recipefibre = Decimal.Parse(row["TotalDietaryFibre"].ToString());
                        recipe.recipecholesterol = Decimal.Parse(row["TotalCholesterol"].ToString());
                        recipe.recipecarbohydrate = Decimal.Parse(row["TotalCarbohydrates"].ToString());
                        recipe.recipeprotein = Decimal.Parse(row["TotalProteins"].ToString());
                        recipe.recipesatfat = Decimal.Parse(row["TotalSaturatedFat"].ToString());
                        recipe.recipetransfat = Decimal.Parse(row["TotalTransFat"].ToString());
                        recipe.recipetotalfat = Decimal.Parse(row["TotalFat"].ToString());
                        recipe.recipecaloriestype = row["CaloriesType"].ToString();



                        list.Add(recipe);
                    }
                }
            }
            catch (Exception e)
            {
                list = null;
            }
            return list;
        }

        //Retrieve Recipe by Recipe Name
        public List<CustomerViewRecipe> retrieveRecipeByName(string name)
        {
            List<CustomerViewRecipe> list = new List<CustomerViewRecipe>();
            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;

            DataTable tdTable = new DataTable();
            DataSet ds = new DataSet();

            StringBuilder sqlcom = new StringBuilder();
            sqlcom.AppendLine("SELECT * FROM Recipe");
            sqlcom.AppendLine("WHERE RecipeName = @paraname");


            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlDataAdapter da;
                da = new SqlDataAdapter(sqlcom.ToString(), myConn);
                da.SelectCommand.Parameters.AddWithValue("@paraname", name);



                da.Fill(ds, "tdTable");

                int rec_cnt = ds.Tables["tdTable"].Rows.Count;
                int num = rec_cnt;
                if (num > 0)
                {
                    for (int z = 0; z < num; z++)
                    {
                        DataRow row = ds.Tables["tdTable"].Rows[z];
                        CustomerViewRecipe recipe = new CustomerViewRecipe();
                        recipe.recipemedicalcondition = retrieveRecipeMedicalCondition(name);
                        recipe.recipeimage = row["Image"].ToString();
                        recipe.recipetype = row["Type"].ToString();
                        recipe.recipeportion = int.Parse(row["Portion"].ToString());
                        recipe.recipecookingtime = int.Parse(row["CookingTime"].ToString());
                        recipe.recipecookingtype = row["CookingType"].ToString();
                        recipe.recipefounder = row["RecipeFounder"].ToString();
                        recipe.recipecalories = Decimal.Parse(row["TotalCalories"].ToString());
                        recipe.recipesodium = Decimal.Parse(row["TotalSodium"].ToString());
                        recipe.recipesugar = Decimal.Parse(row["TotalSugar"].ToString());
                        recipe.recipefibre = Decimal.Parse(row["TotalDietaryFibre"].ToString());
                        recipe.recipecholesterol = Decimal.Parse(row["TotalCholesterol"].ToString());
                        recipe.recipecarbohydrate = Decimal.Parse(row["TotalCarbohydrates"].ToString());
                        recipe.recipeprotein = Decimal.Parse(row["TotalProteins"].ToString());
                        recipe.recipesatfat = Decimal.Parse(row["TotalSaturatedFat"].ToString());
                        recipe.recipetransfat = Decimal.Parse(row["TotalTransFat"].ToString());
                        recipe.recipetotalfat = Decimal.Parse(row["TotalFat"].ToString());
                        recipe.recipeday = row["Day"].ToString();

                        list.Add(recipe);
                    }
                }
            }
            catch (Exception e)
            {
                list = null;
            }
            return list;
        }

        //Method to retrieve recipe medical condition
        public string retrieveRecipeMedicalCondition(string name)
        {

            string medical = string.Empty;
            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;

            DataTable tdTable = new DataTable();
            DataSet ds = new DataSet();

            StringBuilder sqlcom = new StringBuilder();
            sqlcom.AppendLine("SELECT * FROM Recipe_MedicalCondition WHERE RecipeName=@paraname");


            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlDataAdapter da;
                da = new SqlDataAdapter(sqlcom.ToString(), myConn);
                da.SelectCommand.Parameters.AddWithValue("@paraname", name);



                da.Fill(ds, "tdTable");

                int rec_cnt = ds.Tables["tdTable"].Rows.Count;
                int num = rec_cnt;
                if (num > 0)
                {
                    for (int z = 0; z < num; z++)
                    {
                        DataRow row = ds.Tables["tdTable"].Rows[z];
                        medical = row["MedicalCondition"].ToString();
                    }
                }else
                {
                    medical = "Non-Diabetes";
                }
            }
            catch (Exception e)
            {
                medical = null;
            }
            return medical;
        }

        //Retrieve recipe cooking equipment
        public List<CustomerViewRecipe> retrieveCookingEquipment(string name)
        {
            List<CustomerViewRecipe> list = new List<CustomerViewRecipe>();
            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;

            DataTable tdTable = new DataTable();
            DataSet ds = new DataSet();

            StringBuilder sqlcom = new StringBuilder();
            sqlcom.AppendLine("SELECT * FROM Recipe_CookingEquipments");
            sqlcom.AppendLine("WHERE RecipeName = @paraname");


            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlDataAdapter da;
                da = new SqlDataAdapter(sqlcom.ToString(), myConn);
                da.SelectCommand.Parameters.AddWithValue("@paraname", name);



                da.Fill(ds, "tdTable");

                int rec_cnt = ds.Tables["tdTable"].Rows.Count;
                int num = rec_cnt;
                if (num > 0)
                {
                    for (int z = 0; z < num; z++)
                    {
                        DataRow row = ds.Tables["tdTable"].Rows[z];
                        CustomerViewRecipe recipe = new CustomerViewRecipe();
                        recipe.recipeequipment = row["EquipmentName"].ToString();
                       
                        list.Add(recipe);
                    }
                }
            }
            catch (Exception e)
            {
                list = null;
            }
            return list;
        }

        //Retrieve recipe cooking instruction
        public List<CustomerViewRecipe> retrieveInstruction(string name)
        {
            List<CustomerViewRecipe> list = new List<CustomerViewRecipe>();
            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;

            DataTable tdTable = new DataTable();
            DataSet ds = new DataSet();

            StringBuilder sqlcom = new StringBuilder();
            sqlcom.AppendLine("SELECT * FROM Recipe_CookingInstruction");
            sqlcom.AppendLine("WHERE RecipeName = @paraname");


            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlDataAdapter da;
                da = new SqlDataAdapter(sqlcom.ToString(), myConn);
                da.SelectCommand.Parameters.AddWithValue("@paraname", name);



                da.Fill(ds, "tdTable");

                int rec_cnt = ds.Tables["tdTable"].Rows.Count;
                int num = rec_cnt;
                if (num > 0)
                {
                    for (int z = 0; z < num; z++)
                    {
                        DataRow row = ds.Tables["tdTable"].Rows[z];
                        CustomerViewRecipe recipe = new CustomerViewRecipe();
                        recipe.recipesteps = int.Parse(row["CookingStep"].ToString());
                        //recipe.recipeinstruction = instruction(row["CookingInstruction"].ToString());
                        recipe.recipeinstruction = row["CookingInstruction"].ToString();

                        list.Add(recipe);
                    }
                }
            }
            catch (Exception e)
            {
                list = null;
            }
            return list;
        }

        //Retrieve recipe food allergens
        public List<CustomerViewRecipe> retrieveRecipeAllergies(string name)
        {
            List<CustomerViewRecipe> list = new List<CustomerViewRecipe>();
            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;

            DataTable tdTable = new DataTable();
            DataSet ds = new DataSet();

            StringBuilder sqlcom = new StringBuilder();
            sqlcom.AppendLine("SELECT * FROM Recipe_FoodAllergens");
            sqlcom.AppendLine("WHERE RecipeName = @paraname");


            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlDataAdapter da;
                da = new SqlDataAdapter(sqlcom.ToString(), myConn);
                da.SelectCommand.Parameters.AddWithValue("@paraname", name);



                da.Fill(ds, "tdTable");

                int rec_cnt = ds.Tables["tdTable"].Rows.Count;
                int num = rec_cnt;
                if (num > 0)
                {
                    for (int z = 0; z < num; z++)
                    {
                        DataRow row = ds.Tables["tdTable"].Rows[z];
                        CustomerViewRecipe recipe = new CustomerViewRecipe();
                        recipe.recipeallergy = row["FoodAllergyName"].ToString();

                        list.Add(recipe);
                    }
                }
            }
            catch (Exception e)
            {
                list = null;
            }
            return list;
        }

        //Retrieve recipe ingredient
        public List<CustomerViewRecipe> retrieveRecipeIngredient(string name)
        {
            List<CustomerViewRecipe> list = new List<CustomerViewRecipe>();
            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;

            DataTable tdTable = new DataTable();
            DataSet ds = new DataSet();

            StringBuilder sqlcom = new StringBuilder();
            sqlcom.AppendLine("SELECT * FROM ListOfIngredients");
            sqlcom.AppendLine("WHERE RecipeName = @paraname");


            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlDataAdapter da;
                da = new SqlDataAdapter(sqlcom.ToString(), myConn);
                da.SelectCommand.Parameters.AddWithValue("@paraname", name);



                da.Fill(ds, "tdTable");

                int rec_cnt = ds.Tables["tdTable"].Rows.Count;
                int num = rec_cnt;
                if (num > 0)
                {
                    for (int z = 0; z < num; z++)
                    {
                        DataRow row = ds.Tables["tdTable"].Rows[z];
                        CustomerViewRecipe recipe = new CustomerViewRecipe();
                        recipe.ingretientquantity = int.Parse(row["Quantity"].ToString());
                        recipe.ingredientname = row["IngredientName"].ToString();
                        recipe.ingredientimage = retrieveingredientimage(recipe.ingredientname);
                        recipe.ingredientmeasurement = row["Measurement"].ToString();

                        list.Add(recipe);
                    }
                }
            }
            catch (Exception e)
            {
                list = null;
            }
            return list;
        }

        //Method retrieve ingredient image
        public string retrieveingredientimage(string name)
        {
            string image = string.Empty;
            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;

            DataTable tdTable = new DataTable();
            DataSet ds = new DataSet();

            StringBuilder sqlcom = new StringBuilder();
            sqlcom.AppendLine("SELECT * FROM Ingredients WHERE IngredientName=@paraname");


            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlDataAdapter da;
                da = new SqlDataAdapter(sqlcom.ToString(), myConn);
                da.SelectCommand.Parameters.AddWithValue("@paraname", name);



                da.Fill(ds, "tdTable");

                int rec_cnt = ds.Tables["tdTable"].Rows.Count;
                int num = rec_cnt;
                if (num > 0)
                {
                    for (int z = 0; z < num; z++)
                    {
                        DataRow row = ds.Tables["tdTable"].Rows[z];
                        image = row["Image"].ToString();
                    }
                }
               
            }
            catch (Exception e)
            {
                image = null;
            }
            return image;
        }

        //Recommed Recipe
        public List<CustomerViewRecipe> retrieveRecommendRecipe(string day ,string email)
        {
            List<CustomerViewRecipe> list = new List<CustomerViewRecipe>();
            CustomerViewRecipe viewrecipe = new CustomerViewRecipe();
            CustomerNutrtionProfileClass nutrition = new CustomerNutrtionProfileClass();

            List<CustomerViewRecipe> recommendrecipelist = new List<CustomerViewRecipe>();
            List<CustomerViewRecipe> recipelist = new List<CustomerViewRecipe>();
            List<CustomerViewRecipe> recipeallergylist = new List<CustomerViewRecipe>();
            List<CustomerViewRecipe> ingredientlist = new List<CustomerViewRecipe>();
            List<CustomerNutrtionProfileClass> customermedical = new List<CustomerNutrtionProfileClass>();
            List<CustomerNutrtionProfileClass> customerdietlist = new List<CustomerNutrtionProfileClass>();
            List<CustomerNutrtionProfileClass> customernutritionlist = new List<CustomerNutrtionProfileClass>();

            recipelist = viewrecipe.retrieveRecipeByDate(day);
            customermedical = nutrition.retrieveMedicateProfile(email);
            
            int countwords = 0;
            int countavoidance = 0;
            customerdietlist = nutrition.retrieveDietaryProfile(email);
            customernutritionlist = nutrition.retrieveNutritionProfile(email);

            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;

            DataTable tdTable = new DataTable();
            DataSet ds = new DataSet();

            for(int a = 0; a < customermedical.Count; a++)
            {
               
                decimal customercalories = customernutritionlist[a].calories;
                int frequencymeal = customerdietlist[a].meal;
                decimal caloriesneeded = customercalories / frequencymeal;


                for (int b = 0; b < recipelist.Count; b++)
                {
                    Boolean allergy = false;
                    Boolean avoidance = false;

                    if (customermedical[a].medical.Split(' ')[a] == recipelist[b].recipemedicalcondition)
                    {
                        for(int c = 0; c < customerdietlist.Count; c++)
                        {
                            recipeallergylist = viewrecipe.retrieveRecipeAllergies(recipelist[b].recipename);
                            countwords = countword(customerdietlist[c].allergy);
                            for(int d = 0; d < countwords; d++)
                            {
                                for (int e = 0; e < recipeallergylist.Count; e++)
                                {
                                    if (customerdietlist[c].allergy.Split(' ')[d] == recipeallergylist[e].recipeallergy)
                                    {
                                        allergy = true;
                                    }
                                }
                            }
                        }
                        if(allergy == false)
                        {
                            for (int f = 0; f < customerdietlist.Count; f++)
                            {
                                ingredientlist = viewrecipe.retrieveRecipeIngredient(recipelist[b].recipename);
                                countavoidance = countword(customerdietlist[f].avoid);
                                for (int g = 0; g < countavoidance; g++)
                                {
                                    for (int h = 0; h < ingredientlist.Count; h++)
                                    {
                                        if (customerdietlist[f].avoid.Split(' ')[g] == ingredientlist[h].ingredientname)
                                        {
                                            avoidance = true;
                                        }
                                    }

                                }
                            }
                            if(avoidance != true)
                            {

                                string type =  caloriesType(Math.Round(caloriesneeded,0));

                                if(type == recipelist[b].recipecaloriestype)
                                {
                                    StringBuilder sqlcom = new StringBuilder();
                                    sqlcom.AppendLine("SELECT * FROM Recipe");
                                    //sqlcom.AppendLine("INNER JOIN Recipe_MedicalCondition ON Recipe.RecipeName = Recipe_MedicalCondition.RecipeName");
                                    sqlcom.AppendLine("WHERE Recipe.Day = @paraday");


                                    try
                                    {
                                        SqlConnection myConn = new SqlConnection(DBConnect);
                                        SqlDataAdapter da;
                                        da = new SqlDataAdapter(sqlcom.ToString(), myConn);
                                        da.SelectCommand.Parameters.AddWithValue("@paraday", day);



                                        da.Fill(ds, "tdTable");

                                        int rec_cnt = ds.Tables["tdTable"].Rows.Count;
                                        int num = rec_cnt;
                                        if (num > 0)
                                        {

                                            DataRow row = ds.Tables["tdTable"].Rows[b];
                                            CustomerViewRecipe recipe = new CustomerViewRecipe();
                                            recipe.recipename = row["RecipeName"].ToString();
                                            recipe.recipemedicalcondition = retrieveRecipeMedicalCondition(recipe.recipename);
                                            recipe.recipeimage = row["Image"].ToString();
                                            recipe.recipetype = row["Type"].ToString();
                                            recipe.recipeportion = int.Parse(row["Portion"].ToString());
                                            recipe.recipecookingtime = int.Parse(row["CookingTime"].ToString());
                                            recipe.recipecookingtype = row["CookingType"].ToString();
                                            recipe.recipefounder = row["RecipeFounder"].ToString();
                                            recipe.recipecalories = Decimal.Parse(row["TotalCalories"].ToString());
                                            recipe.recipesodium = Decimal.Parse(row["TotalSodium"].ToString());
                                            recipe.recipesugar = Decimal.Parse(row["TotalSugar"].ToString());
                                            recipe.recipefibre = Decimal.Parse(row["TotalDietaryFibre"].ToString());
                                            recipe.recipecholesterol = Decimal.Parse(row["TotalCholesterol"].ToString());
                                            recipe.recipecarbohydrate = Decimal.Parse(row["TotalCarbohydrates"].ToString());
                                            recipe.recipeprotein = Decimal.Parse(row["TotalProteins"].ToString());
                                            recipe.recipesatfat = Decimal.Parse(row["TotalSaturatedFat"].ToString());
                                            recipe.recipetransfat = Decimal.Parse(row["TotalTransFat"].ToString());
                                            recipe.recipetotalfat = Decimal.Parse(row["TotalFat"].ToString());



                                            list.Add(recipe);
                                        }

                                    }
                                    catch (Exception e)
                                    {
                                        list = null;
                                    }
                                }
 
                            }
                        }
                    }else
                    {
                        if(customermedical[a].medical.Split(' ')[a] == "None")
                        {
                            for (int i = 0; i < customerdietlist.Count; i++)
                            {
                                recipeallergylist = viewrecipe.retrieveRecipeAllergies(recipelist[b].recipename);
                                countwords = countword(customerdietlist[i].allergy);
                                for (int j = 0; j < countwords; j++)
                                {
                                    for (int k = 0; k < recipeallergylist.Count; k++)
                                    {
                                        if (customerdietlist[i].allergy.Split(' ')[j] == recipeallergylist[k].recipeallergy)
                                        {
                                            allergy = true;
                                        }
                                    }
                                }
                            }
                            if(allergy != true)
                            {
                                for (int l = 0; l < customerdietlist.Count; l++)
                                {
                                    ingredientlist = viewrecipe.retrieveRecipeIngredient(recipelist[b].recipename);
                                    countavoidance = countword(customerdietlist[l].avoid);
                                    for (int m = 0; m < countavoidance; m++)
                                    {
                                        for (int n = 0; n < ingredientlist.Count; n++)
                                        {
                                            if (customerdietlist[l].avoid.Split(' ')[m] == ingredientlist[n].ingredientname)
                                            {
                                                avoidance = true;
                                            }
                                        }

                                    }
                                }
                                if (avoidance != true)
                                {
                                    string type = caloriesType(Math.Round(caloriesneeded, 0));

                                    if (type == recipelist[b].recipecaloriestype)
                                    {
                                        StringBuilder sqlcom = new StringBuilder();
                                        sqlcom.AppendLine("SELECT * FROM Recipe");
                                        sqlcom.AppendLine("WHERE Recipe.Day = @paraday");


                                        try
                                        {
                                            SqlConnection myConn = new SqlConnection(DBConnect);
                                            SqlDataAdapter da;
                                            da = new SqlDataAdapter(sqlcom.ToString(), myConn);
                                            da.SelectCommand.Parameters.AddWithValue("@paraday", day);



                                            da.Fill(ds, "tdTable");

                                            int rec_cnt = ds.Tables["tdTable"].Rows.Count;
                                            int num = rec_cnt;
                                            if (num > 0)
                                            {

                                                DataRow row = ds.Tables["tdTable"].Rows[b];
                                                CustomerViewRecipe recipe = new CustomerViewRecipe();
                                                recipe.recipename = row["RecipeName"].ToString();
                                                recipe.recipemedicalcondition = retrieveRecipeMedicalCondition(recipe.recipename);
                                                recipe.recipeimage = row["Image"].ToString();
                                                recipe.recipetype = row["Type"].ToString();
                                                recipe.recipeportion = int.Parse(row["Portion"].ToString());
                                                recipe.recipecookingtime = int.Parse(row["CookingTime"].ToString());
                                                recipe.recipecookingtype = row["CookingType"].ToString();
                                                recipe.recipefounder = row["RecipeFounder"].ToString();
                                                recipe.recipecalories = Decimal.Parse(row["TotalCalories"].ToString());
                                                recipe.recipesodium = Decimal.Parse(row["TotalSodium"].ToString());
                                                recipe.recipesugar = Decimal.Parse(row["TotalSugar"].ToString());
                                                recipe.recipefibre = Decimal.Parse(row["TotalDietaryFibre"].ToString());
                                                recipe.recipecholesterol = Decimal.Parse(row["TotalCholesterol"].ToString());
                                                recipe.recipecarbohydrate = Decimal.Parse(row["TotalCarbohydrates"].ToString());
                                                recipe.recipeprotein = Decimal.Parse(row["TotalProteins"].ToString());
                                                recipe.recipesatfat = Decimal.Parse(row["TotalSaturatedFat"].ToString());
                                                recipe.recipetransfat = Decimal.Parse(row["TotalTransFat"].ToString());
                                                recipe.recipetotalfat = Decimal.Parse(row["TotalFat"].ToString());



                                                list.Add(recipe);
                                            }

                                        }
                                        catch (Exception e)
                                        {
                                            list = null;
                                        }
                                    }     
                                }
                            }       
                        }

                    }
                }
            }
            
            return list;
        }

        public int countword(string sentence)
        {
            string[] word = sentence.Split(' ');
            int wordCount = word.Count() - 1;
            return wordCount;
        }

        public string caloriesType(decimal calories)
        {
            string type = string.Empty;
            decimal c = calories;

            if( (decimal)150< c && c <= (decimal)400)
            {
                type = "Low";

            }else if((decimal)400 < c && c <= (decimal)600)
            {
                type = "Medium";

            }else if((decimal)600 < c && c <= (decimal)800)
            {
                type = "MediumHigh";

            }else if((decimal)800 < c && c <= (decimal)1000)
            {
                type = "High";
            }

            return type;
        }

        public string instruction(string ins)
        {
            string newin = string.Empty;
            newin = ins.Replace("style", " ");
            return newin;
        }

    }
}