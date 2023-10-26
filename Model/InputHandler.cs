
namespace Calculator.Model
{
    internal class InputHandler
    {
        private string action = string.Empty;

        public string GetInputValue()
        {
            action = Console.ReadLine() ?? "Необходимо ввести значение!";
            return action;
        }

        public string GetInputValue(string messeage)
        {
            action = Console.ReadLine() ?? $"{messeage}";
            return action;
        }
    }
}
