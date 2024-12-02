using System;

namespace TimeConversionAndErrorHandling
{
    class Application
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите дату и время в формате UTC (гггг-ММ-дд ЧЧ:мм:сс): ");
                string userInput = Console.ReadLine();
                DateTime parsedUtcDate = DateTime.Parse(userInput);

                try
                {
                    DateTime convertedLocalDate = ConvertUtcToLocal(parsedUtcDate);
                    Console.WriteLine($"Локальная дата и время: {convertedLocalDate}");
                }
                catch (Exception conversionEx)
                {
                    throw new Exception("Ошибка при преобразовании UTC времени в локальное время.", conversionEx);
                }
            }
            catch (Exception mainEx)
            {
                Console.WriteLine("Произошла ошибка: " + mainEx.Message);
                if (mainEx.InnerException != null)
                {
                    Console.WriteLine("Внутреннее исключение: " + mainEx.InnerException.Message);
                }
            }
        }

        static DateTime ConvertUtcToLocal(DateTime utcDateTime)
        {
            try
            {
                TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
                return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, localTimeZone);
            }
            catch (Exception timeZoneEx)
            {
                throw new Exception("Ошибка при преобразовании времени в локальный часовой пояс.", timeZoneEx);
            }
        }
    }
}
