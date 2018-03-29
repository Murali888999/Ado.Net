using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using log4net.Config;

namespace AdodotNet
{
    class ReadingparticularRecord
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            XmlConfigurator.Configure();
            readrecord();
        }
        /// <summary>
        /// in this method we are reading particular record.
        /// </summary>
        public static void readrecord()
        {            
            try
            {
                SqlConnection con = new SqlConnection(@"Data source=.\SQLExpress;Persist Security Info=True;User Id=sa;Password=123");
                con.Open();
                Console.WriteLine("Enter Id");
                int id = Convert.ToInt32(Console.ReadLine());
                SqlCommand sc = new SqlCommand("select * from employee where id=" + id, con);
                SqlDataReader sdr = sc.ExecuteReader();
                while (sdr.Read())
                {
                    Console.WriteLine(sdr["id"] + "" + sdr["name"] + "" + sdr["age"]);
                }
                
                con.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
