using System;
using System.Data;

internal class Program
{
    static void Main(string[] args)
    {
        DataTable employees = new DataTable("Employees");

        employees.Columns.Add("Id", typeof(int));
        employees.Columns.Add("Name", typeof(string));
        employees.Columns.Add("Country", typeof(string));
        employees.Columns.Add("Salary", typeof(decimal));
        employees.Columns.Add("HireDate", typeof(DateTime));

        employees.Rows.Add(1, "Mohamed", "Egypt", 10000m, new DateTime(2008, 1, 1));
        employees.Rows.Add(2, "Ibrahem", "Jordan", 50030m, new DateTime(2006, 4, 21));
        employees.Rows.Add(3, "Ziad", "Kuwait", 43232m, new DateTime(2009, 7, 15));
        employees.Rows.Add(4, "Ahmed", "Egypt", 25000m, new DateTime(2010, 3, 10));
        employees.Rows.Add(5, "Basem", "Egypt", 28000m, new DateTime(2011, 6, 5));


        DataView dvEmployees = employees.DefaultView;

        Console.WriteLine("Data before sorting:\n");
        for (int i = 0; i < dvEmployees.Count; i++)
        {
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}", dvEmployees[i][0], dvEmployees[i][1],
                dvEmployees[i][2], dvEmployees[i][3], ((DateTime)dvEmployees[i][4]).ToString("dd/MM/yyyy"));
        }

        // Sort data by Name Asc
        dvEmployees.Sort = "Name ASC";

        Console.WriteLine("\nData after sorting by name ASC:\n");
        for (int i = 0; i < dvEmployees.Count; i++)
        {
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}", dvEmployees[i][0], dvEmployees[i][1],
                dvEmployees[i][2], dvEmployees[i][3], ((DateTime)dvEmployees[i][4]).ToString("dd/MM/yyyy"));
        }
    }
}

