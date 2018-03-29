using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using log4net.Config;

namespace AdodotNet
{
    class Updatedata
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            XmlConfigurator.Configure();
            update();
        }
        /// <summary>
        /// update the data from the database
        /// using update query
        /// </summary>
        public static void update()
        {
            try
            {
                Console.WriteLine("Enter id");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter name");
                string name = Console.ReadLine();
                string query = "update employee set name='" + name + "' where id=" + id;
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLExpress;Persist Security Info=True; User Id=sa;Password=123");
                con.Open();               
                SqlCommand sc = new SqlCommand(query, con);
                sc.ExecuteNonQuery();
                log.Info("updation is successful"+id);
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
