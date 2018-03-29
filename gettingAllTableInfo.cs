using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using log4net.Config;

namespace AdodotNet
{
    class gettingAllTableInfo
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            XmlConfigurator.Configure();
            Retrieve();
        }
        /// <summary>
        /// In this method we getting full content of table,by entering table Name
        /// </summary>
        public static void Retrieve()
        {
            try
            {
                string constring = @"Data Source=.\SQLExpress; Persist Security Info=True;User Id=sa;Password=123";
                SqlConnection con = new SqlConnection(constring);
                con.Open();
                Console.WriteLine("enter table name");
                string tname = Console.ReadLine();
                SqlCommand sc = new SqlCommand("select * from "+tname , con);
                SqlDataReader sdr = sc.ExecuteReader();
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    Console.Write(sdr.GetName(i), "\t");
                }
                Console.WriteLine();
                Console.WriteLine("-------------");
                while (sdr.Read())
                {
                    Console.WriteLine(sdr["id"] + "" + sdr["name"] + "" + sdr["age"]);
                }
                con.Close();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
            Console.ReadLine();
        }
    }
}
