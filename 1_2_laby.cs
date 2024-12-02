
using System;
using UtilityLibrary;

namespace NumberStarApp
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            // Получение и вывод строки с числами от 1 до N
            Console.Write("Введите значение N для вывода чисел: ");
            if (int.TryParse(Console.ReadLine(), out int numberLimit))
            {
                string formattedNumbers = NumberGenerator.GenerateSequence(numberLimit);
                Console.WriteLine($"Числа от 1 до {numberLimit}: {formattedNumbers}");
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
            }

            // Получение и вывод квадрата из звёздочек
            Console.Write("\nВведите значение N для построения квадрата (нечётное число): ");
            if (int.TryParse(Console.ReadLine(), out int squareSize))
            {
                Console.WriteLine("Квадрат из звёздочек:");
                StarPatternBuilder.BuildSquare(squareSize);
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
            }
        }
    }
}





// 2 лаба

/*using System;

class StarApp
{
    static void Main(string[] args)
    {
        // Вызов метода расчёта индекса массы тела
        ComputeBMI();

        // Вызов метода работы с массивом чисел
        ProcessArray();

        // Вызов метода расчёта средней длины слова
        AnalyzeAverageWordLength();
    }

    // 1. Метод для расчёта индекса массы тела
    static void ComputeBMI()
    {
        Console.WriteLine("Введите ваш вес в килограммах:");
        double bodyWeight = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите ваш рост в сантиметрах:");
        double heightInMeters = Convert.ToDouble(Console.ReadLine()) / 100;

        double bodyMassIndex = bodyWeight / (heightInMeters * heightInMeters);
        Console.WriteLine($"Ваш ИМТ: {bodyMassIndex:F2}");
    }

    // 2. Метод для работы с массивом чисел
    static void ProcessArray()
    {
        Random randomGenerator = new Random();
        int[] numberArray = new int[10];

        // Заполнение массива случайными числами
        for (int index = 0; index < numberArray.Length; index++)
        {
            numberArray[index] = randomGenerator.Next(1, 101); // Числа от 1 до 100
        }

        Console.WriteLine("\nСгенерированный массив:");
        DisplayArray(numberArray);

        // Поиск минимального и максимального значений
        int minimumValue = numberArray[0], maximumValue = numberArray[0];
        for (int index = 1; index < numberArray.Length; index++)
        {
            if (numberArray[index] < minimumValue) minimumValue = numberArray[index];
            if (numberArray[index] > maximumValue) maximumValue = numberArray[index];
        }

        Console.WriteLine($"Минимальное значение: {minimumValue}");
        Console.WriteLine($"Максимальное значение: {maximumValue}");

        // Сортировка массива
        for (int i = 0; i < numberArray.Length - 1; i++)
        {
            for (int j = i + 1; j < numberArray.Length; j++)
            {
                if (numberArray[i] > numberArray[j])
                {
                    int temp = numberArray[i];
                    numberArray[i] = numberArray[j];
                    numberArray[j] = temp;
                }
            }
        }

        Console.WriteLine("Отсортированный массив:");
        DisplayArray(numberArray);
    }

    // Вспомогательный метод для вывода массива
    static void DisplayArray(int[] array)
    {
        foreach (var element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }

    // 3. Метод для расчёта средней длины слова
    static void AnalyzeAverageWordLength()
    {
        Console.WriteLine("\nВведите строку текста:");
        string textInput = Console.ReadLine();

        string[] wordsArray = textInput.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        int totalWordLength = 0;
        int wordCount = 0;

        foreach (string rawWord in wordsArray)
        {
            string sanitizedWord = ""; // Удаление символов пунктуации
            foreach (char character in rawWord)
            {
                if (Char.IsLetterOrDigit(character))
                {
                    sanitizedWord += character;
                }
            }

            totalWordLength += sanitizedWord.Length;
            wordCount++;
        }

        double averageWordLength = (wordCount > 0) ? (double)totalWordLength / wordCount : 0;
        Console.WriteLine($"Средняя длина слова: {averageWordLength:F2}");
    }
}

*/
