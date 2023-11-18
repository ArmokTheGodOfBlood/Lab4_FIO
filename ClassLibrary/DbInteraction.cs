using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public static class Entities
    {
        public class Article
        {
            public int? Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
        }
    }
    public static class DbHandler
    {
        private static string connectionString = "Data source = DBSRV\vip2022; Database = ";
        public static class Article
        {
            public static Entities.Article GetById(int id)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlDataReader reader = new SqlCommand("", connection).ExecuteReader())
                    {

                    }
                }
                return new Entities.Article();
            }
        }
    }
}
