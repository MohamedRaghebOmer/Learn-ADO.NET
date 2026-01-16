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

        static clsDeleteResult DeleteRecoreds(string contactIDs)
        {
            clsDeleteResult result = new clsDeleteResult();

            string query = @"DELETE FROM Contacts
                            WHERE ContactID IN (" + contactIDs + ");";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    result.Success = (rowsAffected > 0);
                    result.Message = rowsAffected > 0
                        ? "Records deleted successfully"
                        : "Records not found";
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
            clsDeleteResult result = DeleteRecoreds("8, 9, 10, 12, 13");

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
