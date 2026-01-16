using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net;

namespace FindSingleContact_GetOneRowFromTable
{
    internal class Program
    {
        static string connectionString = "Server=.;Database=ContactsDB;User ID = sa;Password=123456";

        public struct stContact
        {
            public int ContactID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public int CountryID { get; set; }
        }

        static bool FindContactByID(int contactID, ref stContact contact)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Contacts WHERE ContactID = @ContactID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ContactID", contactID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    contact.ContactID = (int)reader["ContactID"];
                    contact.FirstName = (string)reader["FirstName"];
                    contact.LastName = (string)reader["LastName"];
                    contact.Email = (string)reader["Email"];
                    contact.Phone = (string)reader["Phone"];
                    contact.Address = (string)reader["Address"];
                    contact.CountryID = (int)reader["CountryID"];
                    isFound = true;
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return isFound;
        }

        static void Main(string[] args)
        {
            stContact contact = new stContact();

            if (FindContactByID(1, ref contact))
            {
                Console.WriteLine(contact.ContactID);
                Console.WriteLine(contact.FirstName);
                Console.WriteLine(contact.LastName);
                Console.WriteLine(contact.Email);
                Console.WriteLine(contact.Phone);
                Console.WriteLine(contact.Address);
                Console.WriteLine(contact.CountryID);
            }
            else
            {
                Console.WriteLine("Contact not found");
            }
        }
    }
}
