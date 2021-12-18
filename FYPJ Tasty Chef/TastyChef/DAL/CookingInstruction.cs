using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TastyChef.DAL
{
    public class CookingInstruction
    {

        private int stepNumber;
     
        private string stepInstruction;
   
        private string recipeName;

        

      
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


        public string StepInstruction
        {
            get
            {
                return stepInstruction;
            }

            set
            {
                stepInstruction = value;
            }
        }

        public int StepNumber
        {
            get
            {
                return stepNumber;
            }

            set
            {
                stepNumber = value;
            }
        }

        string _connStr = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;
        //Default Constructor
        public CookingInstruction()
        {

        }

        public CookingInstruction(int stepNumber, string stepInstruction)
        {
            this.stepNumber = stepNumber;
            this.stepInstruction = stepInstruction;
           
        }

        public CookingInstruction(int stepNumber)
        {
            this.stepNumber = stepNumber;
        }

        public CookingInstruction(int stepNumber, string stepInstruction, string recipeName)
        {
            this.stepNumber = stepNumber;
            this.stepInstruction = stepInstruction;
            this.recipeName = recipeName;
        }

        //Insert Method
        public int InsertCookingInstruction(string RecipeName, int CookingStep, string CookingInsturction)
        {
            int result = 0;
            string queryStr = "INSERT INTO Recipe_CookingInstruction(RecipeName,CookingStep,CookingInstruction)" + "values (@RecipeName,@CookingStep,@CookingInstruction)";
            SqlConnection conn = new SqlConnection(_connStr); SqlCommand cmd = new SqlCommand(queryStr, conn);

            cmd.Parameters.AddWithValue("@RecipeName", RecipeName);
            cmd.Parameters.AddWithValue("@CookingStep", CookingStep);
            cmd.Parameters.AddWithValue("@CookingInstruction", CookingInsturction);

            conn.Open();
            result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
            conn.Close();
            return result;
        }
        public List<CookingInstruction> RetrieveCookingInstructionByRecipeName(string recipeName)
        {

            string queryStr = "SELECT * FROM Recipe_CookingInstruction WHERE RecipeName = @RecipeName";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            List <CookingInstruction> rList = new List<CookingInstruction>();

            string RecipeName;
            int cookingStep;
            string cookingInstruction;
            


            conn.Open();
            cmd.Parameters.AddWithValue("@RecipeName", recipeName);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                RecipeName = dr["RecipeName"].ToString();
                cookingStep = Convert.ToInt32(dr["CookingStep"].ToString());
                cookingInstruction = dr["CookingInstruction"].ToString();
               


                CookingInstruction r = new CookingInstruction(cookingStep,cookingInstruction,RecipeName);

                rList.Add(r);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return rList;
        }
    }
}