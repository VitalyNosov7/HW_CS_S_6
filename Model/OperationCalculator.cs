using Calculator.Model;
using System;

namespace Calculator
{
    internal class OperationCalculator : ICalc
    {
        private MessegerCalculator messegerOperationCalculator = new MessegerCalculator();
        private double result = 0;
        public Stack<Tuple<string, double, double, double>> operation = new Stack<Tuple<string, double, double, double>>();

        public double Add(double a, double b)
        {
            result = a + b;
            operation.Push(new Tuple<string, double, double, double>("+", a, b, result));
            return result;
        }

        public double Sub(double a, double b)
        {
            result = a - b;
            operation.Push(new Tuple<string, double, double, double>("+", a, b, result));
            return result;
        }

        public double Mul(double a, double b)
        {
            result = a * b;
            operation.Push(new Tuple<string, double, double, double>("+", a, b, result));
            return result;
        }

        public double Div(double a, double b)
        {
            if (b == 0)
            {
                result = 0;
                messegerOperationCalculator.DisplayMessage("Попытка деления на ноль!");
                return result;
            }
            else
            {
                result = a / b;
                operation.Push(new Tuple<string, double, double, double>("+", a, b, result));
                return result;
            }
        }

        public double GetResult()
        {
            return result;
        }

        public void CancelLast()
        {
            string currentOperation = operation.Peek().Item1;
            switch (currentOperation)
            {
                case "+":
                    result -= operation.Pop().Item2;
                    break;
                case "-":
                    result += operation.Pop().Item2;
                    break;
                case "*":
                    result /= operation.Pop().Item2;
                    break;
                case "/":
                    result *= operation.Pop().Item2;
                    break;
                default:
                    messegerOperationCalculator.DisplayMessage("Ошибка");
                    break;

            }
        }
    }
}