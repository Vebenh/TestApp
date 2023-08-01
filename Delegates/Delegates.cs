using System;
namespace TestApp.Delegates
{
    public class Delegates
    {
        delegate void Action(int x, int y, Operations operation);
        delegate void MessageAction(string text);

        private string? text1 { get; set; }
        private string? text2 { get; set; }
        private int x { get; set; }

        public enum Operations
        {
            Mult,
            Div,
            Sum,
            Subt
        }

        public Delegates(string? text1, string text2, int number1 = 0, int number2 = 0, Operations operation = Operations.Sum)
        {
            this.text1 = text1;
            MessageAction action = modifyText;
            action += printText;
            action(text2);

            Action message = makeOperation;
            message(number1, number2, operation);

            printInt();
        }

        private void modifyText(string text)
        {
            this.text1 += text ?? "Oh";
        }

        private void printText(string text)
        {
            Console.WriteLine(this.text1);
        }

        private void makeOperation(int number1, int number2, Operations operation)
        {
            switch (operation)
            {
                case Operations.Mult:
                    this.x = number1 * number2;
                    break;
                case Operations.Div:
                    this.x = number1 / number2;
                    break;
                case Operations.Subt:
                    this.x = number1 - number2;
                    break;
                case Operations.Sum:
                    this.x = number1 + number2;
                    break;

            }
        }

        private void printInt()
        {
            Console.WriteLine(this.x);
        }

    }
}

