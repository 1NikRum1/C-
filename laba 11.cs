﻿using System;
using System.Data.SqlClient;
using System.Linq;
using LinqToDB;
using LinqToDB.Data;
using System.Collections.Generic;

namespace DatabaseUtility
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.;Database=YourDatabase;Trusted_Connection=True;";

            Console.WriteLine("Выберите режим работы:");
            Console.WriteLine("1: ADO.NET");
            Console.WriteLine("2: Linq2db");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RunAdoNetExamples(connectionString);
                    break;
                case "2":
                    RunLinq2DbExamples();
                    break;
                default:
                    Console.WriteLine("Неверный выбор!");
                    break;
            }
        }

        private static void RunAdoNetExamples(string connectionString)
        {
            Console.WriteLine("--- ADO.NET ---");

            // Пример выборки данных
            Console.WriteLine("Данные из таблицы:");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM YourTable";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["ColumnName"]);
                        }
                    }
                }
            }

            // Пример вставки данных
            Console.WriteLine("Добавление новой строки...");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO YourTable (ColumnName) VALUES (@Value)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Value", "NewValue");
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void RunLinq2DbExamples()
        {
            Console.WriteLine("--- Linq2db ---");

            using (var db = new YourDatabaseConnection())
            {
                // Пример выборки данных
                var data = db.YourTable.ToList();
                Console.WriteLine("Данные из таблицы:");
                foreach (var item in data)
                {
                    Console.WriteLine(item.ColumnName);
                }

                // Пример вставки данных
                Console.WriteLine("Добавление новой строки...");
                db.Insert(new YourTable
                {
                    ColumnName = "NewValue"
                });
            }
        }
    }

    public class YourDatabaseConnection : LinqToDB.Data.DataConnection
    {
        public YourDatabaseConnection() : base("YourConnectionString") { }

        public ITable<YourTable> YourTable => GetTable<YourTable>();
    }

    public class YourTable
    {
        public int Id { get; set; }
        public string ColumnName { get; set; }
    }
}