using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TastyChef.DAL
{
    public class ListOfIngredients
    {
        private string recipeName;
        private int quantity;
        private string ingredientName;
        private string measurement;

        string _connStr = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
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

        public ListOfIngredients()
        {

        }

        public ListOfIngredients(string recipeName, int quantity, string ingredientName, string measurement)
        {
            this.recipeName = recipeName;
            this.quantity = quantity;
            this.ingredientName = ingredientName;
            this.measurement = measurement;
        }

        public ListOfIngredients(int quantity, string ingredientName, string measurement)
        {
            this.quantity = quantity;
            this.ingredientName = ingredientName;
            this.measurement = measurement;
        }
        //Insert Method
        public int InsertListofIngredients(string RecipeName, int quantity, string ingredientName , string measurement)
        {
            int result = 0;
            string queryStr = "INSERT INTO ListOfIngredients(RecipeName,IngredientName,Quantity,Measurement)" + "values (@RecipeName,@IngredientName,@Quantity,@Measurement)";
            SqlConnection conn = new SqlConnection(_connStr); SqlCommand cmd = new SqlCommand(queryStr, conn);

            cmd.Parameters.AddWithValue("@RecipeName", RecipeName);
            cmd.Parameters.AddWithValue("@IngredientName", ingredientName);
            cmd.Parameters.AddWithValue("@Quantity", quantity);
            cmd.Parameters.AddWithValue("@Measurement", measurement);


            conn.Open();
            result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
            conn.Close();
            return result;
        }
        public List<ListOfIngredients> RetrieveListOfIngredientsByRecipeName(string recipeName)
        {

            string queryStr = "SELECT * FROM ListOfIngredients WHERE RecipeName = @RecipeName";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            List<ListOfIngredients> rList = new List<ListOfIngredients>();

            string RecipeName;
            int Quantity;
            string IngredientName;
            string Measurement;


            conn.Open();
            cmd.Parameters.AddWithValue("@RecipeName", recipeName);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                RecipeName = dr["RecipeName"].ToString();
                Quantity = Convert.ToInt32(dr["Quantity"].ToString());
                IngredientName = dr["IngredientName"].ToString();
                Measurement = dr["Measurement"].ToString();


                ListOfIngredients r = new ListOfIngredients(RecipeName, Quantity, IngredientName, Measurement);

                rList.Add(r);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return rList;
        }
        public Boolean checkIngredientNameExistInDataBase(string ingredientName, string recipeName)
        {
            Boolean result = false;

            SqlConnection conn = new SqlConnection(_connStr);

            string queryString = "Select * FROM ListOfIngredients where IngredientName = @IngredientName and RecipeName = @RecipeName";
            SqlCommand cmd = new SqlCommand(queryString, conn);
            cmd.Parameters.AddWithValue("@IngredientName", ingredientName);
            cmd.Parameters.AddWithValue("@RecipeName", recipeName);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                result = true;
            }
            else
            {

                result = false;
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return result;

        }
    }
}