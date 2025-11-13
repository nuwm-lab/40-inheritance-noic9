using System;
using System.Linq;

namespace LabWork
{
    public class Pryama
    {
        protected const double Epsilon = 1e-10;

        private double _a0;
        private double _a1;
        private double _a2;


        public double A0
        {
            get => _a0;
            protected set => _a0 = value;
        }


        public double A1
        {
            get => _a1;
            protected set => _a1 = value;
        }


        public double A2
        {
            get => _a2;
            protected set => _a2 = value;
        }

        public Pryama()
        {
            _a0 = 0;
            _a1 = 0;
            _a2 = 0;
        }

        public Pryama(double a0, double a1, double a2)
        {
            _a0 = a0;
            _a1 = a1;
            _a2 = a2;
        }


        public virtual void SetCoefficients(params double[] coefficients)
        {
            if (coefficients == null)
            {
                throw new ArgumentNullException(nameof(coefficients), "Масив коефіцієнтів не може бути null");
            }

            if (coefficients.Length != 3)
            {
                throw new ArgumentException(
                    "Для прямої потрібно рівно 3 коефіцієнти у порядку: a0 (вільний член), a1 (при x), a2 (при y)",
                    nameof(coefficients));
            }

            _a0 = coefficients[0];
            _a1 = coefficients[1];
            _a2 = coefficients[2];
        }

        public virtual void PrintCoefficients()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                         ПРЯМА                             ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.WriteLine($"Рівняння: ({_a1})*x + ({_a2})*y + ({_a0}) = 0");
            Console.WriteLine($"Коефіцієнти:");
            Console.WriteLine($"  • a0 (вільний член) = {_a0}");
            Console.WriteLine($"  • a1 (при x)        = {_a1}");
            Console.WriteLine($"  • a2 (при y)        = {_a2}");
        }

        public virtual bool ContainsPoint(params double[] point)
        {
            if (point == null)
            {
                throw new ArgumentNullException(nameof(point), "Координати точки не можуть бути null");
            }

            if (point.Length != 2)
            {
                throw new ArgumentException(
                    "Для прямої потрібно рівно 2 координати точки: x, y",
                    nameof(point));
            }

            double x = point[0];
            double y = point[1];

            double result = _a1 * x + _a2 * y + _a0;

            return Math.Abs(result) < Epsilon;
        }

