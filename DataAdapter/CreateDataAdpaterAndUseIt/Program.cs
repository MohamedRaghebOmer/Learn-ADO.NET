using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

internal class Program
{
    static void Main()
    {
        string connectionString = "Server=.;Database=HR_Database;User ID = sa;Password=123456";
        SqlConnection connection = null;
        DataSet dataSet = new DataSet();
        string query = "SELECT * FROM Employees;";

        try
        {
            connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString);

            connection.Open();
           // adapter.SelectCommand.Connection = connection;
            adapter.Fill(dataSet, "Employees");

            // Display the data from the DataSet
            DataTable customersTable = dataSet.Tables["Employees"];
            foreach (DataRow row in customersTable.Rows)
            {
                Console.WriteLine("Customer ID: {0}, Name: {1}, LastName: {2}", row["ID"], row["FirstName"], row["LastName"]);
            }

            //
            //
            // Make changes to the DataSet (add, modify, or delete rows)
            //
            //

            // Set the UpdateCommand of the DataAdapter to the connection
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            // Update the data source with the changes
            adapter.Update(dataSet, "Employees");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }
}

