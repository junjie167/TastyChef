using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TastyChef.DAL
{
    public class Admin
    {
        private string loginID;
        private string password;
        private string name;

        public string LoginID
        {
            get
            {
                return loginID;
            }

            set
            {
                loginID = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

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
        //Default Constructor
        public Admin()
        {

        }
        //Constructor for Insert
        public Admin(string loginID,string password,string name)
        {
            this.LoginID = loginID;
            this.Password = password;
            this.Name = name;

        }
        string _connStr = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;
        //Insert Method
        public int InsertAdmin()
        {
            int result = 0;
            string queryStr = "INSERT INTO Admin(LoginID,Password,Name)" + "values (@LoginID,@Password,@Name)";
            SqlConnection conn = new SqlConnection(_connStr); SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@LoginID", this.LoginID);
            cmd.Parameters.AddWithValue("@Password", this.Password);
            cmd.Parameters.AddWithValue("@Name", this.Name);
            conn.Open();
            result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
            conn.Close();
            return result;
        }
        //Login 
        public Boolean checkAdminUser(string LoginID, string Password)
        {
            Boolean result = false;

            SqlConnection conn = new SqlConnection(_connStr);

            string queryString = "Select * FROM Admin where LoginID = @LoginID and Password = @Password";
            SqlCommand cmd = new SqlCommand(queryString, conn);
            cmd.Parameters.AddWithValue("@LoginID", LoginID);
            cmd.Parameters.AddWithValue("@Password", Password);

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
        //check if loginID exist
        public int checkLoginID(string LoginID)
        {
            int result = 0;

            SqlConnection conn = new SqlConnection(_connStr);

            string queryString = "Select * FROM Admin where LoginID = @LoginID ";
            SqlCommand cmd = new SqlCommand(queryString, conn);
            cmd.Parameters.AddWithValue("@LoginID", LoginID);


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
    }
}