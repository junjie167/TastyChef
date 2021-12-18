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
    public class CustomerRegistrationClass
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string gender { get; set; }
        public DateTime dob { get; set; }
        public int age { get; set; }
        public string mobile { get; set; }
        public string house { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string postal { get; set; }
        public string add { get; set; }
        public string unitnumber { get; set; }
        public int deliveryid { get; set; }
        public string fulladdress { get; set; }



        public CustomerRegistrationClass()
        {

        }


        public CustomerRegistrationClass(string firstname, string lastname, string gen, DateTime birthday, int birth, string mobilenum, string housenum, string emailaddress, string pass)
        {
            this.fname = firstname;
            this.lname = lastname;
            this.gender = gen;
            this.dob = birthday;
            this.age = birth;
            this.mobile = mobilenum;
            this.house = housenum;
            this.email = emailaddress;
            this.password = pass;
        }

        public CustomerRegistrationClass(string postalcode, string address, string unit)
        {
            this.postal = postalcode;
            this.add = address;
            this.unitnumber = unit;
        }


        public int createCustomer(string email, string first, string last, string gender, DateTime dob, string postal, string address, string unit, string mobile, string home, string pass, int age)
        {
            int result = 0;
            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;
            StringBuilder sqlcomm = new StringBuilder();
            sqlcomm.AppendLine("INSERT INTO Customer(EmailAddress, FirstName, LastName, Gender, DOB, PostalCode, HomeAddress, UnitNumber, MobileNumber, HomeNumber, Password, Age)");
            sqlcomm.AppendLine("VALUES(@paraemail, @parafirst, @paralast, @paragender, @paradob, @parapostal, @paraaddress, @paraunit, @paramobile, @parahome, @parapass, @paraage)");

            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlCommand sqlCmd = new SqlCommand(sqlcomm.ToString(), myConn);

                sqlCmd.Parameters.AddWithValue("@paraemail", email);
                sqlCmd.Parameters.AddWithValue("@parafirst", first);
                sqlCmd.Parameters.AddWithValue("@paralast", last);
                sqlCmd.Parameters.AddWithValue("@paragender", gender);
                sqlCmd.Parameters.AddWithValue("@paradob", dob);
                sqlCmd.Parameters.AddWithValue("@parapostal", postal);
                sqlCmd.Parameters.AddWithValue("@paraaddress", address);
                sqlCmd.Parameters.AddWithValue("@paraunit", unit);
                sqlCmd.Parameters.AddWithValue("@paramobile", mobile);
                sqlCmd.Parameters.AddWithValue("@parahome", home);
                sqlCmd.Parameters.AddWithValue("@parapass", pass);
                sqlCmd.Parameters.AddWithValue("@paraage", age);
              

                myConn.Open();
                result = sqlCmd.ExecuteNonQuery();

                //Step 5: Close connection
                myConn.Close();
            }
            catch (Exception e)
            {
                result = 0;
            }
            return result;
        }

        public int createDeliveryAddress(string email, string postal, string address, string unitnumber)
        {
            int result = 0;
            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;
            StringBuilder sqlcomm = new StringBuilder();
            sqlcomm.AppendLine("INSERT INTO CustomerDeliveryAddress(EmailAddress, PostalCode, Address, UnitNumber)");
            sqlcomm.AppendLine("VALUES(@paraemail, @parapostal, @paraaddress, @paraunit)");

            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlCommand sqlCmd = new SqlCommand(sqlcomm.ToString(), myConn);

                sqlCmd.Parameters.AddWithValue("@paraemail", email);
                sqlCmd.Parameters.AddWithValue("@parapostal", postal);
                sqlCmd.Parameters.AddWithValue("@paraaddress", address);
                sqlCmd.Parameters.AddWithValue("@paraunit", unitnumber);


                myConn.Open();
                result = sqlCmd.ExecuteNonQuery();

                //Step 5: Close connection
                myConn.Close();
            }
            catch (Exception e)
            {
                result = 0;
            }
            return result;
        }




        public Boolean checkuser(string user, string pass)
        {

            Boolean result = false;

            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;

            DataSet ds = new DataSet();

            DataTable tdData = new DataTable();

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("SELECT * From Customer");
            sqlCommand.AppendLine("where EmailAddress = @paraUser");
            sqlCommand.AppendLine("and Password = @paraPassw");

            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlDataAdapter da;
                da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
                da.SelectCommand.Parameters.AddWithValue("@paraUser", user);
                da.SelectCommand.Parameters.AddWithValue("@paraPassw", pass);

                da.Fill(ds, "tdTable");

                int rec_cnt = ds.Tables["tdTable"].Rows.Count;
                if (rec_cnt > 0)
                {
                    result = true;

                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }


        public List<CustomerRegistrationClass> retrieveCustomer(string email)
        {
            List<CustomerRegistrationClass> list = new List<CustomerRegistrationClass>();
            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;

            DataTable tdTable = new DataTable();
            DataSet ds = new DataSet();

            StringBuilder sqlcom = new StringBuilder();
            sqlcom.AppendLine("SELECT * FROM Customer");
            sqlcom.AppendLine("WHERE EmailAddress=@paraemail");

            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlDataAdapter da;
                da = new SqlDataAdapter(sqlcom.ToString(), myConn);
                da.SelectCommand.Parameters.AddWithValue("@paraemail", email);


                da.Fill(ds, "tdTable");

                int rec_cnt = ds.Tables["tdTable"].Rows.Count;
                int num = rec_cnt;
                if (num > 0)
                {
                    for (int z = 0; z < num; z++)
                    {
                        DataRow row = ds.Tables["tdTable"].Rows[z];
                        CustomerRegistrationClass l = new CustomerRegistrationClass();
                        l.fname = row["FirstName"].ToString();
                        l.lname = row["LastName"].ToString();
                        l.gender = row["Gender"].ToString();
                        l.dob = DateTime.Parse(row["DOB"].ToString());
                        l.postal = row["PostalCode"].ToString();
                        l.add = row["HomeAddress"].ToString();
                        l.unitnumber = row["UnitNumber"].ToString();
                        l.mobile = row["MobileNumber"].ToString();
                        l.house = row["HomeNumber"].ToString();
                        l.age = int.Parse(row["Age"].ToString());
                        list.Add(l);
                    }
                }
            }
            catch (Exception e)
            {
                list = null;
            }
            return list;
        }

        //Retrieve Customer Delivery Address
        public List<CustomerRegistrationClass> retrieveCustomerDelivery(string email)
        {
            List<CustomerRegistrationClass> list = new List<CustomerRegistrationClass>();
            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;

            DataTable tdTable = new DataTable();
            DataSet ds = new DataSet();

            StringBuilder sqlcom = new StringBuilder();
            sqlcom.AppendLine("SELECT * FROM CustomerDeliveryAddress");
            sqlcom.AppendLine("WHERE EmailAddress=@paraemail");

            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlDataAdapter da;
                da = new SqlDataAdapter(sqlcom.ToString(), myConn);
                da.SelectCommand.Parameters.AddWithValue("@paraemail", email);


                da.Fill(ds, "tdTable");

                int rec_cnt = ds.Tables["tdTable"].Rows.Count;
                int num = rec_cnt;
                if (num > 0)
                {
                    for (int z = 0; z < num; z++)
                    {
                        DataRow row = ds.Tables["tdTable"].Rows[z];
                        CustomerRegistrationClass l = new CustomerRegistrationClass();
                        l.deliveryid = int.Parse(row["Id"].ToString());
                        l.postal = row["PostalCode"].ToString();
                        l.add = row["Address"].ToString();
                        l.unitnumber = row["UnitNumber"].ToString();
                        l.fulladdress = l.add + " #" + l.unitnumber +"\n" +"Singapore(" + l.postal + ")"; 
                        list.Add(l);
                    }
                }
            }
            catch (Exception e)
            {
                list = null;
            }
            return list;
        }

        //UPDATE customer basic profile
        public int updateCusstomerdetails(string first, string last, DateTime dob, string gender, string mobile, string home, int age, string email , string postal, string add, string u)
        {
            int result = 0;
            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;
            StringBuilder sqlcomm = new StringBuilder();
            sqlcomm.AppendLine("UPDATE Customer SET  FirstName = @parafname, LastName =@paralname, Gender= @paragender, DOB = @paradob, MobileNumber = @paramobile, HomeNumber = @parahome,  Age =@paraage, PostalCode = @parapostal, HomeAddress =@paradd, UnitNumber = @parau");
            sqlcomm.AppendLine("WHERE EmailAddress = @paraemail");

            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlCommand sqlCmd = new SqlCommand(sqlcomm.ToString(), myConn);

                sqlCmd.Parameters.AddWithValue("@parafname", first);
                sqlCmd.Parameters.AddWithValue("@paralname", last);
                sqlCmd.Parameters.AddWithValue("@paragender", gender);
                sqlCmd.Parameters.AddWithValue("@paradob", dob);
                sqlCmd.Parameters.AddWithValue("@paramobile", mobile);
                sqlCmd.Parameters.AddWithValue("@parahome", home);
                sqlCmd.Parameters.AddWithValue("@paraage", age);
                sqlCmd.Parameters.AddWithValue("@paraemail", email);
                sqlCmd.Parameters.AddWithValue("@parapostal", postal);
                sqlCmd.Parameters.AddWithValue("@paradd", add);
                sqlCmd.Parameters.AddWithValue("@parau", u);



                myConn.Open();
                result = sqlCmd.ExecuteNonQuery();

                //Step 5: Close connection
                myConn.Close();
            }
            catch (Exception e)
            {
                result = 0;
            }
            return result;
        }

        //Update Customer Delivery Address
        public int updatedelivery(string email, string postal, string address, string unit, int id)
        {
            int result = 0;
            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;
            StringBuilder sqlcomm = new StringBuilder();
            sqlcomm.AppendLine("UPDATE CustomerDeliveryAddress SET  PostalCode = @parapostal, Address = @paraadd, UnitNumber = @paraunit");
            sqlcomm.AppendLine("WHERE EmailAddress = @paraemail AND Id = @paraid");

            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlCommand sqlCmd = new SqlCommand(sqlcomm.ToString(), myConn);

                sqlCmd.Parameters.AddWithValue("@parapostal", postal);
                sqlCmd.Parameters.AddWithValue("@paraadd", address);
                sqlCmd.Parameters.AddWithValue("@paraunit", unit);
                sqlCmd.Parameters.AddWithValue("@paraemail", email);
                sqlCmd.Parameters.AddWithValue("@paraid", id);



                myConn.Open();
                result = sqlCmd.ExecuteNonQuery();

                //Step 5: Close connection
                myConn.Close();
            }
            catch (Exception e)
            {
                result = 0;
            }
            return result;
        }

        //Delete Customer Delivery Address
        public int removeAddress (string email, int id)
        {
            String DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;
            StringBuilder sqlComm = new StringBuilder();
            int result = 0;

            sqlComm.AppendLine("DELETE FROM CustomerDeliveryAddress");
            sqlComm.AppendLine("WHERE Id=@paraid AND EmailAddress=@paraemail");

            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlCommand cmd = new SqlCommand(sqlComm.ToString(), myConn);


                cmd.Parameters.AddWithValue("@paraid", id);
                cmd.Parameters.AddWithValue("@paraemail", email);

                myConn.Open();
                result = cmd.ExecuteNonQuery();
                myConn.Close();
            }
            catch (Exception e)
            {
                result = 0;
            }
            return result;
        }

        //Check Email Address
        public Boolean checkEmail(string email)
        {
            Boolean result = false;

            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;

            DataSet ds = new DataSet();

            DataTable tdData = new DataTable();

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("SELECT * From Customer");
            sqlCommand.AppendLine("where EmailAddress = @paraUser");

            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlDataAdapter da;
                da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
                da.SelectCommand.Parameters.AddWithValue("@paraUser", email);

                da.Fill(ds, "tdTable");

                int rec_cnt = ds.Tables["tdTable"].Rows.Count;
                if (rec_cnt > 0)
                {
                    result = true;

                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

    }
}