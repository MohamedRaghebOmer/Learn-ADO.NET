using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateData
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

        // send by ref to avoid coping large size of data
        static bool UpdateRecored(int contactID, ref stContact newContact)
        {
            bool recordUpdated = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"UPDATE Contacts
                            SET 
                                FirstName = @firstName,
                                LastName = @lastName,
                                Email = @email,
                                Phone = @phone,
                                Address = @address,
                                CountryID = @countryID
                            WHERE ContactID = @contactID";
            
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@firstName", newContact.FirstName);
            command.Parameters.AddWithValue("@lastName", newContact.LastName);
            command.Parameters.AddWithValue("@email", newContact.Email);
            command.Parameters.AddWithValue("@phone", newContact.Phone);
            command.Parameters.AddWithValue("@address", newContact.Address);
            command.Parameters.AddWithValue("@countryID", newContact.CountryID);
            command.Parameters.AddWithValue("@contactID", contactID);

            try
            {
                connection.Open();
                recordUpdated = (command.ExecuteNonQuery() == 1);
                connection.Close();
            }
            catch(Exception)
            {
                // Backend method: just return false, no printing
                return false;
            }
            return recordUpdated;
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

            if (UpdateRecored(1, ref contact))
            {
                Console.WriteLine("Record updated successfully.");
            }
            else
            {
                Console.WriteLine("update failed");

            }
        }
    }
}
