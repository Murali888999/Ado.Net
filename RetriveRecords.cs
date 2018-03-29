using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using log4net;
using log4net.Config;

namespace AdodotNet
{
    class RetrieveRecords
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            XmlConfigurator.Configure();
            retrieve();
        }
        /// <summary>
        /// read or retrive the data from database
        /// using select query
        /// </summary>
        public static void retrieve()
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
    }
}
