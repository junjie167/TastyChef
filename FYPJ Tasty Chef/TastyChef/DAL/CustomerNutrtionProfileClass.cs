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
    public class CustomerNutrtionProfileClass
    {
        //Nutrition Group
        public int nutritiongroupid { get; set; }
        public string nutritiongroupname { get; set; }
        public string nutritiongroupmedical { get; set; }
        public string nutritiongroupdiettype { get; set; }
        public string nutritiongroupallergy { get; set; }

        //email
        public string email { get; set; }

        //Nutrition Profile
        public decimal height { get; set; }
        public decimal weight { get; set; }
        public string weightstatus { get; set; }
        public decimal bmi { get; set; }
        public decimal bmr { get; set; }
        public string activitylevel { get; set; }
        public decimal calories { get; set; }
        public string proteinrange { get; set; }
        public string carbohydraterange { get; set; }
        public string fatsrange { get; set; }
        public string levelcarbohydrate { get; set; }
        public string macronutrient { get; set; }
        public int percent { get; set; }

        //Diet Profile
        public string diettype { get; set; }
        public string allergy { get; set; }
        public string avoid { get; set; }
        public int meal { get; set; }
        public int snack { get; set; }

        //Medical Condition Profile
        public string medical { get; set; }
        public decimal glucose { get; set; }

        //Allengies
        public string allengyies { get; set; }
        

        public CustomerNutrtionProfileClass()
        {

        }

        public CustomerNutrtionProfileClass(string email, string carbohydraterange,string proteinrange, string fatrange, decimal calories, string activity, decimal bmi, decimal bmr, decimal height, decimal weight, string weightstatus, string level)
        {
            this.email = email;
            this.carbohydraterange = carbohydraterange;
            this.proteinrange = proteinrange;
            this.fatsrange = fatrange;
            this.calories = calories;
            this.activitylevel = activity;
            this.bmi = bmi;
            this.bmr = bmr;
            this.height = height;
            this.weight = weight;
            this.weightstatus = weightstatus;
            this.levelcarbohydrate = level;
        }

        public CustomerNutrtionProfileClass(string diettype, string allergy, string avoid, int meal, int snack, string email)
        {
            this.diettype = diettype;
            this.allengyies = allergy;
            this.avoid = avoid;
            this.meal = meal;
            this.snack = snack;
            this.email = email;
        }

        public CustomerNutrtionProfileClass(string medical, decimal glucose, string email)
        {
            this.medical = medical;
            this.glucose = glucose;
            this.email = email;
        }

        public CustomerNutrtionProfileClass(int id, string group, string medical, string diet)
        {
            this.nutritiongroupid = id;
            this.nutritiongroupname = group;
            this.nutritiongroupmedical = medical;
            this.nutritiongroupdiettype = diet;
        }

        public CustomerNutrtionProfileClass(string allergy)
        {
            this.nutritiongroupallergy = allergy;
        }

        //Check Existing customer nutrition profile
        public Boolean checkNutritionProfile(string email)
        {
            Boolean result = false;

            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;

            DataSet ds = new DataSet();

            DataTable tdData = new DataTable();

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("SELECT * From CustomerNutritionProfile");
            sqlCommand.AppendLine("where EmailAddress = @paraemail");

            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlDataAdapter da;
                da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
                da.SelectCommand.Parameters.AddWithValue("@paraemail", email);


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

        //Retrieve Nutrition group condition
        public List<CustomerNutrtionProfileClass> retrieveNutrition()
        {
            List<CustomerNutrtionProfileClass> list = new List<CustomerNutrtionProfileClass>();
            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;

            DataTable tdTable = new DataTable();
            DataSet ds = new DataSet();

            StringBuilder sqlcom = new StringBuilder();
            sqlcom.AppendLine("SELECT * FROM NutritionGroup");

            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlDataAdapter da;
                da = new SqlDataAdapter(sqlcom.ToString(), myConn);
               


                da.Fill(ds, "tdTable");

                int rec_cnt = ds.Tables["tdTable"].Rows.Count;
                int num = rec_cnt;
                if (num > 0)
                {
                    for (int z = 0; z < num; z++)
                    {
                        DataRow row = ds.Tables["tdTable"].Rows[z];
                        CustomerNutrtionProfileClass l = new CustomerNutrtionProfileClass();
                        l.nutritiongroupid = int.Parse(row["NutritionGroupID"].ToString());
                        l.nutritiongroupname = row["Name"].ToString();
                        l.nutritiongroupmedical = row["MedicalCondition"].ToString();
                        l.nutritiongroupdiettype = row["DietType"].ToString();                        
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

        //Retrieve NutritonGroup for food allergy
        public List<CustomerNutrtionProfileClass> retrieveNutritionGroupAllergy(int id)
        {
            List<CustomerNutrtionProfileClass> list = new List<CustomerNutrtionProfileClass>();
            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;

            DataTable tdTable = new DataTable();
            DataSet ds = new DataSet();

            StringBuilder sqlcom = new StringBuilder();
            sqlcom.AppendLine("SELECT * FROM NutritionGroup_FoodAllergies");
            sqlcom.AppendLine("WHERE NutritionGroupID = @paraid");

            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlDataAdapter da;
                da = new SqlDataAdapter(sqlcom.ToString(), myConn);
                da.SelectCommand.Parameters.AddWithValue("@paraid", id);


                da.Fill(ds, "tdTable");

                int rec_cnt = ds.Tables["tdTable"].Rows.Count;
                int num = rec_cnt;
                if (num > 0)
                {
                    for (int z = 0; z < num; z++)
                    {
                        DataRow row = ds.Tables["tdTable"].Rows[z];
                        CustomerNutrtionProfileClass l = new CustomerNutrtionProfileClass();
                        l.nutritiongroupid = int.Parse(row["NutritionGroupID"].ToString());
                        l.nutritiongroupallergy = row["FoodAllergyName"].ToString();
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

        //Create nutrition profile
        public int createNutritionProfile(string email, string carbointake, string proteinintake, string fatintake, decimal caloriesintake, string level, decimal bmi, decimal bmr, decimal height, decimal weight, string weightstatus, string carbolevel)
        {
            int result = 0;
            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;
            StringBuilder sqlcomm = new StringBuilder();
            sqlcomm.AppendLine("INSERT INTO CustomerNutritionProfile(EmailAddress, CarbohydratesIntake, ProteinsIntake, FatIntake, CaloriesIntake, Activeness, BMI, BMR, Height, Weight, WeightStatus, CarbohydrateLevel)");
            sqlcomm.AppendLine("VALUES(@paraemail, @paracarbo, @paraprotein, @parafat, @paracalories, @paraactive, @parabmi, @parabmr, @paraheight, @paraweight, @paraweightstatus, @paracarbolevel)");

            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlCommand sqlCmd = new SqlCommand(sqlcomm.ToString(), myConn);

                sqlCmd.Parameters.AddWithValue("@paraemail", email);
                sqlCmd.Parameters.AddWithValue("@paracarbo", carbointake);
                sqlCmd.Parameters.AddWithValue("@paraprotein", proteinintake);
                sqlCmd.Parameters.AddWithValue("@parafat", fatintake);
                sqlCmd.Parameters.AddWithValue("@paracalories", caloriesintake);
                sqlCmd.Parameters.AddWithValue("@paraactive", level);
                sqlCmd.Parameters.AddWithValue("@parabmi", bmi);
                sqlCmd.Parameters.AddWithValue("@parabmr", bmr);
                sqlCmd.Parameters.AddWithValue("@paraheight", height);
                sqlCmd.Parameters.AddWithValue("@paraweight", weight);
                sqlCmd.Parameters.AddWithValue("@paraweightstatus", weightstatus);
                sqlCmd.Parameters.AddWithValue("@paracarbolevel", carbolevel);
              

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

        //Create Customer Diet Profile
        public int createDietProfile(string diet, string allergy, string avoid, int meal, int snack, string email)
        {
            int result = 0;
            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;
            StringBuilder sqlcomm = new StringBuilder();
            sqlcomm.AppendLine("INSERT INTO CustomerDietProfile(DietType, FoodAllergy, FoodAvoidance, MealFrequency, SnackFrequency, EmailAddress)");
            sqlcomm.AppendLine("VALUES(@paradiet, @paraallergy, @paraavoid, @parameal, @parasnack, @paraemail)");

            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlCommand sqlCmd = new SqlCommand(sqlcomm.ToString(), myConn);

                sqlCmd.Parameters.AddWithValue("@paradiet", diet);
                sqlCmd.Parameters.AddWithValue("@paraallergy", allergy);
                sqlCmd.Parameters.AddWithValue("@paraavoid", avoid);
                sqlCmd.Parameters.AddWithValue("@parameal", meal);
                sqlCmd.Parameters.AddWithValue("@parasnack", snack);
                sqlCmd.Parameters.AddWithValue("@paraemail", email);
                


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

        //Create Customer Medical Profile
        public int createMedicalProfile(string medical,decimal glucose,string email)
        {
            int result = 0;
            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;
            StringBuilder sqlcomm = new StringBuilder();
            sqlcomm.AppendLine("INSERT INTO CustomerChronicDisease(MedicalCondition, GlucoseLevel, EmailAddress)");
            sqlcomm.AppendLine("VALUES(@paramedical, @paraglucose, @paraemail)");

            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlCommand sqlCmd = new SqlCommand(sqlcomm.ToString(), myConn);

                sqlCmd.Parameters.AddWithValue("@paramedical", medical);
                sqlCmd.Parameters.AddWithValue("@paraglucose", glucose);
                sqlCmd.Parameters.AddWithValue("@paraemail", email);



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

        //Retrieve Customer Nutrition Profile
        public List<CustomerNutrtionProfileClass> retrieveNutritionProfile(string email)
        {
            List<CustomerNutrtionProfileClass> list = new List<CustomerNutrtionProfileClass>();
            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;

            DataTable tdTable = new DataTable();
            DataSet ds = new DataSet();

            StringBuilder sqlcom = new StringBuilder();
            sqlcom.AppendLine("SELECT * FROM CustomerNutritionProfile");
            sqlcom.AppendLine("WHERE EmailAddress = @paraemail");

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
                        CustomerNutrtionProfileClass l = new CustomerNutrtionProfileClass();
                        l.height = Decimal.Parse(row["Height"].ToString());
                        l.weight = Decimal.Parse(row["Weight"].ToString());
                        l.weightstatus = row["WeightStatus"].ToString();
                        l.bmi = Decimal.Parse(row["BMI"].ToString());
                        l.activitylevel = row["Activeness"].ToString();
                        l.bmr = Decimal.Parse(row["BMR"].ToString());
                        l.calories = Decimal.Parse(row["CaloriesIntake"].ToString());
                        l.carbohydraterange = row["CarbohydratesIntake"].ToString();
                        l.proteinrange = row["ProteinsIntake"].ToString();
                        l.fatsrange = row["FatIntake"].ToString();
                        l.levelcarbohydrate = row["CarbohydrateLevel"].ToString();
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

        //Retrieve Customer Dietary Profile
        public List<CustomerNutrtionProfileClass> retrieveDietaryProfile(string email)
        {
            List<CustomerNutrtionProfileClass> list = new List<CustomerNutrtionProfileClass>();
            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;

            DataTable tdTable = new DataTable();
            DataSet ds = new DataSet();

            StringBuilder sqlcom = new StringBuilder();
            sqlcom.AppendLine("SELECT * FROM CustomerDietProfile");
            sqlcom.AppendLine("WHERE EmailAddress = @paraemail");

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
                        CustomerNutrtionProfileClass l = new CustomerNutrtionProfileClass();
                        l.diettype = row["DietType"].ToString();
                        l.allergy = row["FoodAllergy"].ToString();
                        l.avoid = row["FoodAvoidance"].ToString();
                        l.meal = int.Parse(row["MealFrequency"].ToString());
                        l.snack = int.Parse(row["SnackFrequency"].ToString());
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

        //Retrieve Customer Medical Condition
        public List<CustomerNutrtionProfileClass> retrieveMedicateProfile(string email)
        {
            List<CustomerNutrtionProfileClass> list = new List<CustomerNutrtionProfileClass>();
            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;

            DataTable tdTable = new DataTable();
            DataSet ds = new DataSet();

            StringBuilder sqlcom = new StringBuilder();
            sqlcom.AppendLine("SELECT * FROM CustomerChronicDisease");
            sqlcom.AppendLine("WHERE EmailAddress = @paraemail");

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
                        CustomerNutrtionProfileClass l = new CustomerNutrtionProfileClass();
                        l.medical = row["MedicalCondition"].ToString();
                        l.glucose = Decimal.Parse(row["GlucoseLevel"].ToString());
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

        //Retrieve Macronutrient Percentage
        public List<CustomerNutrtionProfileClass> retrievemacronutrient(string marcrolevel)
        {
            List<CustomerNutrtionProfileClass> list = new List<CustomerNutrtionProfileClass>();
            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;

            DataTable tdTable = new DataTable();
            DataSet ds = new DataSet();

            StringBuilder sqlcom = new StringBuilder();
            sqlcom.AppendLine("SELECT * FROM MacroPercentage");
            sqlcom.AppendLine("WHERE CarbohydrateLevel = @paralevel");

            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlDataAdapter da;
                da = new SqlDataAdapter(sqlcom.ToString(), myConn);
                da.SelectCommand.Parameters.AddWithValue("@paralevel", marcrolevel);


                da.Fill(ds, "tdTable");

                int rec_cnt = ds.Tables["tdTable"].Rows.Count;
                int num = rec_cnt;
                if (num > 0)
                {
                    for (int z = 0; z < num; z++)
                    {
                        DataRow row = ds.Tables["tdTable"].Rows[z];
                        CustomerNutrtionProfileClass l = new CustomerNutrtionProfileClass();
                        l.macronutrient = row["Macronutrients"].ToString();
                        l.percent = int.Parse(row["PERCENT"].ToString());
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


        //Update Customer Nutrition Profile
        public int updateNutritionProfile(string email, string carbointake, string proteinintake, string fatintake, decimal caloriesintake, string level, decimal bmi, decimal bmr, decimal height, decimal weight, string weightstatus, string carbolevel)
        {
            int result = 0;
            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;
            StringBuilder sqlcomm = new StringBuilder();
            sqlcomm.AppendLine("UPDATE CustomerNutritionProfile SET CarbohydratesIntake =@paracarbo,  ProteinsIntake =  @paraprotein, FatIntake = @parafat, CaloriesIntake = @paracalories,  Activeness = @paraactive, BMI = @parabmi, BMR = @parabmr, Height = @paraheight, Weight = @paraweight, WeightStatus = @paraweightstatus, CarbohydrateLevel = @paracarbolevel");
            sqlcomm.AppendLine("WHERE EmailAddress = @paraemail");

            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlCommand sqlCmd = new SqlCommand(sqlcomm.ToString(), myConn);

                sqlCmd.Parameters.AddWithValue("@paraemail", email);
                sqlCmd.Parameters.AddWithValue("@paracarbo", carbointake);
                sqlCmd.Parameters.AddWithValue("@paraprotein", proteinintake);
                sqlCmd.Parameters.AddWithValue("@parafat", fatintake);
                sqlCmd.Parameters.AddWithValue("@paracalories", caloriesintake);
                sqlCmd.Parameters.AddWithValue("@paraactive", level);
                sqlCmd.Parameters.AddWithValue("@parabmi", bmi);
                sqlCmd.Parameters.AddWithValue("@parabmr", bmr);
                sqlCmd.Parameters.AddWithValue("@paraheight", height);
                sqlCmd.Parameters.AddWithValue("@paraweight", weight);
                sqlCmd.Parameters.AddWithValue("@paraweightstatus", weightstatus);
                sqlCmd.Parameters.AddWithValue("@paracarbolevel", carbolevel);


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

        //Update Customer diet profile
        public int updateDietprofile(string diet, string allergy, string avoid, int meal, int snack, string email)
        {
            int result = 0;
            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;
            StringBuilder sqlcomm = new StringBuilder();
            sqlcomm.AppendLine("UPDATE CustomerDietProfile SET DietType = @paradiet, FoodAllergy = @paraallergy, FoodAvoidance = @paraavoid, MealFrequency = @parameal, SnackFrequency = @parasnack");
            sqlcomm.AppendLine("WHERE EmailAddress = @paraemail");

            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlCommand sqlCmd = new SqlCommand(sqlcomm.ToString(), myConn);

                sqlCmd.Parameters.AddWithValue("@paradiet", diet);
                sqlCmd.Parameters.AddWithValue("@paraallergy", allergy);
                sqlCmd.Parameters.AddWithValue("@paraavoid", avoid);
                sqlCmd.Parameters.AddWithValue("@parameal", meal);
                sqlCmd.Parameters.AddWithValue("@parasnack", snack);
                sqlCmd.Parameters.AddWithValue("@paraemail", email);



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

        //UPDATE Customer medical condition
        public int updateMedicalCondition(string medical, decimal glucose, string email)
        {
            int result = 0;
            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;
            StringBuilder sqlcomm = new StringBuilder();
            sqlcomm.AppendLine("UPDATE CustomerChronicDisease SET MedicalCondition = @paramedical, GlucoseLevel = @paraglucose");
            sqlcomm.AppendLine("WHERE EmailAddress = @paraemail");

            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlCommand sqlCmd = new SqlCommand(sqlcomm.ToString(), myConn);

                sqlCmd.Parameters.AddWithValue("@paramedical", medical);
                sqlCmd.Parameters.AddWithValue("@paraglucose", glucose);
                sqlCmd.Parameters.AddWithValue("@paraemail", email);



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

        //Retrieve Food Allergies
        public List<CustomerNutrtionProfileClass> retrieveFoodAllergy()
        {
            List<CustomerNutrtionProfileClass> list = new List<CustomerNutrtionProfileClass>();
            
            string DBConnect = ConfigurationManager.ConnectionStrings["TastyChefContext"].ConnectionString;

            DataTable tdTable = new DataTable();
            DataSet ds = new DataSet();

            StringBuilder sqlcom = new StringBuilder();
            sqlcom.AppendLine("SELECT * FROM FoodAllergies");
           

            try
            {
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlDataAdapter da;
                da = new SqlDataAdapter(sqlcom.ToString(), myConn);
                


                da.Fill(ds, "tdTable");

                int rec_cnt = ds.Tables["tdTable"].Rows.Count;
                int num = rec_cnt;
                if (num > 0)
                {
                    CustomerNutrtionProfileClass t = new CustomerNutrtionProfileClass();
                    t.allengyies = "None";
                    list.Add(t);

                    for (int z = 0; z < num; z++)
                    {
                        DataRow row = ds.Tables["tdTable"].Rows[z];
                        CustomerNutrtionProfileClass l = new CustomerNutrtionProfileClass();
                        l.allengyies = row["FoodAllergyName"].ToString();
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


    }
}