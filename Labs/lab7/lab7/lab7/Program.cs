namespace Calculate
{
    public class Calculator
    {
        static void Main(string[] args)
        {
            double num1, num2;

            Console.WriteLine("Простой калькулятор");
            Console.WriteLine("Доступные операции: +, -, *, /");

            Console.Write("Введите первое число: ");
            num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите операцию: ");
            char operation = Console.ReadLine()[0];

            Console.Write("Введите второе число: ");
            num2 = Convert.ToDouble(Console.ReadLine());

            double result = PerformOperation(num1, num2, operation);

            Console.WriteLine("Результат: " + result);
        }

        static double PerformOperation(double num1, double num2, char operation)
        {
            double result = 0.0;

            switch (operation)
            {
                case '+':
                    result = Add(num1, num2);
                    break;
                case '-':
                    result = Subtract(num1, num2);
                    break;
                case '*':
                    result = Multiply(num1, num2);
                    break;
                case '/':
                    if (num2 != 0)
                    {
                        result = Divide(num1, num2);
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: Нельзя делить на ноль.");
                    }
                    break;
                default:
                    Console.WriteLine("Ошибка: Неверная операция.");
                    break;
            }

            return result;
        }

        public static double Add(double a, double b)
        {
            return a + b;
        }

        public static double Subtract(double a, double b)
        {
            return a - b;
        }

        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        public static double Divide(double a, double b)
        {
            return a / b;
        }
    }
}
