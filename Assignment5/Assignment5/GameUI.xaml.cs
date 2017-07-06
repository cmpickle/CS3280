using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Assignment5
{
    /// <summary>
    /// Interaction logic for GameUI.xaml
    /// </summary>
    public partial class GameUI : Window, GameUIView
    {
#region class fields
        /// <summary>
        /// The type of game the player selected
        /// </summary>
        String gameType;
        /// <summary>
        /// The game object that represents the current game
        /// </summary>
        private Game game;
        #endregion

#region constructor
        /// <summary>
        /// The default constructor
        /// </summary>
        public GameUI()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Constructs the Game UI of type {Addition, Subtraction, Multiplication, Division} type
        /// </summary>
        /// <param name="type">The game type {Addition, Subtraction, Multiplication, Division}</param>
        public GameUI(String type)
        {
            try
            {
                gameType = type;

                InitializeComponent();

                game = new Game(gameType);
                game.AttatchView(this);

                base.Title = gameType + " Game";
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
#endregion

        /// <summary>
        /// Passes the player game to the game object
        /// </summary>
        /// <param name="playerName"></param>
        public void setPlayerName(String playerName)
        {
            try
            {
                game.setPlayerName(playerName);
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

#region event handlers
        /// <summary>
        /// The event handler for the Submit button
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void btnGameSubmit_PreviewKeyDown(object sender, KeyEventArgs arg)
        {
            try
            {
                if (!((arg.Key >= Key.D0 && arg.Key <= Key.D9) || arg.Key >= Key.NumPad0 && arg.Key <= Key.NumPad9))
                {
                    if (!(arg.Key == Key.Back || arg.Key == Key.Delete))
                    {
                        arg.Handled = true;
                    }
                    game.SubmitAnswer(txtAnswer.Text);
                }
            } 
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            } 
        }
#endregion

        #region GUI controls
        /// <summary>
        /// Updates the question label
        /// </summary>
        /// <param name="question">The new question string</param>
        public void UpdateQuestion(String question)
        {
            try
            {
                lblProblem.Content = question;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        /// <summary>
        /// Updates the score label
        /// </summary>
        /// <param name="score">The new score string</param>
        public void UpdateScore(string score)
        {
            try
            {
                lblScore.Content = score;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        /// <summary>
        /// Updates the timer label
        /// </summary>
        /// <param name="time">The new timer string</param>
        public void UpdateTimer(String time)
        {
            try
            {
                lblTimer.Content = time;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        /// <summary>
        /// Clears the txtAnser box
        /// </summary>
        public void ClearTxtAnswer()
        {
            try
            {
                txtAnswer.Text = "";
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        /// <summary>
        /// Closes the window
        /// </summary>
        public void CloseWindow()
        {
            try
            {
                this.Close();
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
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
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText("C:\\" + System.AppDomain.CurrentDomain.FriendlyName + "Error.txt", Environment.NewLine + "HandleError Exception: " + e.Message);
            }
        }
#endregion
    }
}
