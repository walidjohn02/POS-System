using System;
using Microsoft.Data.Sqlite;
using System.Windows.Forms;

namespace theGrandCouchApp
{
    internal static class Program
    {
        public static string ConnectionString = "Data Source=inventory.db";

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Ensure all tables exist before opening any form
            EnsureDatabaseTables();

            // Launch the main/home form
            Application.Run(new HomeForm());
        }

        private static void EnsureDatabaseTables()
        {
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();

            // Products table
            string createProducts = @"CREATE TABLE IF NOT EXISTS Products (
                                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        Barcode TEXT NOT NULL UNIQUE,
                                        Name TEXT NOT NULL,
                                        Price REAL NOT NULL,
                                        PurchasePrice REAL NOT NULL DEFAULT 0,
                                        Quantity INTEGER NOT NULL
                                    );";
            using var cmdProducts = new SqliteCommand(createProducts, conn);
            cmdProducts.ExecuteNonQuery();

            // Sales table
            string createSales = @"CREATE TABLE IF NOT EXISTS Sales (
                                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        SaleDate TEXT,
                                        Total REAL,
                                        IsDebt INTEGER
                                    );";
            using var cmdSales = new SqliteCommand(createSales, conn);
            cmdSales.ExecuteNonQuery();

            // SaleItems table
            string createSaleItems = @"CREATE TABLE IF NOT EXISTS SaleItems (
                                          Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                          SaleId INTEGER,
                                          ProductId INTEGER,
                                          ProductName TEXT,
                                          Quantity INTEGER,
                                          Price REAL
                                      );";
            using var cmdSaleItems = new SqliteCommand(createSaleItems, conn);
            cmdSaleItems.ExecuteNonQuery();
        }
    }
}