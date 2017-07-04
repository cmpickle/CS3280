using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Game
    {
        private string type = "Addition";
        GameUIView gameUIView;

        public Game(string type)
        {
            this.type = type;
        }

        public void AttatchView(GameUIView gameUIView)
        {
            this.gameUIView = gameUIView;

            gameUIView.UpdateQuestion(GenerateQuestion());
        }

        private String GenerateQuestion()
        {
            String result;

            switch(type)
            {
                case "Addition":
                    result = GenerateAdditionQuestion();
                    break;
                case "Subtraction":
                    result = GenerateSubtractionQuestion();
                    break;
                case "Multiplication":
                    result = GenerateMultiplicationQuestion();
                    break;
                case "Division":
                    result = GenerateDivisionQuestion();
                    break;
                default:
                    result = "Error! Something went wrong.";
                    break;
            }

            return result;
        }

        private String GenerateAdditionQuestion()
        {
            Random rand = new Random();
            int first = rand.Next(1, 20);
            int second = rand.Next(1, 20);

            return "" + first + " + " + second + " = ";
        }

        private String GenerateSubtractionQuestion()
        {
            Random rand = new Random();
            int first = rand.Next(1, 19);
            int second;
            do
            {
                second = rand.Next(1, 20);
            } while (first <= second);

            return "" + first + " - " + second + " = ";
        }

        private String GenerateMultiplicationQuestion()
        {
            Random rand = new Random();
            int first = rand.Next(1, 13);
            int second = rand.Next(1, 13);

            return "" + first + " * " + second + " = ";
        }

        private String GenerateDivisionQuestion()
        {
            Random rand = new Random();
            int first = rand.Next(1, 21);
            int second;
            do
            {
                second = rand.Next(1, 20);
            } while (first < second || first % second != 0);

            return "" + first + " / " + second + " = ";
        }
    }
}
