using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Program
{
    static void Main(string[] args)
    {
        DataTable EmployeesDataTable = new DataTable();

        // Add table columns
        EmployeesDataTable.Columns.Add("ID", typeof(int));
        EmployeesDataTable.Columns.Add("Name", typeof(string));
        EmployeesDataTable.Columns.Add("Country", typeof(string));
        EmployeesDataTable.Columns.Add("Salary", typeof(double));
        EmployeesDataTable.Columns.Add("DateOfBirth", typeof(DateTime));


        // Add Rows
        EmployeesDataTable.Rows.Add(1, "Ragheb", "EGP", 10000.543, new DateTime(2008, 1, 1));
        EmployeesDataTable.Rows.Add(2, "kem", "JOD", 30000.23, new DateTime(1978, 7, 22));
        EmployeesDataTable.Rows.Add(3, "Ali", "KSA", 2332.322, DateTime.Now);
        EmployeesDataTable.Rows.Add(4, "Mikel", "USA", 3232.53, DateTime.Now);
        EmployeesDataTable.Rows.Add(5, "Jane", "GRM", 5432.42, DateTime.Now);


        // filtering by country = EGP or JOD
        DataRow[] countryFilter = EmployeesDataTable.Select("Country = 'JOD' OR Country = 'EGP'");
        Console.WriteLine("Filter by country = JOD or country = EGP");
        foreach (DataRow row in countryFilter)
            Console.WriteLine("ID: {0}\t, Name: {1}\t, Country: {2}\t, Salary: {3}\t, DateOfBirth: {4}\n",
                row["ID"], row["Name"], row["Country"], row["Salary"], row["DateOfBirth"]);


        // filtering by id = 1
        DataRow[] idFilter = EmployeesDataTable.Select("ID = 1");
        Console.WriteLine("\n\nFilter by id = 1");
        foreach (DataRow row in idFilter)
            Console.WriteLine("ID: {0}\t, Name: {1}\t, Country: {2}\t, Salary: {3}\t, DateOfBirth: {4}\n",
                row["ID"], row["Name"], row["Country"], row["Salary"], row["DateOfBirth"]);
    }
}

