using System;
using System.Data.SqlClient;

namespace PrettyHair
{
    public class User
    {
        SqlConnection conn = new SqlConnection("Server=ealdb1.eal.local; Database=ejl81_db; User Id=ejl81_usr; Password=Baz1nga81");
        public User(string un, string pw, object rg)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_INSERT_USER", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@USERNAME", un));
                cmd.Parameters.Add(new SqlParameter("@PASSWORD", pw));
                cmd.Parameters.Add(new SqlParameter("@USER_RIGHTS", rg));
                cmd.ExecuteNonQuery();
                Username = un;
                Password = pw;
                Rights = rg;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message.ToString());
                Console.ReadKey();
            }
            finally
            {
                conn.Close();
            }
        }

        public string Password { get; set; }
        public object Rights { get; internal set; }
        public string Username { get; set; }
        public Inbox Inbox { get; internal set; }
    }
}
