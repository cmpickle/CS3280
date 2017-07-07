using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Assignment5
{
    /// <summary>
    /// Represents a math game. Controls the game logic and sends update requests to the GUI via the interface.
    /// </summary>
    class Game
    {
        #region class fields
        /// <summary>
        /// The type of game
        /// </summary>
        private string type = "Addition";
        /// <summary>
        /// The interface to communicate with the GUI
        /// </summary>
        private GameUIView gameUIView;

        /// <summary>
        /// The game timer
        /// </summary>
        private DispatcherTimer timer;

        /// <summary>
        /// The current player's name
        /// </summary>
        private User player;
        /// <summary>
        /// The high scores object
        /// </summary>
        private HighScoreLogic highScoresLogic;
        /// <summary>
        /// The correct answer for the current question
        /// </summary>
        private int currentAnswer;
        /// <summary>
        /// The player's score
        /// </summary>
        private int score = 0;
        /// <summary>
        /// How many questions remain for this game
        /// </summary>
        private int questionNum = 10;
        /// <summary>
        /// Game time in seconds
        /// </summary>
        private int time = 0;
        /// <summary>
        /// An array of Bitmap images to display to the user after they answer a question.
        /// indices 0-2 are for wrong answers and indices 3-5 are for correct answers.
        /// </summary>
        private BitmapImage[] images = {    new BitmapImage(new Uri("/Images/JarJar.png", UriKind.Relative)),
                                            new BitmapImage(new Uri("/Images/JarJarGaping.jpg", UriKind.Relative)),
                                            new BitmapImage(new Uri("/Images/JarJarScared.jpg", UriKind.Relative)),
                                            new BitmapImage(new Uri("/Images/ObiWan.jpg", UriKind.Relative)),
                                            new BitmapImage(new Uri("/Images/Rey.jpg", UriKind.Relative)),
                                            new BitmapImage(new Uri("/Images/Yoda.jpg", UriKind.Relative))};
        #endregion

        #region constructor
        /// <summary>
        /// Constructs a game of type (type)
        /// </summary>
        /// <param name="type">The type of game {Addition, Subtraction, Multiplication, or Division}</param>
        public Game(string type)
        {
            try
            {
                this.type = type;

                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(1000);
                timer.Tick += UpdateTimer;
                timer.Start();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        #region public methods
        /// <summary>
        /// Attatches the GUI to the current game
        /// </summary>
        /// <param name="gameUIView">The GUI that implements the GameUIView</param>
        public void AttatchView(GameUIView gameUIView)
        {
            this.gameUIView = gameUIView;

            gameUIView.UpdateQuestion(GenerateQuestion());
        }

        /// <summary>
        /// Sets the player name for the current game
        /// </summary>
        /// <param name="player">The current user's name</param>
        public void setPlayerName(User player, HighScoreLogic highScores)
        {
            try
            {
                this.player = player;

                this.highScoresLogic = highScores;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Verifies if the user's input is correct or not. Applies game logic based on result.
        /// </summary>
        /// <param name="input">The user's answer</param>
        public void SubmitAnswer(String input)
        {
            try
            {
                int answer;
                Int32.TryParse(input, out answer);

                if (answer == currentAnswer)
                {
                    ++score;

                    gameUIView.UpdateScore(String.Format("Score: {0}", score));

                    DisplayCorrect();
                }
                else
                {
                    DisplayIncorrect();
                }

                --questionNum;
                if (questionNum == 0)
                {
                    timer.Stop();
                    highScoresLogic.AddScore(new UserScore(player.Name, score, time, type));
                    HighScores highScores = new HighScores(highScoresLogic, new UserScore(player.Name, score, time, type));
                    gameUIView.CloseWindow();
                    highScores.ShowDialog();
                }
                gameUIView.ClearTxtAnswer();

                gameUIView.UpdateQuestion(GenerateQuestion());
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        #region private methods
        /// <summary>
        /// Returns a question for the appropriate game type
        /// </summary>
        /// <returns>question string</returns>
        private String GenerateQuestion()
        {
            String result = "Error!";

            try
            {
                switch (type)
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
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Returns a random addition question
        /// </summary>
        /// <returns>addition question string</returns>
        private String GenerateAdditionQuestion()
        {
            Random rand = new Random();
            int first = rand.Next(1, 20);
            int second = rand.Next(1, 20);

            currentAnswer = first + second;

            return "" + first + " + " + second + " = ";
        }

        /// <summary>
        /// Returns a random subtraction question
        /// </summary>
        /// <returns>subtraction question string</returns>
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

        /// <summary>
        /// Returns a random multiplication question
        /// </summary>
        /// <returns>multiplication question string</returns>
        private String GenerateMultiplicationQuestion()
        {
            Random rand = new Random();
            int first = rand.Next(1, 13);
            int second = rand.Next(1, 13);

            currentAnswer = first * second;

            return "" + first + " * " + second + " = ";
        }

        /// <summary>
        /// Returns a random division question
        /// </summary>
        /// <returns>division question string</returns>
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

        /// <summary>
        /// Updates the time variable on the timer and tells the GUI to update.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void UpdateTimer(Object sender, EventArgs e)
        {
            try
            {
                ++time;

                TimeSpan span = TimeSpan.FromSeconds(time);
                gameUIView.UpdateTimer(span.ToString("mm':'ss"));
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Updates the GUI to diplay that they were incorrect
        /// </summary>
        private void DisplayIncorrect()
        {
            try
            {
                Random rand = new Random();
                gameUIView.DisplayResultLabel("incorrect!", new SolidColorBrush(Color.FromRgb(255, 0, 0)));

                gameUIView.DisplayResultImg(images[rand.Next(3)]);
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Updates the GUI to diplay that they were correct
        /// </summary>
        private void DisplayCorrect()
        {
            try
            {
                Random rand = new Random();
                gameUIView.DisplayResultLabel("correct!", new SolidColorBrush( Color.FromRgb(0,255,0)));

                gameUIView.DisplayResultImg(images[rand.Next(3, 6)]);
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        #region error handling
        /// <summary>
        /// The error handling method. This prints out a user readable stack trace for debugging purposes.
        /// </summary>
        /// <param name="sClass">The class the error originated from</param>
        /// <param name="sMethod">The method the error originated from</param>
        /// <param name="sMessage">The error message</param>
        private void HandleError(String sClass, String sMethod, String sMessage)
        {
            try
            {
                gameUIView.ShowError(sClass + "." + sMethod + " -> " + Environment.NewLine + sMessage);
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText("C:\\" + System.AppDomain.CurrentDomain.FriendlyName + "Error.txt", Environment.NewLine + "HandleError Exception: " + e.Message);
            }
        }
        #endregion
    }
}
