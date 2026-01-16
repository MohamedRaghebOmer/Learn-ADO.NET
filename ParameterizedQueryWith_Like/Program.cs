using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ParameterizedQueryWith_Like
{
    internal class Program
    {
        static string connectionString = "Server=.;Database=ContactsDB;User ID=sa;Password=123456";
        static void SearchContactsStartsWith(string start)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Contacts WHERE FirstName LIKE @start + '%'";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@start", start);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    int ContactID = (int)reader["ContactID"];
                    string FirstName = (string)reader["FirstName"];
                    string LastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int CountryID = (int)reader["CountryID"];


                    Console.WriteLine($"ContactID: {ContactID}");
                    Console.WriteLine($"FirstName: {FirstName}");
                    Console.WriteLine($"LastName: {LastName}");
                    Console.WriteLine($"Email: {email}");
                    Console.WriteLine($"Phone: {phone}");
                    Console.WriteLine($"Address: {address}");
                    Console.WriteLine($"CountryID: {CountryID}\n");
                }

                connection.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        static void SearchContactsEndsWith(string end)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Contacts WHERE FirstName LIKE '%' + @end";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@end", end);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    int ContactID = (int)reader["ContactID"];
                    string FirstName = (string)reader["FirstName"];
                    string LastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int CountryID = (int)reader["CountryID"];


                    Console.WriteLine($"ContactID: {ContactID}");
                    Console.WriteLine($"FirstName: {FirstName}");
                    Console.WriteLine($"LastName: {LastName}");
                    Console.WriteLine($"Email: {email}");
                    Console.WriteLine($"Phone: {phone}");
                    Console.WriteLine($"Address: {address}");
                    Console.WriteLine($"CountryID: {CountryID}\n");
                }
                connection.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        static void SearchContactsContains(string str)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Contacts WHERE FirstName LIKE '%' + @str + '%'";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@str", str);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    int ContactID = (int)reader["ContactID"];
                    string FirstName = (string)reader["FirstName"];
                    string LastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int CountryID = (int)reader["CountryID"];


                    Console.WriteLine($"ContactID: {ContactID}");
                    Console.WriteLine($"FirstName: {FirstName}");
                    Console.WriteLine($"LastName: {LastName}");
                    Console.WriteLine($"Email: {email}");
                    Console.WriteLine($"Phone: {phone}");
                    Console.WriteLine($"Address: {address}");
                    Console.WriteLine($"CountryID: {CountryID}\n");
                }
                connection.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Ends with (ne)----------------------------");
            SearchContactsEndsWith("ne");
            Console.WriteLine("Starts with(m)----------------------------");
            SearchContactsStartsWith("m");
            Console.WriteLine("Contains (ae)----------------------------");
            SearchContactsContains("ae");
        }
    }
}