        public override string ToString()
        {
            return $"Пряма: ({_a1})*x + ({_a2})*y + ({_a0}) = 0";
        }
    }


    public class Giperploschyna : Pryama
    {
        private double _a3;
        private double _a4;

        public double A3
        {
            get => _a3;
            private set => _a3 = value;
        }

        public double A4
        {
            get => _a4;
            private set => _a4 = value;
        }

        public Giperploschyna() : base()
        {
            _a3 = 0;
            _a4 = 0;
        }

        public Giperploschyna(double a0, double a1, double a2, double a3, double a4)
            : base(a0, a1, a2)
        {
            _a3 = a3;
            _a4 = a4;
        }

        public override void SetCoefficients(params double[] coefficients)
        {
            if (coefficients == null)
            {
                throw new ArgumentNullException(nameof(coefficients), "Масив коефіцієнтів не може бути null");
            }

            if (coefficients.Length != 5)
            {
                throw new ArgumentException(
                    "Для гіперплощини потрібно рівно 5 коефіцієнтів у порядку: a0 (вільний член), a1 (при x1), a2 (при x2), a3 (при x3), a4 (при x4)",
                    nameof(coefficients));
            }

            A0 = coefficients[0];
            A1 = coefficients[1];
            A2 = coefficients[2];
            _a3 = coefficients[3];
            _a4 = coefficients[4];
        }

        public override void PrintCoefficients()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                     ГІПЕРПЛОЩИНА                          ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.WriteLine($"Рівняння: ({_a4})*x4 + ({_a3})*x3 + ({A2})*x2 + ({A1})*x1 + ({A0}) = 0");
            Console.WriteLine($"Коефіцієнти:");
            Console.WriteLine($"  • a0 (вільний член) = {A0}");
            Console.WriteLine($"  • a1 (при x1)       = {A1}");
            Console.WriteLine($"  • a2 (при x2)       = {A2}");
            Console.WriteLine($"  • a3 (при x3)       = {_a3}");
            Console.WriteLine($"  • a4 (при x4)       = {_a4}");
        }

        public override bool ContainsPoint(params double[] point)
        {
            if (point == null)
            {
                throw new ArgumentNullException(nameof(point), "Координати точки не можуть бути null");
            }

            if (point.Length != 4)
            {
                throw new ArgumentException(
                    "Для гіперплощини потрібно рівно 4 координати точки: x1, x2, x3, x4",
                    nameof(point));
            }

            double x1 = point[0];
            double x2 = point[1];
            double x3 = point[2];
            double x4 = point[3];

            double result = _a4 * x4 + _a3 * x3 + A2 * x2 + A1 * x1 + A0;

            return Math.Abs(result) < Epsilon;
        }

        public override string ToString()
        {
            return $"Гіперплощина: ({_a4})*x4 + ({_a3})*x3 + ({A2})*x2 + ({A1})*x1 + ({A0}) = 0";
        }
    }

    public static class InputHelper
    {

        public static double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (double.TryParse(input, out double result))
                {
                    return result;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Помилка! Введіть коректне число.");
                Console.ResetColor();
            }
        }

        public static int ReadInt(string prompt, int minValue = int.MinValue)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (int.TryParse(input, out int result) && result >= minValue)
                {
                    return result;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ Помилка! Введіть коректне ціле число (мінімум {minValue}).");
                Console.ResetColor();
            }
        }

        public static double[] ReadCoefficients(int count, string typeName)
        {
            double[] coefficients = new double[count];
            
            Console.WriteLine($"\n📝 Введіть {count} коефіцієнтів для {typeName}:");
            Console.WriteLine("   Порядок: a0 (вільний член), a1, a2, ...");
            
            for (int i = 0; i < count; i++)
            {
                coefficients[i] = ReadDouble($"   a{i} = ");
            }

            return coefficients;
        }

        public static double[] ReadPoint(int dimension, string[] coordinateNames)
        {
            double[] point = new double[dimension];
            
            for (int i = 0; i < dimension; i++)
            {
                point[i] = ReadDouble($"   {coordinateNames[i]} = ");
            }

            return point;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  Робота з класами 'Пряма' та 'Гіперплощина'              ║");
            Console.WriteLine("║  Виконав: noic9                                           ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");

            try
            {
                WorkWithPryama();

                Console.WriteLine("\n\n");

                WorkWithGiperploschyna();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n❌ Критична помилка: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("\n\n╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  Програма завершена. Натисніть будь-яку клавішу...       ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.ReadKey();
        }

        static void WorkWithPryama()
        {
            Console.WriteLine("┌─────────────────────────────────────────────────────────┐");
            Console.WriteLine("│ 1. ПРЯМА (a1*x + a2*y + a0 = 0)                         │");
            Console.WriteLine("└─────────────────────────────────────────────────────────┘");

            Pryama pryama = new Pryama();

            double[] coefficients = InputHelper.ReadCoefficients(3, "прямої");
            pryama.SetCoefficients(coefficients);

            Console.WriteLine();
            pryama.PrintCoefficients();

            Console.WriteLine("\n┌─── Перевірка належності точок прямій ───┐");
            int pointCount = InputHelper.ReadInt("\nВведіть кількість точок для перевірки: ", 0);

            for (int i = 0; i < pointCount; i++)
            {
                Console.WriteLine($"\n📍 Точка #{i + 1}:");
                double[] point = InputHelper.ReadPoint(2, new[] { "x", "y" });

                bool belongs = pryama.ContainsPoint(point);

                Console.ForegroundColor = belongs ? ConsoleColor.Green : ConsoleColor.Yellow;
                Console.WriteLine($"   Результат: Точка ({point[0]}, {point[1]}) " +
                                $"{(belongs ? "✓ НАЛЕЖИТЬ" : "✗ НЕ НАЛЕЖИТЬ")} прямій");
                Console.ResetColor();
            }

            // Демонстрація властивостей
            Console.WriteLine("\n┌─── Доступ через властивості ───┐");
            Console.WriteLine($"A0 = {pryama.A0}");
            Console.WriteLine($"A1 = {pryama.A1}");
            Console.WriteLine($"A2 = {pryama.A2}");
            Console.WriteLine($"ToString(): {pryama}");
        }

        static void WorkWithGiperploschyna()
        {
            Console.WriteLine("┌─────────────────────────────────────────────────────────┐");
            Console.WriteLine("│ 2. ГІПЕРПЛОЩИНА (a4*x4 + a3*x3 + a2*x2 + a1*x1 + a0 = 0)│");
            Console.WriteLine("└─────────────────────────────────────────────────────────┘");

            Giperploschyna giper = new Giperploschyna();

            double[] coefficients = InputHelper.ReadCoefficients(5, "гіперплощини");
            giper.SetCoefficients(coefficients);

            Console.WriteLine();
            giper.PrintCoefficients();

            Console.WriteLine("\n┌─── Перевірка належності точок гіперплощині ───┐");
            int pointCount = InputHelper.ReadInt("\nВведіть кількість точок для перевірки: ", 0);

            for (int i = 0; i < pointCount; i++)
            {
                Console.WriteLine($"\n📍 Точка #{i + 1} (4-вимірний простір):");
                double[] point = InputHelper.ReadPoint(4, new[] { "x1", "x2", "x3", "x4" });

                bool belongs = giper.ContainsPoint(point);

                Console.ForegroundColor = belongs ? ConsoleColor.Green : ConsoleColor.Yellow;
                Console.WriteLine($"   Результат: Точка ({string.Join(", ", point)}) " +
                                $"{(belongs ? "✓ НАЛЕЖИТЬ" : "✗ НЕ НАЛЕЖИТЬ")} гіперплощині");
                Console.ResetColor();
            }

            Console.WriteLine("\n┌─── Доступ через властивості ───┐");
            Console.WriteLine($"A0 = {giper.A0}");
            Console.WriteLine($"A1 = {giper.A1}");
            Console.WriteLine($"A2 = {giper.A2}");
            Console.WriteLine($"A3 = {giper.A3}");
            Console.WriteLine($"A4 = {giper.A4}");
            Console.WriteLine($"ToString(): {giper}");
        }
    }
}
