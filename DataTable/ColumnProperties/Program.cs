using System;
using System.Data;

internal class Program
{
    static void Main(string[] args)
    {
        //DataTable dtEmployees = new DataTable("Employees");

        // dtEmployees.Columns.Add("ID", typeof(int));
        // dtEmployees.Columns.Add("Name", typeof(string));
        // dtEmployees.Columns.Add("Country", typeof(string));
        // dtEmployees.Columns.Add("Salary", typeof(double));
        // dtEmployees.Columns.Add("DateOfBirth", typeof(DateTime));

        // DataColumn[] PKID = new DataColumn[1];
        // PKID[0] = dtEmployees.Columns["ID"];
        // dtEmployees.PrimaryKey = PKID;

        DataColumn ID = new DataColumn();
        ID.ColumnName = "ID";
        ID.Caption = "Employees ID";
        ID.ReadOnly = true;
        ID.AutoIncrement = true;
        ID.AutoIncrementSeed = 1;
        ID.AutoIncrementStep = 1;


        // Name properties
        DataColumn Name = new DataColumn();
        Name.ColumnName = "Name";
        Name.Caption = "Employees names";
        Name.MaxLength = 30;
        Name.Unique = false;
        Name.AutoIncrement = false;
        Name.ReadOnly = false;
        
    }
}
