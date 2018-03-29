using System;
using System.Data.SqlClient;
using System.Net;
using log4net;
using log4net.Config;
namespace AdodotNet
{   
    class CreatingTable
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
               
        static void Main(string[] args)
        {
            XmlConfigurator.Configure();
            create();
        }
        /// <summary>
        /// this Method will create table
        /// table name is employee
        /// </summary> 
        public static void create()
        {           
            try
            {              
                SqlConnection   con = new SqlConnection(@"Data Source=.\SQLExpress;Persist Security Info=True;User ID=sa;Password=123");
                //opening  connection
                con.Open();
                //writing SQL Quer
                string s1 = "create table employee(id int,name varchar(90),age int)";
                SqlCommand sc = new SqlCommand(s1, con);
                //Executing Sql Query
                sc.ExecuteNonQuery();
                log.Info(" employee Table is created");
                con.Close();
            }
            catch (Exception e)
            {
                log.Error(e);
                Console.WriteLine(e);
            }
            Console.ReadLine();
        }
    }
}