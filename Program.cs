using System;

namespace LabWork
{
    // Базовий клас "Пряма"
    // Рівняння: a1*x + a2*y + a0 = 0
    class Pryama
    {
        protected double a0, a1, a2;

        public Pryama()
        {
            a0 = 0;
            a1 = 0;
            a2 = 0;
        }

        // Конструктор з параметрами
        public Pryama(double a0, double a1, double a2)
        {
            this.a0 = a0;
            this.a1 = a1;
            this.a2 = a2;
        }

        // Метод завдання коефіцієнтів
        public virtual void SetCoefficients(params double[] coefficients)
        {
            if (coefficients.Length != 3)
            {
                throw new ArgumentException("Для прямої потрібно 3 коефіцієнти (a0, a1, a2)");
            }
            a0 = coefficients[0];
            a1 = coefficients[1];
            a2 = coefficients[2];
        }

        // Метод виведення коефіцієнтів на екран
        public virtual void PrintCoefficients()
        {
            Console.WriteLine("=== Пряма ===");
            Console.WriteLine($"Рівняння: {a1}*x + {a2}*y + {a0} = 0");
            Console.WriteLine($"Коефіцієнти: a0 = {a0}, a1 = {a1}, a2 = {a2}");
        }

        // Метод визначення належності точки прямій
        public virtual bool ContainsPoint(params double[] point)
        {
            if (point.Length != 2)
            {
                throw new ArgumentException("Для прямої потрібно 2 координати точки (x, y)");
            }
            
            double x = point[0];
            double y = point[1];
            
            // Обчислюємо значення лівої частини рівняння
            double result = a1 * x + a2 * y + a0;
            
            // Перевіряємо, чи дорівнює результат нулю (з похибкою для дійсних чисел)
            const double epsilon = 1e-10;
            return Math.Abs(result) < epsilon;
        }
    }

    // Похідний клас "Гіперплощина"
    // Рівняння: a4*x4 + a3*x3 + a2*x2 + a1*x1 + a0 = 0
    class Giperploschyna : Pryama
    {
        private double a3, a4;

        // Конструктор за замовчуванням
        public Giperploschyna() : base()
        {
            a3 = 0;
            a4 = 0;
        }

        // Конструктор з параметрами
        public Giperploschyna(double a0, double a1, double a2, double a3, double a4) 
            : base(a0, a1, a2)
        {
            this.a3 = a3;
            this.a4 = a4;
        }

        // Перевантажений метод завдання коефіцієнтів
        public override void SetCoefficients(params double[] coefficients)
        {
            if (coefficients.Length != 5)
            {
                throw new ArgumentException("Для гіперплощини потрібно 5 коефіцієнтів (a0, a1, a2, a3, a4)");
            }
            a0 = coefficients[0];
            a1 = coefficients[1];
            a2 = coefficients[2];
            a3 = coefficients[3];
            a4 = coefficients[4];
        }

        // Перевантажений метод виведення коефіцієнтів
        public override void PrintCoefficients()
        {
            Console.WriteLine("=== Гіперплощина ===");
            Console.WriteLine($"Рівняння: {a4}*x4 + {a3}*x3 + {a2}*x2 + {a1}*x1 + {a0} = 0");
            Console.WriteLine($"Коефіцієнти: a0 = {a0}, a1 = {a1}, a2 = {a2}, a3 = {a3}, a4 = {a4}");
        }

