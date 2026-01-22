using System;
using System.Data;
using System.Linq;
internal class Program
{
    static void Main(string[] args)
    {
        DataTable EmployeesDataTable = new DataTable();

        // Add table columns
        EmployeesDataTable.Columns.Add("ID", typeof(int));
        EmployeesDataTable.Columns.Add("Name", typeof(string));
        EmployeesDataTable.Columns.Add("Country", typeof(string));
        EmployeesDataTable.Columns.Add("Salary", typeof(decimal));
        EmployeesDataTable.Columns.Add("DateOfBirth", typeof(DateTime));

        // Add Rows
        EmployeesDataTable.Rows.Add(1, "Ragheb", "EGP", 10000.543, new DateTime(2008, 1, 1));
        EmployeesDataTable.Rows.Add(2, "kem", "JOD", 30000.23, new DateTime(1978, 7, 22));
        EmployeesDataTable.Rows.Add(3, "Ali", "KSA", 2332.322, DateTime.Now);
        EmployeesDataTable.Rows.Add(4, "Mikel", "USA", 3232.53, DateTime.Now);
        EmployeesDataTable.Rows.Add(5, "Jane", "GRM", 5432.42, DateTime.Now);

        // Print table
        foreach (DataRow row in EmployeesDataTable.Rows)
        {
            Console.WriteLine("ID: {0}\t, Name: {1}\t, Country: {2}\t, Salary: {3}\t, DateOfBirth: {4}\n", row["ID"], row["Name"], row["Country"], row["Salary"], row["DateOfBirth"]);
        }
    }
}

