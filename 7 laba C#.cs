using System;

namespace GeometryAndPersonDemo
{
    // Класс CircleDetails для описания круга
    public class CircleDetails
    {
        public double CenterX { get; private set; }
        public double CenterY { get; private set; }
        private double _radius;

        public double Radius
        {
            get => _radius;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Радиус должен быть положительным числом.");
                _radius = value;
            }
        }

        public double Perimeter => 2 * Math.PI * Radius;
        public double SurfaceArea => Math.PI * Radius * Radius;

        public CircleDetails(double centerX, double centerY, double radius)
        {
            CenterX = centerX;
            CenterY = centerY;
            Radius = radius;
        }

        public override string ToString()
        {
            return $"Круг с центром ({CenterX}, {CenterY}) и радиусом {Radius}.\nДлина окружности: {Perimeter:F2}\nПлощадь: {SurfaceArea:F2}";
        }
    }

    // Класс Person для описания человека
    public class Person
    {
        public string Surname { get; set; }
        public string GivenName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age => DateTime.Now.Year - BirthDate.Year -
                          (DateTime.Now.DayOfYear < BirthDate.DayOfYear ? 1 : 0);

        public Person(string surname, string givenName, string middleName, DateTime birthDate)
        {
            Surname = surname;
            GivenName = givenName;
            MiddleName = middleName;
            BirthDate = birthDate;
        }

        public override string ToString()
        {
            return $"{Surname} {GivenName} {MiddleName}, {Age} лет.";
        }
    }

    // Класс Staff на основе Person
    public class Staff : Person
    {
        public string JobTitle { get; set; }
        public int YearsOfExperience { get; set; }

        public Staff(string surname, string givenName, string middleName, DateTime birthDate, string jobTitle, int yearsOfExperience)
            : base(surname, givenName, middleName, birthDate)
        {
            JobTitle = jobTitle;
            YearsOfExperience = yearsOfExperience;
        }

        public override string ToString()
        {
            return $"{base.ToString()} Должность: {JobTitle}, Стаж работы: {YearsOfExperience} лет.";
        }
    }

    // Абстрактный класс ShapeDetails
    public abstract class ShapeDetails
    {
        public abstract double SurfaceArea { get; }
        public abstract double Perimeter { get; }
        public virtual string ShapeName => "Фигура";
    }

    public interface IDisplayable
    {
        void Display();
    }

    public class CircleShape : ShapeDetails, IDisplayable
    {
        public double Radius { get; private set; }

        public CircleShape(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Радиус должен быть положительным числом.");
            Radius = radius;
        }

        public override double SurfaceArea => Math.PI * Radius * Radius;
        public override double Perimeter => 2 * Math.PI * Radius;

        public override string ShapeName => "Круг";

        public void Display()
        {
            Console.WriteLine($"{ShapeName}: Радиус {Radius}, Площадь {SurfaceArea:F2}, Длина окружности {Perimeter:F2}");
        }
    }

    class EntryPoint
    {
        static void Main(string[] args)
        {
            // Демонстрация работы с классом CircleDetails
            Console.WriteLine("Демонстрация работы с классом CircleDetails:");
            CircleDetails circleDetails = new CircleDetails(0, 0, 5);
            Console.WriteLine(circleDetails);

            // Демонстрация работы с классом Person
            Console.WriteLine("\nДемонстрация работы с классом Person:");
            Console.WriteLine("Введите фамилию:");
            string surname = Console.ReadLine();
            Console.WriteLine("Введите имя:");
            string givenName = Console.ReadLine();
            Console.WriteLine("Введите отчество:");
            string middleName = Console.ReadLine();
            Console.WriteLine("Введите дату рождения (гггг-мм-дд):");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Person person = new Person(surname, givenName, middleName, birthDate);
            Console.WriteLine(person);

            // Демонстрация работы с классом Staff
            Console.WriteLine("\nДемонстрация работы с классом Staff:");
            Console.WriteLine("Введите должность:");
            string jobTitle = Console.ReadLine();
            Console.WriteLine("Введите стаж работы:");
            int experience = int.Parse(Console.ReadLine());
            Staff staff = new Staff(surname, givenName, middleName, birthDate, jobTitle, experience);
            Console.WriteLine(staff);

            // Демонстрация абстрактного класса и интерфейса
            Console.WriteLine("\nДемонстрация абстрактного класса и интерфейса:");
            CircleShape circleShape = new CircleShape(10);
            circleShape.Display();
        }
    }
}
