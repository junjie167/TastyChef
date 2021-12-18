using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TastyChef.DAL
{
    public class Recipe
    {
        private string recipeName;
        private string image;
        private string type;
        private string day;
        private int portion;
        private int cookingTime;
        private string recipeFounder;
        private string cookingType;
        
     
  
        private decimal totalCalories;
        private decimal totalSodium;
        private decimal totalCholesterol;
        private decimal totalSugar;
        private decimal totalDietaryFiber;
        private decimal totalCarbohydrates;
        private decimal totalProteins;
        private decimal totalSaturatedFat;
        private decimal totalTransFat;
        private decimal totalFat;
        

        public string RecipeName
        {
            get
            {
                return recipeName;
            }

            set
            {
                recipeName = value;
            }
        }

        public string Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public int Portion
        {
            get
            {
                return portion;
            }

            set
            {
                portion = value;
            }
        }

        public int CookingTime
        {
            get
            {
                return cookingTime;
            }

            set
            {
                cookingTime = value;
            }
        }

        public string CookingType
        {
            get
            {
                return cookingType;
            }

            set
            {
                cookingType = value;
            }
        }


        public string RecipeFounder
        {
            get
            {
                return recipeFounder;
            }

            set
            {
                recipeFounder = value;
            }
        }

      

        public decimal TotalCalories
        {
            get
            {
                return totalCalories;
            }

            set
            {
                totalCalories = value;
            }
        }

        public decimal TotalSodium
        {
            get
            {
                return totalSodium;
            }

            set
            {
                totalSodium = value;
            }
        }

        public decimal TotalCholesterol
        {
            get
            {
                return totalCholesterol;
            }

            set
            {
                totalCholesterol = value;
            }
        }

        public decimal TotalSugar
        {
            get
            {
                return totalSugar;
            }

            set
            {
                totalSugar = value;
            }
        }

        public decimal TotalDietaryFiber
        {
            get
            {
                return totalDietaryFiber;
            }

            set
            {
                totalDietaryFiber = value;
            }
        }

        public decimal TotalCarbohydrates
        {
            get
            {
                return totalCarbohydrates;
            }

            set
            {
                totalCarbohydrates = value;
            }
        }

        public decimal TotalProteins
        {
            get
            {
                return totalProteins;
            }

            set
            {
                totalProteins = value;
            }
        }

        public decimal TotalSaturatedFat
        {
            get
            {
                return totalSaturatedFat;
            }

            set
            {
                totalSaturatedFat = value;
            }
        }

        public decimal TotalTransFat
        {
            get
            {
                return totalTransFat;
            }

            set
            {
                totalTransFat = value;
            }
        }

        public decimal TotalFat
        {
            get
            {
                return totalFat;
            }

            set
            {
                totalFat = value;
            }
        }

        public string Day
        {
            get
            {
                return day;
            }

            set
            {
                day = value;
            }
        }
        string _connStr = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;

        //Default Constuctor
        public Recipe()
        {

        }

        //Constructor For Recipe Step 1 Session
        public Recipe(string recipeName1, string image1, string type1, int portion1, int cookingTime1, string recipeFounder1, string cookingType1)
        {
            this.recipeName = recipeName1;
            this.image = image1;
            this.type = type1;
            this.portion = portion1;
            this.cookingTime = cookingTime1;
            this.recipeFounder = recipeFounder1;
            this.cookingType = cookingType1;
        }

        public Recipe(string recipeName, string image, string type, string day)
        {
            this.recipeName = recipeName;
            this.image = image;
            this.type = type;
            this.Day = day;
        }

        public Recipe(string recipeName, string image, string type, string day, int portion, int cookingTime, string recipeFounder, string cookingType, decimal totalCalories, decimal totalSodium, decimal totalCholesterol, decimal totalSugar, decimal totalDietaryFiber, decimal totalCarbohydrates, decimal totalProteins, decimal totalSaturatedFat, decimal totalTransFat, decimal totalFat)
        {
            this.recipeName = recipeName;
            this.image = image;
            this.type = type;
            this.day = day;
            this.portion = portion;
            this.cookingTime = cookingTime;
            this.recipeFounder = recipeFounder;
            this.cookingType = cookingType;
            this.totalCalories = totalCalories;
            this.totalSodium = totalSodium;
            this.totalCholesterol = totalCholesterol;
            this.totalSugar = totalSugar;
            this.totalDietaryFiber = totalDietaryFiber;
            this.totalCarbohydrates = totalCarbohydrates;
            this.totalProteins = totalProteins;
            this.totalSaturatedFat = totalSaturatedFat;
            this.totalTransFat = totalTransFat;
            this.totalFat = totalFat;
        }

        //check if Recipe Name exist
        public int checkRecipeName(string recipeName)
        {
            int result = 0;

            SqlConnection conn = new SqlConnection(_connStr);

            string queryString = "Select * FROM Recipe where RecipeName = @RecipeName ";
            SqlCommand cmd = new SqlCommand(queryString, conn);
            cmd.Parameters.AddWithValue("@RecipeName", recipeName);


            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                result = 1;
            }
            else
            {

                result = 0;
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return result;

        }
        //Insert Method
        public int InsertRecipe(string RecipeName, string Image, string Type, int Portion, int CookingTime, string CookingType, string RecipeFounder, decimal TotalCalories, decimal TotalSodium, decimal TotalSugar, decimal TotalDietaryFiber, decimal TotalCholesterol, decimal TotalCarbohydrates, decimal TotalProteins, decimal TotalSaturatedFat, decimal TotalTransFat, decimal TotalFat, string Day,string caloriesType)
        {
            int result = 0;
            string queryStr = "INSERT INTO Recipe(RecipeName,Image,Type,Portion,CookingTime,CookingType,RecipeFounder,TotalCalories,TotalSodium,TotalSugar,TotalDietaryFibre,TotalCholesterol,TotalCarbohydrates,TotalProteins,TotalSaturatedFat,TotalTransFat,TotalFat,Day,CaloriesType)" + "values (@RecipeName,@Image,@Type,@Portion,@CookingTime,@CookingType,@RecipeFounder,@TotalCalories,@TotalSodium,@TotalSugar,@TotalDietaryFiber,@TotalCholesterol,@TotalCarbohydrates,@TotalProteins,@TotalSaturatedFat,@TotalTransFat,@TotalFat,@Day,@CaloriesType)";
            SqlConnection conn = new SqlConnection(_connStr); SqlCommand cmd = new SqlCommand(queryStr, conn);
 
            cmd.Parameters.AddWithValue("@RecipeName", RecipeName);
            cmd.Parameters.AddWithValue("@Image", Image);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@Portion", Portion);
            cmd.Parameters.AddWithValue("@CookingTime", CookingTime);
            cmd.Parameters.AddWithValue("@CookingType", CookingType);
            cmd.Parameters.AddWithValue("@RecipeFounder", RecipeFounder);
            cmd.Parameters.AddWithValue("@TotalCalories", TotalCalories);
            cmd.Parameters.AddWithValue("@TotalSodium", TotalSodium);
            cmd.Parameters.AddWithValue("@TotalSugar", TotalSugar);
            cmd.Parameters.AddWithValue("@TotalDietaryFiber", TotalDietaryFiber);
            cmd.Parameters.AddWithValue("@TotalCholesterol", TotalCholesterol);
            cmd.Parameters.AddWithValue("@TotalCarbohydrates", TotalCarbohydrates);
            cmd.Parameters.AddWithValue("@TotalProteins", TotalProteins);
            cmd.Parameters.AddWithValue("@TotalSaturatedFat", TotalSaturatedFat);
            cmd.Parameters.AddWithValue("@TotalTransFat", TotalTransFat);
            cmd.Parameters.AddWithValue("@TotalFat", TotalFat);
            cmd.Parameters.AddWithValue("@Day", Day);
            cmd.Parameters.AddWithValue("@CaloriesType", caloriesType);
            conn.Open();
            result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
            conn.Close();
            return result;
        }
        public int UpdateRecipeAvailableDay(string RecipeName, string day)
        {
            int result = 0;
            string queryStr = "Update Recipe Set Day=@Day WHERE RecipeName=@RecipeName";
            SqlConnection conn = new SqlConnection(_connStr); SqlCommand cmd = new SqlCommand(queryStr, conn);

            cmd.Parameters.AddWithValue("@RecipeName", RecipeName);
            cmd.Parameters.AddWithValue("@Day", day);
           
            conn.Open();
            result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
            conn.Close();
            return result;
        }

        public List<Recipe> RetriveAllRecipe()
        {
            List<Recipe> recipeList = new List<Recipe>();

            string recipeName;
            string image;
            string schedule;
            string type;

        

            string queryStr = "SELECT * FROM Recipe";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            //Continue to read the resultsets row by row if not the end
            while (dr.Read())
            {

                recipeName = dr["RecipeName"].ToString();

                image = dr["Image"].ToString();
                type = dr["Type"].ToString();
                schedule = dr["Day"].ToString();
              

                Recipe r = new Recipe(recipeName,image,type, schedule);
                recipeList.Add(r);


            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return recipeList;
        }
     
        public List<Recipe> SearchRecipeByName(string recipeName)
        {

            string queryStr = "SELECT * FROM Recipe WHERE RecipeName LIKE '%" + recipeName + "%'";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            List<Recipe> rList = new List<Recipe>();

         
            string image;
            string schedule;
            string type;


          
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                recipeName = dr["RecipeName"].ToString();

                image = dr["Image"].ToString();
                type = dr["Type"].ToString();
                schedule = dr["Day"].ToString();


                Recipe r = new Recipe(recipeName, image, type, schedule);
                rList.Add(r);


            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return rList;
        }
       
        public List<Recipe> SearchRecipeByDay(string sday)
        {

            string queryStr = "SELECT * FROM Recipe WHERE Day = @Day" ;
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            List<Recipe> rList = new List<Recipe>();


            string image;
            string schedule;
            string type;



            conn.Open();
            cmd.Parameters.AddWithValue("@Day",sday);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                recipeName = dr["RecipeName"].ToString();

                image = dr["Image"].ToString();
                type = dr["Type"].ToString();
                schedule = dr["Day"].ToString();


                Recipe r = new Recipe(recipeName, image, type, schedule);
                rList.Add(r);


            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return rList;
        }
        public Recipe SearchRecipeByDayReturnRecipe(string sday,string recipeName)
        {

            string queryStr = "SELECT * FROM Recipe WHERE Day = @Day and RecipeName=@RecipeName";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            Recipe r=null;


            string image;
            string schedule;
            string type;



            conn.Open();
            cmd.Parameters.AddWithValue("@Day", sday);
            cmd.Parameters.AddWithValue("@RecipeName", recipeName);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                recipeName = dr["RecipeName"].ToString();

                image = dr["Image"].ToString();
                type = dr["Type"].ToString();
                schedule = dr["Day"].ToString();


              r = new Recipe(recipeName, image, type, schedule);
              


            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return r;
        }
        public List<Recipe> SearchRecipeByType(string Type)
        {

            string queryStr = "SELECT * FROM Recipe WHERE Type = @Type";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            List<Recipe> rList = new List<Recipe>();


            string image;
            string schedule;
            string type;



            conn.Open();
            cmd.Parameters.AddWithValue("@Type", Type);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                recipeName = dr["RecipeName"].ToString();

                image = dr["Image"].ToString();
                type = dr["Type"].ToString();
                schedule = dr["Day"].ToString();


                Recipe r = new Recipe(recipeName, image, type, schedule);
                rList.Add(r);


            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return rList;
        }
        public Recipe SearchRecipe(string recipeName)
        {

            string queryStr = "SELECT * FROM Recipe WHERE RecipeName =@RecipeName";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            Recipe r = new Recipe();


            string image;
            string schedule;
            string type;



            conn.Open();
            cmd.Parameters.AddWithValue("@RecipeName", recipeName);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {

                recipeName = dr["RecipeName"].ToString();

                image = dr["Image"].ToString();
                type = dr["Type"].ToString();
                schedule = dr["Day"].ToString();


                 r = new Recipe(recipeName, image, type, schedule);
                


            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return r;
        }
        public Recipe GetRecipeDetailsByRecipeName(string recipeName)
        {
            Recipe r;
            string RecipeName;
            string Image;
            string Type;
            int Portion;
            int CookingTime;
            string CookingType;
            string RecipeFounder;
            decimal TotalCalories, TotalSodium, TotalSugar, TotalDietaryFiber, TotalCholesterol, TotalCarbohydrates, TotalProteins, TotalSaturatedFat, TotalTransFat, TotalFat;
            string Day;
          
            string queryStr = "Select * FROM Recipe WHERE RecipeName = @RecipeName";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@RecipeName", recipeName);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            //check if there are any resultsets 
            if (dr.Read())
            {
                RecipeName = dr["RecipeName"].ToString();

                Image = dr["Image"].ToString();
                Type = dr["Type"].ToString();
                Day = dr["Day"].ToString();
                Portion = Convert.ToInt32(dr["Portion"].ToString());
                CookingTime = Convert.ToInt32(dr["CookingTime"].ToString());
                CookingType = dr["CookingType"].ToString();
                RecipeFounder = dr["RecipeFounder"].ToString();
                TotalCalories= Convert.ToDecimal(dr["TotalCalories"].ToString());
                TotalSodium= Convert.ToDecimal(dr["TotalSodium"].ToString());
                TotalSugar= Convert.ToDecimal(dr["TotalSugar"].ToString());
                TotalDietaryFiber= Convert.ToDecimal(dr["TotalDietaryFibre"].ToString());
                TotalCholesterol= Convert.ToDecimal(dr["TotalCholesterol"].ToString());
                TotalCarbohydrates= Convert.ToDecimal(dr["TotalCarbohydrates"].ToString());
                TotalProteins= Convert.ToDecimal(dr["TotalProteins"].ToString());
               TotalSaturatedFat = Convert.ToDecimal(dr["TotalSaturatedFat"].ToString());
                TotalTransFat= Convert.ToDecimal(dr["TotalTransFat"].ToString());
               TotalFat = Convert.ToDecimal(dr["TotalFat"].ToString());





                r = new Recipe(RecipeName, Image, Type, Day, Portion, CookingTime, RecipeFounder, CookingType, TotalCalories, TotalSodium, TotalCholesterol, TotalSugar, TotalDietaryFiber, TotalCarbohydrates, TotalProteins, TotalSaturatedFat, TotalTransFat, TotalFat);
            }
            else
            {
                r = null;
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return r;

        }
       
        public List<Recipe> SearchRecipeByNameAndDayAvailable(string recipeName,string day)
        {

            string queryStr = "SELECT * FROM Recipe WHERE RecipeName LIKE '%" + recipeName + "%' and Day = @Day";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            List<Recipe> rList = new List<Recipe>();


            string image;
            string schedule;
            string type;


          
            conn.Open();
            cmd.Parameters.AddWithValue("@Day", day);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                recipeName = dr["RecipeName"].ToString();

                image = dr["Image"].ToString();
                type = dr["Type"].ToString();
                schedule = dr["Day"].ToString();


                Recipe r = new Recipe(recipeName, image, type, schedule);
                rList.Add(r);


            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return rList;
        }
    }
}