        // Перевантажений метод визначення належності точки
        public override bool ContainsPoint(params double[] point)
        {
            if (point.Length != 4)
            {
                throw new ArgumentException("Для гіперплощини потрібно 4 координати точки (x1, x2, x3, x4)");
            }
            
            double x1 = point[0];
            double x2 = point[1];
            double x3 = point[2];
            double x4 = point[3];
            
            // Обчислюємо значення лівої частини рівняння
            double result = a4 * x4 + a3 * x3 + a2 * x2 + a1 * x1 + a0;
            
            // Перевіряємо, чи дорівнює результат нулю
            const double epsilon = 1e-10;
            return Math.Abs(result) < epsilon;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  Робота з класами 'Пряма' та 'Гіперплощина'              ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");

            // =============== РОБОТА З ПРЯМОЮ ===============
            Console.WriteLine("┌─────────────────────────────────────────────────────────┐");
            Console.WriteLine("│ 1. ПРЯМА                                                │");
            Console.WriteLine("└─────────────────────────────────────────────────────────┘");
            
            // Створення об'єкта класу "Пряма"
            Pryama pryama = new Pryama();
            
            Console.WriteLine("\nВведіть коефіцієнти для прямої (a1*x + a2*y + a0 = 0):");
            
            Console.Write("a0 = ");
            double a0_p = double.Parse(Console.ReadLine());
            
            Console.Write("a1 = ");
            double a1_p = double.Parse(Console.ReadLine());
            
            Console.Write("a2 = ");
            double a2_p = double.Parse(Console.ReadLine());
            
            pryama.SetCoefficients(a0_p, a1_p, a2_p);
            
            Console.WriteLine();
            pryama.PrintCoefficients();
            
            // Перевірка точок для прямої
            Console.WriteLine("\n--- Перевірка належності точок прямій ---");
            
            Console.Write("\nВведіть кількість точок для перевірки: ");
            int n1 = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n1; i++)
            {
                Console.WriteLine($"\nТочка #{i + 1}:");
                Console.Write("x = ");
                double x = double.Parse(Console.ReadLine());
                
                Console.Write("y = ");
                double y = double.Parse(Console.ReadLine());
                
                bool belongs = pryama.ContainsPoint(x, y);
                
                Console.ForegroundColor = belongs ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine($"Точка ({x}, {y}) {(belongs ? "НАЛЕЖИТЬ" : "НЕ НАЛЕЖИТЬ")} прямій");
                Console.ResetColor();
            }

            // =============== РОБОТА З ГІПЕРПЛОЩИНОЮ ===============
            Console.WriteLine("\n\n┌─────────────────────────────────────────────────────────┐");
            Console.WriteLine("│ 2. ГІПЕРПЛОЩИНА                                         │");
            Console.WriteLine("└─────────────────────────────────────────────────────────┘");
            
            // Створення об'єкта класу "Гіперплощина"
            Giperploschyna giper = new Giperploschyna();
            
            Console.WriteLine("\nВведіть коефіцієнти для гіперплощини (a4*x4 + a3*x3 + a2*x2 + a1*x1 + a0 = 0):");
            
            Console.Write("a0 = ");
            double a0_g = double.Parse(Console.ReadLine());
            
            Console.Write("a1 = ");
            double a1_g = double.Parse(Console.ReadLine());
            
            Console.Write("a2 = ");
            double a2_g = double.Parse(Console.ReadLine());
            
            Console.Write("a3 = ");
            double a3_g = double.Parse(Console.ReadLine());
            
            Console.Write("a4 = ");
            double a4_g = double.Parse(Console.ReadLine());
            
            giper.SetCoefficients(a0_g, a1_g, a2_g, a3_g, a4_g);
            
            Console.WriteLine();
            giper.PrintCoefficients();
            
            // Перевірка точок для гіперплощини
            Console.WriteLine("\n--- Перевірка належності точок гіперплощині ---");
            
            Console.Write("\nВведіть кількість точок для перевірки: ");
            int n2 = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n2; i++)
            {
                Console.WriteLine($"\nТочка #{i + 1} (4-вимірний простір):");
                Console.Write("x1 = ");
                double x1 = double.Parse(Console.ReadLine());
                
                Console.Write("x2 = ");
                double x2 = double.Parse(Console.ReadLine());
                
                Console.Write("x3 = ");
                double x3 = double.Parse(Console.ReadLine());
                
                Console.Write("x4 = ");
                double x4 = double.Parse(Console.ReadLine());
                
                bool belongs = giper.ContainsPoint(x1, x2, x3, x4);
                
                Console.ForegroundColor = belongs ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine($"Точка ({x1}, {x2}, {x3}, {x4}) {(belongs ? "НАЛЕЖИТЬ" : "НЕ НАЛЕЖИТЬ")} гіперплощині");
                Console.ResetColor();
            }

            Console.WriteLine("\n\n╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  Програма завершена                                       ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.ReadKey();
        }
    }
}
