using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace RetrieveAutoNumber
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

        static bool InsertNewContact(ref stContact contact, out int insertedIdentity)
        {
            bool insertionResult = false;
            // Assign a default value to the out parameter to
            // avoid an error if an exception occurs before the real value is set
            insertedIdentity = 0; 

            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"INSERT INTO Contacts (FirstName, LastName, Email, Phone, Address, CountryID)
                            VALUES (@FirstName, @LastName, @Email, @Phone, @Address, @CountryID);
                            SELECT SCOPE_IDENTITY();";

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
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out insertedIdentity))
                {
                    insertionResult = true;
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return insertionResult;
        }

        static void Main(string[] args)
        {
            int id;
            stContact contact = new stContact
            {
                FirstName = "Ibrahem",
                LastName = "Abelrhaman",
                Email = "ibrahem@example.com",
                Phone = "01003242324",
                Address = "Banha",
                CountryID = 4
            };

            if (InsertNewContact(ref contact, out id))
            {
                Console.WriteLine($"Record id is {id}.");
            }
            else
            {
                Console.WriteLine("Insertion failed");

            }
        }
    }
}
