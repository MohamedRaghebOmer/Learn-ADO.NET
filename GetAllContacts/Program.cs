using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;

public class Program
{
    static string connectionstring = "server=.;database=ContactsDB;user id=sa;password=123456";
    static void PrintAllContacts()
    {
        SqlConnection connection = new SqlConnection(connectionstring);
        string query = "SELECT * FROM Contacts";
        SqlCommand command = new SqlCommand(query, connection);

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
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
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

        
    public static void Main()
    {
        PrintAllContacts();
    }
}
