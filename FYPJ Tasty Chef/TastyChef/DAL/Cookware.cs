using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace TastyChef.DAL
{
    public class Cookware
    {
        private string name;
        private string image;

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

        public Cookware(string name, string image)
        {
            this.Name = name;
            this.Image = image;
        }
        public Cookware()
        {

        }

        public Cookware(string name)
        {
            this.name = name;
        }

        string _connStr = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;

        public List<Cookware> RetriveAllCooking()
        {
            List<Cookware> CookingEquipmentsList = new List<Cookware>();

            string name;
            string image;



            string queryStr = "SELECT * FROM CookingEquipments";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            //Continue to read the resultsets row by row if not the end
            while (dr.Read())
            {

                name = dr["Name"].ToString();

                image = dr["Image"].ToString();




                Cookware ce = new Cookware(name, image);
                CookingEquipmentsList.Add(ce);


            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return CookingEquipmentsList;
        }
        //Insert Method
        public int InsertCookware(string RecipeName, string EquipmentName)
        {
            int result = 0;
            string queryStr = "INSERT INTO Recipe_CookingEquipments(RecipeName,EquipmentName)" + "values (@RecipeName,@EquipmentName)";
            SqlConnection conn = new SqlConnection(_connStr); SqlCommand cmd = new SqlCommand(queryStr, conn);

            cmd.Parameters.AddWithValue("@RecipeName", RecipeName);
            cmd.Parameters.AddWithValue("@EquipmentName", EquipmentName);
      
            conn.Open();
            result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
            conn.Close();
            return result;
        }
        public List<Cookware> RetrieveCookWareByRecipeName(string recipeName)
        {

            string queryStr = "SELECT * FROM Recipe_CookingEquipments WHERE RecipeName = @RecipeName";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            List<Cookware> rList = new List<Cookware>();

         
           
            string EquipmentName;



            conn.Open();
            cmd.Parameters.AddWithValue("@RecipeName", recipeName);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                EquipmentName = dr["EquipmentName"].ToString();

                Cookware c = new Cookware(EquipmentName);

                rList.Add(c);
            }
            conn.Close();
            dr.Close();
            dr.Dispose();
            return rList;
        }
    }
}