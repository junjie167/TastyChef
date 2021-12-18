using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace TastyChef.DAL
{
    public class TailoredMadeRecipes
    {
        private string tagsMedicalCondition;
        private string recipeName;

        string _connStr = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;


        public TailoredMadeRecipes(string tagsMedicalCondition)
        {
            this.tagsMedicalCondition = tagsMedicalCondition;
        }
        public TailoredMadeRecipes()
        {

        }

        public TailoredMadeRecipes(string tagsMedicalCondition, string recipeName)
        {
            this.tagsMedicalCondition = tagsMedicalCondition;
            this.recipeName = recipeName;
        }

        public string TagsMedicalCondition
        {
            get
            {
                return tagsMedicalCondition;
            }

            set
            {
                tagsMedicalCondition = value;
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
        public int InsertRecipe_MedicalCondition(string RecipeName, string MedicalCondition)
        {
            int result = 0;
            string queryStr = "INSERT INTO Recipe_MedicalCondition(RecipeName,MedicalCondition)" + "values (@RecipeName,@MedicalCondition)";
            SqlConnection conn = new SqlConnection(_connStr); SqlCommand cmd = new SqlCommand(queryStr, conn);

            cmd.Parameters.AddWithValue("@RecipeName", RecipeName);
            cmd.Parameters.AddWithValue("@MedicalCondition", MedicalCondition);


            conn.Open();
            result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
            conn.Close();
            return result;
        }
        public TailoredMadeRecipes RetrieveMedicalCondition(string recipeName)
        {
            TailoredMadeRecipes tmrList = null;
          
            string medicalCondition;
            string queryStr = "SELECT * From Recipe_MedicalCondition where RecipeName = @RecipeName";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@RecipeName", recipeName);
            SqlDataReader dr = cmd.ExecuteReader();
            //Continue to read the resultsets row by row if not the end
            if (dr.Read())
            {
                medicalCondition = dr["MedicalCondition"].ToString();
                tmrList = new TailoredMadeRecipes(medicalCondition);
                
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return tmrList;
        }
        public List<TailoredMadeRecipes> RetrieveRecipeNameByMedicalCondition(string medicalCondition)
        {
            TailoredMadeRecipes tmr = null;
            List<TailoredMadeRecipes> tmrList = new List<TailoredMadeRecipes>();
            string recipeName;
            string queryStr = "SELECT * From Recipe_MedicalCondition where MedicalCondition= @MedicalCondition";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@MedicalCondition", medicalCondition);
            SqlDataReader dr = cmd.ExecuteReader();
            //Continue to read the resultsets row by row if not the end
            while (dr.Read())
            {
                medicalCondition = dr["MedicalCondition"].ToString();
                recipeName = dr["RecipeName"].ToString();
                tmr = new TailoredMadeRecipes(medicalCondition,recipeName);
                tmrList.Add(tmr);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return tmrList;
        }

        public List<TailoredMadeRecipes> RetrieveMedicalConditionByRecipeName(string recipeName)
        {
            List<TailoredMadeRecipes> tmrList = new List<TailoredMadeRecipes>();

            string MedicalCondition;
            string queryStr = "SELECT * From Recipe_MedicalCondition where RecipeName = @RecipeName";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@RecipeName", recipeName);
            SqlDataReader dr = cmd.ExecuteReader();
            //Continue to read the resultsets row by row if not the end
            while (dr.Read())
            {
                MedicalCondition = dr["MedicalCondition"].ToString();
                TailoredMadeRecipes tmr = new TailoredMadeRecipes(MedicalCondition);
                tmrList.Add(tmr);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return tmrList;
        }
    }
}