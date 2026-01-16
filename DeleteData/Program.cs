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
        class clsDeleteResult
        { 
            public bool Success { get; set; }
            public string Message { get; set; }
        }
        static clsDeleteResult DeleteRecored(int contactID)
        {
            clsDeleteResult result = new clsDeleteResult();

            string query = @"DELETE FROM Contacts
                     WHERE ContactID = @contactID";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@contactID", contactID);
                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    result.Success = (rowsAffected == 1);
                    result.Message = rowsAffected == 1 
                        ? "Record deleted successfully" 
                        : "Record not found";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        static void Main(string[] args)
        {
            clsDeleteResult result = DeleteRecored(1342);

            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
