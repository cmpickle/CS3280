using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Assignment5
{
    class Game
    {
        private string type = "Addition";
        private GameUIView gameUIView;

        private DispatcherTimer timer;

        private String playerName;
        private int currentAnswer;
        private int score = 0;
        private int questionNum = 10;
        private int time = 0;

        public Game(string type)
        {
            this.type = type;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += UpdateTimer;
            timer.Start();
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

        public void setPlayerName(String playerName)
        {
            this.playerName = playerName;
        }

        private String GenerateAdditionQuestion()
        {
            Random rand = new Random();
            int first = rand.Next(1, 20);
            int second = rand.Next(1, 20);

            currentAnswer = first + second;

            return "" + first + " + " + second + " = ";
        }

        private String GenerateSubtractionQuestion()
        {
            Random rand = new Random();
            int first = rand.Next(1, 21);
            int second;
            do
            {
                second = rand.Next(1, 20);
            } while (first <= second);

            currentAnswer = first - second;

            return "" + first + " - " + second + " = ";
        }

        private String GenerateMultiplicationQuestion()
        {
            Random rand = new Random();
            int first = rand.Next(1, 13);
            int second = rand.Next(1, 13);

            currentAnswer = first * second;

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

            currentAnswer = first / second;

            return "" + first + " / " + second + " = ";
        }

        public void SubmitAnswer(String input)
        {
            int answer;
            Int32.TryParse(input, out answer);

            if(answer == currentAnswer)
            {
                ++score;

                gameUIView.UpdateScore(String.Format("Score: {0}", score));
            }

            --questionNum;
            if(questionNum == 0)
            {
                timer.Stop();
                HighScores highScores = new HighScores();
                gameUIView.CloseWindow();
                highScores.ShowDialog();
            }
            gameUIView.ClearTxtAnswer();

            gameUIView.UpdateQuestion(GenerateQuestion());
        }

        private void UpdateTimer(Object sender, EventArgs e)
        {
            ++time;

            TimeSpan span = TimeSpan.FromSeconds(time);
             gameUIView.UpdateTimer(span.ToString("mm':'ss"));
        }
    }
}
