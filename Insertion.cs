using System;
using System.Data.SqlClient;
using log4net.Config;

namespace AdodotNet
{
    class Insertion
    { 
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            XmlConfigurator.Configure();

            Insert();
        }
        /// <summary>
        /// inserting data to the database
        /// establishing the connection
        /// inserting the data help of insert query
        /// </summary>
        public static void Insert()
        {
            int id;
            string name;
            int age;
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLExpress;Persist Security Info=True;User Id=sa; Password=123 ");
                con.Open();
                Console.WriteLine("Enter Id");
                id = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Enter Name");
                name = Console.ReadLine();
                Console.WriteLine("Enter Age");
                age = Convert.ToInt32(Console.ReadLine());
                string query ="Insert into employee values("+id+",'"+name+"',"+ age+")";
                SqlCommand cmd = new SqlCommand(query,con);
                cmd.ExecuteNonQuery();
                log.Info("data insertion is successful");
                con.Close();
            }
            catch(Exception e)
            {
                log.Error(e.Message);
            }
            Console.ReadLine();
        }
    }
}
