using System;

namespace CustomSortingExample
{
    // 1. Делегат для сравнения элементов
    public delegate int CompareDelegate<T>(T first, T second);

    // 2. Класс, реализующий сортировку и события
    public class ArraySorter<T>
    {
        // Событие, уведомляющее о завершении сортировки
        public event EventHandler SortingFinished;

        // Событие с дополнительными данными
        public event EventHandler<SortingEventArgs> SortingFinishedWithDetails;

        // Метод для сортировки массива
        public void PerformSort(T[] items, CompareDelegate<T> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer), "The comparer delegate cannot be null");

            // Реализация пузырьковой сортировки
            for (int i = 0; i < items.Length - 1; i++)
            {
                for (int j = 0; j < items.Length - i - 1; j++)
                {
                    if (comparer(items[j], items[j + 1]) > 0)
                    {
                        T temp = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = temp;
                    }
                }
            }

            // Вызов событий после завершения сортировки
            RaiseSortingFinished();
            RaiseSortingFinishedWithDetails(new SortingEventArgs(items.Length));
        }

        // Метод для вызова события SortingFinished
        protected virtual void RaiseSortingFinished()
        {
            SortingFinished?.Invoke(this, EventArgs.Empty);
        }

        // Метод для вызова события SortingFinishedWithDetails
        protected virtual void RaiseSortingFinishedWithDetails(SortingEventArgs args)
        {
            SortingFinishedWithDetails?.Invoke(this, args);
        }
    }

    // 3. Класс аргументов события
    public class SortingEventArgs : EventArgs
    {
        public int ItemCount { get; }

        public SortingEventArgs(int itemCount)
        {
            ItemCount = itemCount;
        }
    }

    class Application
    {
        static void Main(string[] args)
        {
            // Массив для сортировки
            int[] numbers = { 9, 7, 5, 3, 1 };

            // Создание экземпляра ArraySorter
            ArraySorter<int> arraySorter = new ArraySorter<int>();

            // Подписка на события
            arraySorter.SortingFinished += (sender, e) => Console.WriteLine("Сортировка завершена.");
            arraySorter.SortingFinishedWithDetails += (sender, e) =>
            {
                SortingEventArgs details = (SortingEventArgs)e;
                Console.WriteLine($"Сортировка завершена. Количество элементов: {details.ItemCount}");
            };

            // Использование лямбда-выражения для сравнения
            arraySorter.PerformSort(numbers, (a, b) => a.CompareTo(b));

            // Вывод отсортированного массива
            Console.WriteLine("Отсортированный массив: " + string.Join(", ", numbers));
        }
    }
}
