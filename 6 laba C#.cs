using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQExample
{
    class Application
    {
        static void Main(string[] args)
        {
            // Инициализация списка работников
            List<Worker> workerList = new List<Worker>
            {
                new Worker { WorkerId = 1, FullName = "Alice", Team = "HR", Income = 50000 },
                new Worker { WorkerId = 2, FullName = "Bob", Team = "IT", Income = 60000 },
                new Worker { WorkerId = 3, FullName = "Charlie", Team = "IT", Income = 70000 },
                new Worker { WorkerId = 4, FullName = "David", Team = "Finance", Income = 55000 },
                new Worker { WorkerId = 5, FullName = "Eve", Team = "Finance", Income = 45000 },
                new Worker { WorkerId = 6, FullName = "Frank", Team = "HR", Income = 62000 }
            };

            // a. Фильтрация сотрудников с использованием лямбда-выражения
            var highIncomeWorkers = workerList.Where(w => w.Income > 55000).ToList();
            Console.WriteLine("Работники с доходом выше 55000:");
            foreach (var worker in highIncomeWorkers)
            {
                Console.WriteLine($"{worker.FullName} - {worker.Income}");
            }

            // b. Использование анонимных типов
            var workerDetails = workerList.Select(w => new { w.FullName, w.Team }).ToArray();
            Console.WriteLine("\nИнформация о работниках (имя и команда):");
            foreach (var detail in workerDetails)
            {
                Console.WriteLine($"Name: {detail.FullName}, Team: {detail.Team}");
            }

            // c. Группировка работников по командам
            var groupedByTeam = from w in workerList
                                group w by w.Team into teamGroup
                                select new
                                {
                                    Team = teamGroup.Key,
                                    Workers = teamGroup.ToList()
                                };

            Console.WriteLine("\nРаботники по командам:");
            foreach (var group in groupedByTeam)
            {
                Console.WriteLine($"\nTeam: {group.Team}");
                foreach (var worker in group.Workers)
                {
                    Console.WriteLine($"- {worker.FullName}");
                }
            }

            // Дополнительные методы LINQ
            var orderedSubset = workerList.OrderBy(w => w.Income).Skip(1).Take(3).ToList();
            Console.WriteLine("\nПример использования Skip и Take (сортировка по доходу, пропуск 1 и взятие 3):");
            foreach (var worker in orderedSubset)
            {
                Console.WriteLine($"{worker.FullName} - {worker.Income}");
            }

            var firstInIT = workerList.FirstOrDefault(w => w.Team == "IT");
            Console.WriteLine($"\nПервый работник из команды IT: {firstInIT?.FullName ?? "Не найден"}");

            bool existsHighIncome = workerList.Any(w => w.Income > 70000);
            Console.WriteLine($"\nЕсть ли работники с доходом выше 70000? {(existsHighIncome ? "Да" : "Нет")}");
        }
    }

    // Класс работника
    class Worker
    {
        public int WorkerId { get; set; }
        public string FullName { get; set; }
        public string Team { get; set; }
        public decimal Income { get; set; }
    }
}
