using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using log4net.Config;
namespace AdodotNet
{
    class ADOCRUD
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// this Method will create table
        /// table name is employee
        /// </summary> 
        public static void Create()
        {
            try
            {
                log.Info("creating a table");
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLExpress;Persist Security Info=Treu;User Id=sa;Password=123");
                con.Open();
                string query = "create table emp";
                SqlCommand sc = new SqlCommand(query, con);
                sc.ExecuteNonQuery();
                Console.WriteLine("table created");
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
        }
        /// <summary>
        /// inserting data to the database
        /// establishing the connection
        /// inserting the data help of insert query
        /// </summary>
        public static void Insert()
        {
            try
            {
                Console.WriteLine("Inserting records");
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLExpress;Persist Security Info=Treu;User Id=sa;Password=123");
                con.Open();
                Console.WriteLine("Enter Id");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enetr Name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Age");
                int age = Convert.ToInt32(Console.ReadLine());
                string query = "insert into emp values(" + id + "," + name + "," + age + ")";
                SqlCommand sc = new SqlCommand(query, con);
                sc.ExecuteNonQuery();
                Console.WriteLine("inertion is successful");
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
        }
        /// <summary>
        /// delete the data from the database
        /// using delete query
        /// </summary>
        public static void Delete()
        {
            try
            {
                Console.WriteLine("Deleting records");
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLExpress;Persist Security Info=Treu;User Id=sa;Password=123");
                con.Open();
                Console.WriteLine("Enter Id");
                int id = Convert.ToInt32(Console.ReadLine());
                string query = "delete from emp where id=" + id;
                SqlCommand sc = new SqlCommand(query, con);
                sc.ExecuteNonQuery();
                Console.WriteLine("deletion is successful");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// update the data from the database
        /// using update query
        /// </summary>
        public static void Update()
        {
            try
            {
                log.Info("Updating a records");
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLExpress;Persist Security Info=Treu;User Id=sa;Password=123");
                con.Open();
                log.Info("Enetr Name");
                string name = Console.ReadLine();
                log.Info("Enter Id");
                int id = Convert.ToInt32(Console.ReadLine());
                string query = "update  emp set name='" + name + "'where id=" + id;
                SqlCommand sc = new SqlCommand(query, con);
                sc.ExecuteNonQuery();
                Console.WriteLine("updation is successful");
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
        }
        /// <summary>
        /// read or retrive the data from database
        /// using select query
        /// </summary>
        public static void Retrieve()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLExpress;Persist Security Info=True;User Id=sa;Password=123");
                SqlCommand cm = new SqlCommand("Select * from employee", con);
                con.Open();
                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    Console.WriteLine(sdr["id"] + " " + sdr["name"] + " " + sdr["age"]);
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// main method it calls the all static method
        /// by the help of the swicth cases
        /// create(),insert(),delete(),update() and read() method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Creating data = create");
            Console.WriteLine("Inserting data = insert");
            Console.WriteLine("Deleting data = delete");
            Console.WriteLine("Updating data = update");
            Console.WriteLine("Reading data = read");
            string s1 = Console.ReadLine();
            switch (s1.ToUpper())
            {
                case "CREATE":
                    Create();
                    break;
                case "INSERT":
                    Insert();
                    break;
                case "DELETE":
                    Delete();
                    break;
                case "UPDATE":
                    Update();
                    break;
                case "RETRIEVE":
                    Retrieve();
                    break;
                default:
                    Console.WriteLine("write properly");
                    Main(args);
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("operation Complete");
            Console.WriteLine("if u want to continue? pls enter yes or no");
            string s2 = Console.ReadLine();
            if ((s2.ToUpper()).Equals("YES"))
            {
                Main(args);
            }
            Console.ReadKey();
        }
       
    }
}
