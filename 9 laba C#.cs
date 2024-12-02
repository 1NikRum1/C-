using System;
using System.IO;
using System.Linq;

namespace FileHandlingSystem
{
    public class FileManager
    {
        public event Action OnStartCopy;
        public event Action OnFinishCopy;
        public event Action<int> OnProgressUpdate;

        public void CopyFile(string sourcePath, string destinationPath, int bufferSize)
        {
            if (!File.Exists(sourcePath))
                throw new FileNotFoundException("Исходный файл не существует.");

            OnStartCopy?.Invoke();

            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            using (FileStream destinationStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[bufferSize];
                long totalBytes = sourceStream.Length;
                long copiedBytes = 0;
                int bytesRead;

                while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    destinationStream.Write(buffer, 0, bytesRead);
                    copiedBytes += bytesRead;

                    int progress = (int)((double)copiedBytes / totalBytes * 100);
                    OnProgressUpdate?.Invoke(progress);
                }
            }

            OnFinishCopy?.Invoke();
        }

        public void AppendToFile(string path, string data)
        {
            using (StreamWriter writer = new StreamWriter(path, append: true))
            {
                writer.WriteLine(data);
            }
        }

        public string ReadFileAsString(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Файл не существует.");

            return File.ReadAllText(path);
        }

        public byte[] ReadFileAsBytes(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Файл не существует.");

            return File.ReadAllBytes(path);
        }

        public void WriteBytesToFile(string path, byte[] content)
        {
            File.WriteAllBytes(path, content);
        }
    }

    class Application
    {
        static void Main(string[] args)
        {
            FileManager fileHandler = new FileManager();

            fileHandler.OnStartCopy += () => Console.WriteLine("Начало копирования файла.");
            fileHandler.OnFinishCopy += () => Console.WriteLine("Копирование файла завершено.");
            fileHandler.OnProgressUpdate += (percentage) => Console.WriteLine($"Прогресс: {percentage}%");

            try
            {
                string sourceFilePath = "input.txt";
                string destinationFilePath = "output.txt";
                int bufferBlockSize = 1024; // Размер блока буфера в байтах

                // Создание примера исходного файла
                File.WriteAllText(sourceFilePath, "Пример содержимого для тестирования копирования файла.");

                // Копирование файла
                fileHandler.CopyFile(sourceFilePath, destinationFilePath, bufferBlockSize);

                // Проверка идентичности файлов
                byte[] originalBytes = fileHandler.ReadFileAsBytes(sourceFilePath);
                byte[] copiedBytes = fileHandler.ReadFileAsBytes(destinationFilePath);

                Console.WriteLine(originalBytes.SequenceEqual(copiedBytes)
                    ? "Файлы идентичны."
                    : "Файлы не идентичны.");

                // Добавление данных в файл
                fileHandler.AppendToFile(destinationFilePath, "\nДополнительный текст добавлен в файл.");

                // Чтение и вывод содержимого файла
                string updatedContent = fileHandler.ReadFileAsString(destinationFilePath);
                Console.WriteLine("Обновлённое содержимое файла:\n" + updatedContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }
    }
}
