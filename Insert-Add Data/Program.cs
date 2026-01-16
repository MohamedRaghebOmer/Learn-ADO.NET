using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertAddData
{
    internal class Program
    {
        static string connectionString = "Server = .;Database = ContactsDB;User ID = sa; Password = 123456;";
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

        static bool InsertNewContact(ref stContact contact)
        {
            bool insertionResult = false;
            
            SqlConnection connection = new SqlConnection(connectionString);
            
            string query = @"INSERT INTO Contacts (FirstName, LastName, Email, Phone, Address, CountryID)" +
                "VALUES (@FirstName, @LastName, @Email, @Phone, @Address, @CountryID)";
            
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", contact.FirstName);
            command.Parameters.AddWithValue("@LastName", contact.LastName);
            command.Parameters.AddWithValue("@Email", contact.Email);
            command.Parameters.AddWithValue("@Phone", contact.Phone);
            command.Parameters.AddWithValue("@Address", contact.Address);
            command.Parameters.AddWithValue("@CountryID", contact.CountryID);

            try
            {
                connection.Open();
                //int rowsAffected = command.ExecuteNonQuery();
                insertionResult = (command.ExecuteNonQuery() == 1);
                
                connection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return insertionResult;
        }

        static void Main(string[] args)
        {
            stContact contact = new stContact
            {
                FirstName = "Ibrahem",
                LastName = "Abelrhaman",
                Email = "ibrahem@example.com",
                Phone = "01003242324",
                Address = "Banha",
                CountryID = 4
            };

            if (InsertNewContact(ref contact))
            {
                Console.WriteLine("Record inserted successfully.");
            }
            else
            {
                Console.WriteLine("Insertion failed");
            }
        }
    }
}
