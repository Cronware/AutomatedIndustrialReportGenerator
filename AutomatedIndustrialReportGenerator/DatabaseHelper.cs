using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;

public class DatabaseHelper
{
    private string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=admin;Database=industrial_reports";

    public DataTable GetMachineData()
    {
        DataTable dataTable = new DataTable();
        try
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM machine_data ORDER BY timestamp DESC";

                using (var cmd = new NpgsqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Database error: " + ex.Message);
        }
        return dataTable;
    }
}
