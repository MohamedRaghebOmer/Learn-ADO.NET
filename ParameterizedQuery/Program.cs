using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;

public class Program
{
    static string conectionString = "Server=.;Database=ContactsDB;User ID=sa;Password=123456";

    static void PrintAllContactsWithFirstName(string firstName)
    {
        SqlConnection connection = new SqlConnection(conectionString);
        string query = "SELECT * FROM Contacts WHERE FirstName = @firstName";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@firstName", firstName);

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

    static void PrintAllContactsWithFirstNameAndCountryID(string firstName, int countryID)
    {
        SqlConnection connection = new SqlConnection(conectionString);
        string query = "SELECT * FROM Contacts WHERE FirstName = @firstName AND CountryID = @countryID";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@firstName", firstName);
        command.Parameters.AddWithValue("@countryID", countryID);

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

    static void Main(string[] args)
    {
        //PrintAllContactsWithFirstName("jane");
        PrintAllContactsWithFirstNameAndCountryID("jane", 1);
    }
}

