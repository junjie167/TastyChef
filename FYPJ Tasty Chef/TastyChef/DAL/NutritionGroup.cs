using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TastyChef.DAL
{
    public class NutritionGroup
    {
        private int nutritionGroupID;
        private string name;
        private string medicalCondition;
        private string dietType;
        private string foodAllergyName;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string MedicalCondition
        {
            get
            {
                return medicalCondition;
            }

            set
            {
                medicalCondition = value;
            }
        }


        public string DietType
        {
            get
            {
                return dietType;
            }

            set
            {
                dietType = value;
            }
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

        public int NutritionGroupID
        {
            get
            {
                return nutritionGroupID;
            }

            set
            {
                nutritionGroupID = value;
            }
        }

        public int NutritionGroupID1
        {
            get
            {
                return nutritionGroupID;
            }

            set
            {
                nutritionGroupID = value;
            }
        }

        //Default Constructor
        public NutritionGroup()
        {

        }
        public NutritionGroup(int groupID, string name, string medicalCondition)
        {
            this.NutritionGroupID = groupID;
            this.Name = name;
            this.MedicalCondition = medicalCondition;
        }

        public NutritionGroup(int nutritionGroupID)
        {
            this.nutritionGroupID = nutritionGroupID;
        }

        string _connStr = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;

        //Insert Method
        public int InsertNutritionGroup(string name, string medicalCondition, string dietType)
        {
            int result = 0;
            string queryStr = "INSERT INTO NutritionGroup(Name,MedicalCondition,DietType)" + "values (@Name,@MedicalCondition,@DietType)";
            SqlConnection conn = new SqlConnection(_connStr); SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@MedicalCondition", medicalCondition);
            cmd.Parameters.AddWithValue("@DietType", dietType);
            conn.Open();
            result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
            conn.Close();
            return result;
        }
        //Method that retrive the latest ProductID
        public int RetriveLatestNutritionGroupID()
        {
            int np;
            int npID;
            string queryStr = "SELECT MAX(NutritionGroupID) as currNutritionGroupID FROM NutritionGroup";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            //Continue to read the resultsets row by row if not the end
            if (dr.Read())
            {
                npID = int.Parse(dr["currNutritionGroupID"].ToString());
                np = npID;
            }
            else
            {
                np = 0;
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return np;
        }
        //Method that insert into NutritionGroup_FoodAllergies
        public int InsertNutritionGroup_FoodAllergies(int ngID, string faName)
        {
            int result = 0;
            string queryStr = "INSERT INTO NutritionGroup_FoodAllergies(NutritionGroupID,FoodAllergyName)" + "values (@NutritionGroupID,@FoodAllergyName)";
            SqlConnection conn = new SqlConnection(_connStr); SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@NutritionGroupID", ngID);
            cmd.Parameters.AddWithValue("@FoodAllergyName", faName);
            conn.Open();
            result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
            conn.Close();
            return result;
        }
        //Method that check is the condition exist in NutritionGroup Table
        public Boolean checkNutritionGroupCondition(string groupName, string medicalCondition, string dietType)
        {
            Boolean result = false;

            SqlConnection conn = new SqlConnection(_connStr);

            string queryString = "Select * FROM NutritionGroup where Name = @Name and MedicalCondition = @MedicalCondition and DietType=@DietType";
            SqlCommand cmd = new SqlCommand(queryString, conn);
            cmd.Parameters.AddWithValue("@Name", groupName);
            cmd.Parameters.AddWithValue("@MedicalCondition", medicalCondition);

            cmd.Parameters.AddWithValue("@DietType", dietType);

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
        //Method that check is the condition exist in NutritionGroup_FoodAllergies Table
        public Boolean checkNutritionGroup_FoodAllergiesCondition(int nutritionGroupID, string foodAllergyName)
        {
            Boolean result = false;

            SqlConnection conn = new SqlConnection(_connStr);

            string queryString = "Select * FROM NutritionGroup_FoodAllergies where NutritionGroupID = @NutritionGroupID and FoodAllergyName = @FoodAllergyName";
            SqlCommand cmd = new SqlCommand(queryString, conn);
            cmd.Parameters.AddWithValue("@NutritionGroupID ", nutritionGroupID);
            cmd.Parameters.AddWithValue("@FoodAllergyName", foodAllergyName);


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
        public List<NutritionGroup> RetriveAllNutritionGroup()
        {
            List<NutritionGroup> NutritionGroupList = new List<NutritionGroup>();

            int id;
            string name;
            string medicalCondition;


            string queryStr = "SELECT * FROM NutritionGroup";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            //Continue to read the resultsets row by row if not the end
            while (dr.Read())
            {

                name = dr["Name"].ToString();

                medicalCondition = dr["MedicalCondition"].ToString();


                id = int.Parse(dr["NutritionGroupID"].ToString());

                NutritionGroup nutritionGroup = new NutritionGroup(id, name, medicalCondition);
                NutritionGroupList.Add(nutritionGroup);


            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return NutritionGroupList;
        }
    }
}