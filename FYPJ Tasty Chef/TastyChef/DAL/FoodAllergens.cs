using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TastyChef.DAL
{
    public class FoodAllergens
    {
        private string foodAllergyName;
        private string recipeName;
        string _connStr = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;

        public FoodAllergens()
        {

        }

        public FoodAllergens(string foodAllergyName)
        {
            this.foodAllergyName = foodAllergyName;
        }

        public FoodAllergens(string foodAllergyName, string recipeName)
        {
            this.FoodAllergyName = foodAllergyName;
            this.RecipeName = recipeName;
        }

        public string FoodAllergyName
        {
            get
            {
                return foodAllergyName;
            }

            set
            {
                foodAllergyName = value;
            }
        }

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
        //Insert Method
        public int InsertFoodAllergens(string RecipeName,string FoodAllergenName)
        {
            int result = 0;
            string queryStr = "INSERT INTO Recipe_FoodAllergens(RecipeName,FoodAllergyName)" + "values (@RecipeName,@FoodAllergyName)";
            SqlConnection conn = new SqlConnection(_connStr); SqlCommand cmd = new SqlCommand(queryStr, conn);

            cmd.Parameters.AddWithValue("@RecipeName", RecipeName);
            cmd.Parameters.AddWithValue("@FoodAllergyName", FoodAllergenName);
    

            conn.Open();
            result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
            conn.Close();
            return result;
        }
        public List<FoodAllergens> RetrieveFoodAllergensByRecipeName(string recipeName)
        {
            List<FoodAllergens> tmrList = new List<FoodAllergens>();

            string FoodAllergenName;
            string queryStr = "SELECT * From Recipe_FoodAllergens where RecipeName = @RecipeName";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@RecipeName", recipeName);
            SqlDataReader dr = cmd.ExecuteReader();
            //Continue to read the resultsets row by row if not the end
            while (dr.Read())
            {
                FoodAllergenName = dr["FoodAllergyName"].ToString();
                FoodAllergens tmr = new FoodAllergens(FoodAllergenName);
                tmrList.Add(tmr);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return tmrList;
        }
    }
}