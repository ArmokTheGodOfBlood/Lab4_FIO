using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbInteraction
{
    public static class Entities
    {
        public class Article
        {
            public string ForumId { get; set; }
            public string Title { get; set; }
            public string No { get; set; }
            public string Content { get; set; }
        }
    }
    public static class DbHandler
    {
        private static string connectionString = @"Data source=DBSRV\vip2022; Database=ShveygertKK_DebuggingArticles; Integrated Security=true";
        public static class Article
        {
            public static Entities.Article GetById(int id)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlDataReader reader = new SqlCommand($"select * from Article where threadId = {id}", connection).ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Entities.Article()
                            {
                                ForumId = reader.GetString(0),
                                Title = reader.GetString(1),
                                No = reader.GetString(2),
                                Content = reader.GetString(3)

                            };
                        }
                    }
                }
                return new Entities.Article();
            }

            public static void Insert(Entities.Article article)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand($"insert into Article (threadId, title, no, content) values ('{article.ForumId}', '{article.Title}', '{article.No}', '{article.Content}')", connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
