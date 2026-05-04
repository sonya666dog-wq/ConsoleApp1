using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Комплекс задач ===");
                Console.WriteLine("1. Перемешать массив");
                Console.WriteLine("2. Проверка палиндрома");
                Console.WriteLine("3. Калькулятор");
                Console.WriteLine("4. Максимум из трёх чисел");
                Console.WriteLine("5. Синус/косинус угла");
                Console.WriteLine("6. Вывести текущую дату и время");
                Console.WriteLine("7. Перевернуть строку");
                Console.WriteLine("8. Сумма цифр в строке");
                Console.WriteLine("9. Класс Point");
                Console.WriteLine("10. Класс Triangle");
                Console.WriteLine("11. Класс Rectangle");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите пункт: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": Task1(); break;
                    case "2": Task2(); break;
                    case "3": Task3(); break;
                    case "4": Task4(); break;
                    case "5": Task5(); break;
                    case "6": Task6(); break;
                    case "7": Task7(); break;
                    case "8": Task8(); break;
                    case "9": Task9(); break;
                    case "10": Task10(); break;
                    case "11": Task11(); break;
                    case "0": return;
                    default: Console.WriteLine("Неверный ввод"); break;
                }
                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }

        static void Task1()
        {
            Console.Write("Введите числа через пробел: ");
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Random rnd = new Random();
            for (int i = arr.Length - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
            Console.WriteLine("Перемешанный массив: " + string.Join(" ", arr));
        }

        static void Task2()
        {
            Console.Write("Введите строку: ");
            string s = Console.ReadLine();
            string cleaned = new string(s.Where(char.IsLetterOrDigit).ToArray()).ToLower();
            char[] rev = cleaned.ToCharArray();
            Array.Reverse(rev);
            bool isPalindrome = cleaned == new string(rev);
            Console.WriteLine(isPalindrome ? "Строка - палиндром" : "Строка НЕ палиндром");
        }

        static void Task3()
        {
            Console.Write("Введите число A: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введите оператор (+, -, *, /): ");
            char op = Console.ReadLine()[0];
            Console.Write("Введите число B: ");
            double b = double.Parse(Console.ReadLine());

            double res;
            switch (op)
            {
                case '+': res = a + b; break;
                case '-': res = a - b; break;
                case '*': res = a * b; break;
                case '/': res = b != 0 ? a / b : double.NaN; break;
                default: res = double.NaN; break;
            }

            if (double.IsNaN(res))
                Console.WriteLine("Ошибка");
            else
                Console.WriteLine($"Результат: {res}");
        }

        static void Task4()
        {
            Console.Write("Введите три числа через пробел: ");
            double[] nums = Console.ReadLine().Split().Select(double.Parse).ToArray();
            double max = nums[0];
            for (int i = 1; i < nums.Length; i++)
                if (nums[i] > max) max = nums[i];
            Console.WriteLine($"Максимум: {max}");
        }

        static void Task5()
        {
            Console.Write("Введите угол в градусах: ");
            double deg = double.Parse(Console.ReadLine());
            double rad = deg * Math.PI / 180;
            Console.WriteLine("Выберите действие: 1 - синус, 2 - косинус");
            string choice = Console.ReadLine();
            if (choice == "1")
                Console.WriteLine($"sin({deg}) = {Math.Sin(rad)}");
            else if (choice == "2")
                Console.WriteLine($"cos({deg}) = {Math.Cos(rad)}");
            else
                Console.WriteLine("Неверный выбор");
        }

        static void Task6()
        {
            Console.WriteLine($"Текущая дата и время: {DateTime.Now}");
        }

        static void Task7()
        {
            Console.Write("Введите строку: ");
            string s = Console.ReadLine();
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            Console.WriteLine($"Перевёрнутая строка: {new string(arr)}");
        }

        static void Task8()
        {
            Console.Write("Введите строку: ");
            string s = Console.ReadLine();
            int sum = 0;
            foreach (char c in s)
                if (char.IsDigit(c))
                    sum += c - '0';
            Console.WriteLine($"Сумма цифр в строке: {sum}");
        }

        static void Task9()
        {
            Point p1 = new Point();
            Point p2 = new Point(3, 4);
            p1.Show();
            p2.Show();
            Console.WriteLine($"Расстояние p2 от (0,0): {p2.Distance()}");
            p2.Move(1, 1);
            Console.WriteLine("После перемещения на (1,1):");
            p2.Show();
            p2.X = 5;
            p2.Y = 6;
            Console.WriteLine("После ручной установки X=5, Y=6:");
            p2.Show();
            p2.Scale = 2;
            Console.WriteLine("После умножения на 2:");
            p2.Show();
        }

        static void Task10()
        {
            Triangle t = new Triangle(3, 4, 5);
            t.Show();
            Console.WriteLine($"Периметр: {t.Perimeter()}, Площадь: {t.Area():F2}");
            Console.WriteLine($"Треугольник существует: {t.IsExist}");
            t.A = 1; t.B = 1; t.C = 10;
            Console.WriteLine($"Треугольник существует (1,1,10): {t.IsExist}");
        }

        static void Task11()
        {
            Rectangle r = new Rectangle(5, 10);
            r.Show();
            Console.WriteLine($"Периметр: {r.Perimeter()}, Площадь: {r.Area()}");
            Console.WriteLine($"Является квадратом: {r.IsSquare}");
            r.A = 7; r.B = 7;
            Console.WriteLine($"После установки 7x7, квадрат: {r.IsSquare}");
        }
    }

    class Point
    {
        private double x, y;
        public Point() { x = 0; y = 0; }
        public Point(double x, double y) { this.x = x; this.y = y; }
        public void Show() { Console.WriteLine($"Point({x}, {y})"); }
        public double Distance() { return Math.Sqrt(x * x + y * y); }
        public void Move(double a, double b) { x += a; y += b; }
        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public double Scale { set { x *= value; y *= value; } }
    }

    class Triangle
    {
        private double a, b, c;
        public Triangle(double a, double b, double c) { this.a = a; this.b = b; this.c = c; }
        public void Show() { Console.WriteLine($"Triangle({a}, {b}, {c})"); }
        public double Perimeter() { return a + b + c; }
        public double Area()
        {
            double p = Perimeter() / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        public double A { get => a; set => a = value; }
        public double B { get => b; set => b = value; }
        public double C { get => c; set => c = value; }
        public bool IsExist { get { return a + b > c && a + c > b && b + c > a; } }
    }

    class Rectangle
    {
        private double a, b;
        public Rectangle(double a, double b) { this.a = a; this.b = b; }
        public void Show() { Console.WriteLine($"Rectangle({a}, {b})"); }
        public double Perimeter() { return 2 * (a + b); }
        public double Area() { return a * b; }
        public double A { get => a; set => a = value; }
        public double B { get => b; set => b = value; }
        public bool IsSquare { get { return Math.Abs(a - b) < 1e-9; } }
    }
}
