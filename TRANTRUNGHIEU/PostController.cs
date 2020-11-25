using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TranTrungHieuMidterm
{
    public class PostController
    {
        public string connectionString = "";

        public PostController(string cnn)
        {
            this.connectionString = cnn;// "LAPTOP-FRC6H98B\\SQLEXPRESS; initial catalog=18071523MIDTERM2020; Intergrated Security=True";
        }
        public int AddOnePost(PostModel OnePost)
        {
            string queryString = "Insert into POST(Title,Summary,Hcontent) values(@Title,@Summary,@Hcontent)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@Title", System.Data.SqlDbType.Text);
                command.Parameters.Add("@Summary", System.Data.SqlDbType.Text);
                command.Parameters.Add("@HContent", System.Data.SqlDbType.Text);
               
                Console.WriteLine(OnePost.Title);
                command.Parameters["@Title"].Value = OnePost.Title;
                command.Parameters["@Summary"].Value = OnePost.Summary;
                command.Parameters["@Hcontent"].Value = OnePost.Hcontent;
              
                command.Connection.Open();
                command.ExecuteNonQuery();
                

            }
            return 0;
        }
        public int DeletePost(int Id)
        {
            string queryString = "Delete from POST where Id=@Id";
            PostModel mp = new PostModel();
            using (SqlConnection connection =
                   new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                command.Parameters["@Id"].Value = Id;
                connection.Open();

                command.ExecuteNonQuery();

            }

            return 0;
        }
        public DataTable getAll(string Keyword)
        {
            string queryString = "select * from PostId where Hcontent like @Keyword";
            PostModel mp = new PostModel();
            var t = new DataTable();
            using (SqlConnection connection =
              new SqlConnection(connectionString))
            {
                SqlCommand cm = new SqlCommand(queryString, connection);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cm;
                adapter.Fill(t);
                return t;
            }

        }
        public DataTable getAll1()
        {
            string queryString = "select * from POST";
            PostModel mp = new PostModel();
            var t = new DataTable();
            using (SqlConnection connection =
              new SqlConnection(connectionString))
            {
                SqlCommand cm = new SqlCommand(queryString, connection);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cm;
                adapter.Fill(t);
                return t;
            }

        }
    }
}
