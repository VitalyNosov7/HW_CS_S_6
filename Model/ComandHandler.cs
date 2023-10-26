using Calculator.View;

namespace Calculator.Model
{
    internal class ComandHandler
    {
        private MessegerCalculator messegerComandHandler = new MessegerCalculator();
        private OperationCalculator operationCalculator = new OperationCalculator();
        private CalculatorCommands calculatorCommands = new CalculatorCommands();
        private InputHandler inputHandler = new InputHandler();

        public void LaunchHandler()
        {
            string action = string.Empty;
            double firstValue, secondValue;

            while (true)
            {
                calculatorCommands.ViewCommands();

                action = inputHandler.GetInputValue("Ожидается ввод  (+), (-), (*), (/)  или (q)!");

                if (action == "+" || action == "-" || action == "*" || action == "/" || action == "q")
                {

                    if (action == "q")
                    {
                        messegerComandHandler.DisplayMessage("Выполнение расчёта прервано пользователем!\nВыход из программы!");
                        break;
                    }

                    messegerComandHandler.DisplayMessage("Введите числовые значения(В качестве разделителя используйте (,):\n");
                    try
                    {
                        messegerComandHandler.DisplayMessage("Введите первое число:");
                        firstValue = double.Parse(inputHandler.GetInputValue());
                    }
                    catch (Exception)
                    {
                        messegerComandHandler.DisplayMessage("Введено не число!");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }

                    try
                    {
                        messegerComandHandler.DisplayMessage("Введите второе число:)");
                        secondValue = double.Parse(inputHandler.GetInputValue());
                    }
                    catch (Exception)
                    {
                        messegerComandHandler.DisplayMessage("Введено не число!");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }

                    switch (action)
                    {
                        case "+":
                            operationCalculator.Add(firstValue, secondValue);
                            break;

                        case "-":
                            operationCalculator.Sub(firstValue, secondValue);
                            break;

                        case "*":
                            operationCalculator.Mul(firstValue, secondValue);
                            break;

                        case "/":
                            operationCalculator.Div(firstValue, secondValue);
                            break;
                        default:

                            messegerComandHandler.DisplayMessage("Некорректное действие!");
                            break;
                    }

                    messegerComandHandler.DisplayMessage($"Результат вычисления = {operationCalculator.GetResult()}");
                    messegerComandHandler.DisplayMessage("===================================================\n" +
                                                         "Для продолжения нажмите (Y). Для выхода нажмите (q)\n" +
                                                         "===================================================\n");
                }
                else
                {
                    messegerComandHandler.DisplayMessage("Введен не верный оператор!\nПопробуйте еще раз.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                action = inputHandler.GetInputValue("Ожидается ввод  (y) или (q)!");

                if (action == "y")
                {
                    Console.Clear();
                    continue;
                }
                else if (action == "q")
                {
                    Console.Clear();
                    messegerComandHandler.DisplayMessage("Выход из программы!");
                    break;
                }
            }

            messegerComandHandler.DisplayMessage("Программа завершена.");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}