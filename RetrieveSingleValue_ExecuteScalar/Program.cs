using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrieveSingleValue_ExecuteScalar
{
    internal class Program
    {
        static string connectionString = "Server=.;Database=ContactsDB;User ID=sa;Password=123456";
        static string GetFirstName(int contactID)
        {
            string firstName = "";
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT FirstName FROM Contacts WHERE ContactID = @ContactID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ContactID", contactID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    firstName = result.ToString();
                }
                
                connection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return firstName;
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine(GetFirstName(1));
        }
    }
}
