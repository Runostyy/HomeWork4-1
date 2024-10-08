using System;

namespace Lab4_1
{
    class Person
    {
        public string Name { get; set; } // ім'я
        public int Age { get; set; } // вік
        public string Role { get; set; } // роль

        public Person(string N, string R, int A)
        {
            Name = N;
            Age = A;
            Role = R;
        }

        public string GetName() { return Name; }
    }

    // Клас StudentAssesment, частина Student
    class StudentAssesment
    {
        double[] assesment = new double[10];

        // Метод для генерації оцінок і підрахунку середнього балу
        public double StRating(Random arand)
        {
            double rating = 0;
            for (int i = 0; i < 10; i++)
            {
                assesment[i] = arand.Next(56, 101); // Генерація випадкових чисел від 56 до 100
                rating += assesment[i];
                Console.Write(assesment[i].ToString() + ",");
            }
            Console.WriteLine();
            return rating / 10;
        }
    }

    // Клас Student, що наслідує клас Person
    class Student : Person
    {
        public string Facultet { get; set; }
        public string Group { get; set; }
        public int Course { get; set; }

        public Student(string N, string R, int A, string F, string G, int C)
            : base(N, R, A)
        {
            Facultet = F;
            Group = G;
            Course = C;
        }

        // Створення екземплярів класу StudentAssesment
        StudentAssesment strating1 = new StudentAssesment();
        StudentAssesment strating2 = new StudentAssesment();

        public void MyRating(Random arand)
        {
            // Обчислення рейтингів за кожний модуль
            Console.WriteLine("Оцінки за перший модуль:");
            double Rating1 = strating1.StRating(arand);

            Console.WriteLine("Оцінки за другий модуль:");
            double Rating2 = strating2.StRating(arand);

            // Обчислення середнього рейтингу за семестр
            double AverageRating = (Rating1 + Rating2) / 2;
            Console.WriteLine($"Середній рейтинг за семестр = {AverageRating}");

            // Виведення повідомлень в залежності від середнього балу
            if (AverageRating >= 82)
                Console.WriteLine("Привіт відмінникам");
            else if (AverageRating <= 60)
                Console.WriteLine("Перездача! Треба краще вчитися!");
            else
                Console.WriteLine("Можна вчитися ще краще!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Створення екземпляра класу Student
            Student newSt = new Student("Іванов", "студент", 20, "КННІ", "K-01", 3);
            Random arand = new Random();

            // Виклик методу для підрахунку рейтингу
            newSt.MyRating(arand);

            Console.ReadKey();
        }
    }
}
