using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TastyChef.DAL
{
    public class Ingredients
    {
        private string ingredientName;
        private string image;
        private string category;
        private string remarks;
        private decimal proteins;
        private decimal carbohydrates;
        private decimal saturatedFat;
        private decimal transFat;
        private decimal totalFat;
        private decimal sugar;
        private decimal calories;
        private decimal dietaryFiber;
        private decimal cholesterol;
        private decimal sodium;
        private string measurement;

        public string IngredientName
        {
            get
            {
                return ingredientName;
            }

            set
            {
                ingredientName = value;
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

        public string Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
            }
        }

  
        

        public string Remarks
        {
            get
            {
                return remarks;
            }

            set
            {
                remarks = value;
            }
        }

        public decimal Proteins
        {
            get
            {
                return proteins;
            }

            set
            {
                proteins = value;
            }
        }

        public decimal Carbohydrates
        {
            get
            {
                return carbohydrates;
            }

            set
            {
                carbohydrates = value;
            }
        }

        public decimal SaturatedFat
        {
            get
            {
                return saturatedFat;
            }

            set
            {
                saturatedFat = value;
            }
        }

        public decimal TransFat
        {
            get
            {
                return transFat;
            }

            set
            {
                transFat = value;
            }
        }

        public decimal Sugar
        {
            get
            {
                return sugar;
            }

            set
            {
                sugar = value;
            }
        }

        public decimal Calories
        {
            get
            {
                return calories;
            }

            set
            {
                calories = value;
            }
        }

        public decimal DietaryFiber
        {
            get
            {
                return dietaryFiber;
            }

            set
            {
                dietaryFiber = value;
            }
        }

        public decimal Cholesterol
        {
            get
            {
                return cholesterol;
            }

            set
            {
                cholesterol = value;
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

        public decimal Sodium
        {
            get
            {
                return sodium;
            }

            set
            {
                sodium = value;
            }
        }

        public string Measurement
        {
            get
            {
                return measurement;
            }

            set
            {
                measurement = value;
            }
        }

        string _connStr = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;

        //Default Constructor
        public Ingredients()
        {

        }
        //Retrieve All Ingredients
        public Ingredients(string name, string image, string category, decimal calories)
        {
            this.IngredientName = name;
            this.Image = image;
            this.Category = category;
            this.Calories = calories;
        }
        //No Sodium
        public Ingredients(string ingredientName, string image, string category, string remarks, decimal proteins, decimal carbohydrates, decimal saturatedFat, decimal transFat, decimal totalFat, decimal sugar, decimal calories, decimal dietaryFiber, decimal cholesterol,string measurement)
        {
            this.ingredientName = ingredientName;
            this.image = image;
            this.category = category;
            this.remarks = remarks;
            this.proteins = proteins;
            this.carbohydrates = carbohydrates;
            this.saturatedFat = saturatedFat;
            this.transFat = transFat;
            this.sugar = sugar;
            this.calories = calories;
            this.dietaryFiber = dietaryFiber;
            this.cholesterol = cholesterol;
            this.totalFat = totalFat;
            this.measurement = measurement;

        }
        //Constructor that takes in all the attributes

        public Ingredients(string ingredientName, string image, string category, string remarks, decimal proteins, decimal carbohydrates, decimal saturatedFat, decimal transFat,decimal totalFat, decimal sugar, decimal calories, decimal dietaryFiber, decimal cholesterol,decimal sodium,string measurement)
        {
            this.ingredientName = ingredientName;
            this.image = image;
            this.category = category;
            this.remarks = remarks;
            this.proteins = proteins;
            this.carbohydrates = carbohydrates;
            this.saturatedFat = saturatedFat;
            this.transFat = transFat;
            this.sugar = sugar;
            this.calories = calories;
            this.dietaryFiber = dietaryFiber;
            this.cholesterol = cholesterol;
            this.totalFat = totalFat;
            this.sodium = sodium;
            this.measurement = measurement;
        }
        //Constructor that takes in all the Nutritional Information

        public Ingredients(string ingredientName,decimal proteins, decimal carbohydrates, decimal saturatedFat, decimal transFat, decimal totalFat, decimal sugar, decimal calories, decimal dietaryFiber, decimal cholesterol, decimal sodium)
        {
            this.proteins = proteins;
            this.carbohydrates = carbohydrates;
            this.saturatedFat = saturatedFat;
            this.transFat = transFat;
            this.totalFat = totalFat;
            this.sugar = sugar;
            this.calories = calories;
            this.dietaryFiber = dietaryFiber;
            this.cholesterol = cholesterol;
            this.sodium = sodium;
            this.ingredientName = ingredientName;
        }

        //Insert method to Ingredients Table
        public int IngredientsInsert(string ingredientName, string image, string category, string remarks, decimal proteins, decimal sodium, decimal carbohydrates, decimal saturatedFat, decimal transFat, decimal totalFat, decimal sugar, decimal calories, decimal dietaryFiber, decimal cholesterol, string measurement)
        {

            int result = 0;
            string queryStr = "INSERT INTO Ingredients(IngredientName,Image,Category,Sodium,Remarks,Proteins, Carbohydrates,SaturatedFat,TransFat,TotalFat,Sugar,Calories,DietaryFiber,Cholesterol,Measurement)" + "values (@IngredientName,@Image,@Category,@Sodium,@Remarks,@Proteins,@Carbohydrates,@SaturatedFat,@TransFat,@TotalFat,@Sugar,@Calories,@DietaryFiber,@Cholesterol,@Measurement)";
            SqlConnection conn = new SqlConnection(_connStr); SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@IngredientName", ingredientName);
            cmd.Parameters.AddWithValue("@Image", image);
            cmd.Parameters.AddWithValue("@Category", category);
            cmd.Parameters.AddWithValue("@Sodium", sodium);
            cmd.Parameters.AddWithValue("@Remarks", remarks);
            cmd.Parameters.AddWithValue("@Proteins", proteins);
            cmd.Parameters.AddWithValue("@Carbohydrates", carbohydrates);
            cmd.Parameters.AddWithValue("@SaturatedFat", saturatedFat);
            cmd.Parameters.AddWithValue("@TransFat", transFat);
            cmd.Parameters.AddWithValue("@TotalFat", totalFat);
            cmd.Parameters.AddWithValue("@Sugar", sugar);
            cmd.Parameters.AddWithValue("@Calories", calories);
            cmd.Parameters.AddWithValue("@DietaryFiber", dietaryFiber);
            cmd.Parameters.AddWithValue("@Cholesterol", cholesterol);
            cmd.Parameters.AddWithValue("@Measurement", measurement);



            conn.Open();
            result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
            conn.Close();
            return result;
        }//end Insert
         //check if Ingredient Name exist
        public int checkIngredientName(string ingredientName)
        {
            int result = 0;

            SqlConnection conn = new SqlConnection(_connStr);

            string queryString = "Select * FROM Ingredients where IngredientName = @IngredientName ";
            SqlCommand cmd = new SqlCommand(queryString, conn);
            cmd.Parameters.AddWithValue("@IngredientName", ingredientName);


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
        public List<Ingredients> RetriveAllIngredients()
        {
            List<Ingredients> ingredientList = new List<Ingredients>();

            string ingredientName;
            string image;
            string category;

            decimal calories;

            string queryStr = "SELECT * FROM Ingredients";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            //Continue to read the resultsets row by row if not the end
            while (dr.Read())
            {

                ingredientName = dr["IngredientName"].ToString();

                image = dr["Image"].ToString();
                category = dr["Category"].ToString();

                calories = decimal.Parse(dr["Calories"].ToString());

                Ingredients ingredient = new Ingredients(ingredientName, image, category, calories);
                ingredientList.Add(ingredient);


            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return ingredientList;
        }
        //Method for Search Ingredient, search by Ingredient Name and Ingredient Category
        public List<Ingredients> SearchIngredients(string name, string category)
        {

            string queryStr = "SELECT * FROM Ingredients WHERE IngredientName LIKE '%" + name + "%' and Category=@Category";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            List<Ingredients> ingredientList = new List<Ingredients>();

            string ingredientName;
            string image;
         
            string measurement;

            string remarks;
            decimal proteins;
            decimal carbohydrates;
            decimal saturatedFat;
            decimal transFat;
            decimal sugar;
            decimal calories;
            decimal dietaryFiber;
            decimal cholesterol;

            
            cmd.Parameters.AddWithValue("@Category", category);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                ingredientName = dr["IngredientName"].ToString();
                image = dr["Image"].ToString();
                category = dr["Category"].ToString();
                remarks = dr["Remarks"].ToString();
                proteins = decimal.Parse(dr["Proteins"].ToString());
                carbohydrates = decimal.Parse(dr["Carbohydrates"].ToString());
                saturatedFat = decimal.Parse(dr["SaturatedFat"].ToString());
                transFat = decimal.Parse(dr["TransFat"].ToString());
                totalFat = decimal.Parse(dr["TotalFat"].ToString());
                sugar = decimal.Parse(dr["Sugar"].ToString());
                dietaryFiber = decimal.Parse(dr["DietaryFiber"].ToString());
                cholesterol = decimal.Parse(dr["Cholesterol"].ToString());
                calories = decimal.Parse(dr["Calories"].ToString());
                measurement = dr["Measurement"].ToString();

                Ingredients ingredient = new Ingredients(ingredientName, image, category, remarks, proteins, carbohydrates, saturatedFat, transFat, totalFat, sugar, calories, dietaryFiber, cholesterol, measurement);
                ingredientList.Add(ingredient);


            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return ingredientList;
        }
        //Method for Search Ingredient, search by Ingredient Name and Ingredient Category
        public List<Ingredients> SearchIngredientsNameOnly(string name)
        {

            string queryStr = "SELECT * FROM Ingredients WHERE IngredientName LIKE '%" + name + "%'";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            List<Ingredients> ingredientList = new List<Ingredients>();

            string ingredientName;
            string image;

            string measurement;

            string remarks;
            decimal proteins;
            decimal carbohydrates;
            decimal saturatedFat;
            decimal transFat;
            decimal sugar;
            decimal calories;
            decimal dietaryFiber;
            decimal cholesterol;


       
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                ingredientName = dr["IngredientName"].ToString();
                image = dr["Image"].ToString();
                category = dr["Category"].ToString();
                remarks = dr["Remarks"].ToString();
                proteins = decimal.Parse(dr["Proteins"].ToString());
                carbohydrates = decimal.Parse(dr["Carbohydrates"].ToString());
                saturatedFat = decimal.Parse(dr["SaturatedFat"].ToString());
                transFat = decimal.Parse(dr["TransFat"].ToString());
                totalFat = decimal.Parse(dr["TotalFat"].ToString());
                sugar = decimal.Parse(dr["Sugar"].ToString());
                dietaryFiber = decimal.Parse(dr["DietaryFiber"].ToString());
                cholesterol = decimal.Parse(dr["Cholesterol"].ToString());
                calories = decimal.Parse(dr["Calories"].ToString());
                measurement = dr["Measurement"].ToString();

                Ingredients ingredient = new Ingredients(ingredientName, image, category, remarks, proteins, carbohydrates, saturatedFat, transFat, totalFat, sugar, calories, dietaryFiber, cholesterol, measurement);
                ingredientList.Add(ingredient);


            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return ingredientList;
        }
        public int RetriveLTotalIngredients()
        {
            int kp = 0;

            string queryStr = "Select * FROM Ingredients";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            //Continue to read the resultsets row by row if not the end
            while (dr.Read())
            {

                kp++;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();
            return kp;
        }
        public List<Ingredients> RetriveAllIngredientsDetailsByName(string Name)
        {
            List<Ingredients> ingredientList = new List<Ingredients>();

            string ingredientName;
            string image;
            string category;
            string measurement;

            string remarks;
            decimal proteins;
            decimal carbohydrates;
            decimal saturatedFat;
            decimal transFat;
            decimal sugar;
            decimal calories;
            decimal dietaryFiber;
            decimal cholesterol;

            string queryStr = "SELECT * FROM Ingredients where IngredientName=@IngredientName ";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@IngredientName", Name);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            //Continue to read the resultsets row by row if not the end
            while (dr.Read())
            {

                ingredientName = dr["IngredientName"].ToString();
                image = dr["Image"].ToString();
                category = dr["Category"].ToString();
                remarks = dr["Remarks"].ToString();
                proteins = decimal.Parse(dr["Proteins"].ToString());
                carbohydrates = decimal.Parse(dr["Carbohydrates"].ToString());
                saturatedFat= decimal.Parse(dr["SaturatedFat"].ToString());
                transFat = decimal.Parse(dr["TransFat"].ToString());
                totalFat = decimal.Parse(dr["TotalFat"].ToString());
                sugar = decimal.Parse(dr["Sugar"].ToString());
                dietaryFiber = decimal.Parse(dr["DietaryFiber"].ToString());
                cholesterol = decimal.Parse(dr["Cholesterol"].ToString());
                calories = decimal.Parse(dr["Calories"].ToString());
                measurement = dr["Measurement"].ToString();

                Ingredients ingredient = new Ingredients(ingredientName, image, category, remarks, proteins, carbohydrates, saturatedFat, transFat, totalFat, sugar, calories, dietaryFiber, cholesterol, measurement);
                ingredientList.Add(ingredient);


            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return ingredientList;
        }
        public Ingredients RetriveOneIngredientsDetailsByName(string Name)
        {
            Ingredients ingredient = new Ingredients();

            string ingredientName;
            string image;
            string category;

            string remarks;
            decimal proteins;
            decimal carbohydrates;
            decimal saturatedFat;
            decimal transFat;
            decimal sugar;
            decimal calories;
            decimal dietaryFiber;
            decimal cholesterol;
            decimal sodium;

            string queryStr = "SELECT * FROM Ingredients where IngredientName=@IngredientName ";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@IngredientName", Name);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            //Continue to read the resultsets row by row if not the end
            if (dr.Read())
            {

                ingredientName = dr["IngredientName"].ToString();
                image = dr["Image"].ToString();
                category = dr["Category"].ToString();
                remarks = dr["Remarks"].ToString();
                proteins = decimal.Parse(dr["Proteins"].ToString());
                carbohydrates = decimal.Parse(dr["Carbohydrates"].ToString());
                saturatedFat = decimal.Parse(dr["SaturatedFat"].ToString());
                transFat = decimal.Parse(dr["TransFat"].ToString());
                totalFat = decimal.Parse(dr["TotalFat"].ToString());
                sugar = decimal.Parse(dr["Sugar"].ToString());
                dietaryFiber = decimal.Parse(dr["DietaryFiber"].ToString());
                cholesterol = decimal.Parse(dr["Cholesterol"].ToString());
                calories = decimal.Parse(dr["Calories"].ToString());
                sodium = decimal.Parse(dr["Sodium"].ToString());
                measurement = dr["Measurement"].ToString();


                Ingredients ingredienta = new Ingredients(ingredientName, image, category, remarks, proteins, carbohydrates, saturatedFat, transFat, totalFat, sugar, calories, dietaryFiber, cholesterol, sodium, measurement);
                ingredient = ingredienta;


            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return ingredient;
        }
    }

}