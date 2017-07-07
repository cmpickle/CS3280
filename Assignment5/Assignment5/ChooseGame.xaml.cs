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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ChooseGame : Window
    {
#region class fields
        /// <summary>
        /// The current player's name
        /// </summary>
        private User player;
        /// <summary>
        /// The high scores object
        /// </summary>
        private HighScoreLogic highScores;
        #endregion

#region constructor
        /// <summary>
        /// The constructor for choosing a game
        /// </summary>
        /// <param name="player">Current player's name</param>
        public ChooseGame(User player, HighScoreLogic highScores)
        {
            try
            {
                InitializeComponent();

                this.player = player;
                this.highScores = highScores;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

#region event handlers
        /// <summary>
        /// The button event handler for the various game types
        /// </summary>
        /// <param name="sender">The sender object {Addition button, Subtraction button, Multiplication button, or Division button}</param>
        /// <param name="e">The event args</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;

                GameUI gameUI;

                switch (button.Name)
                {
                    case "btnAddition":
                        gameUI = new GameUI("Addition");
                        break;
                    case "btnSubtraction":
                        gameUI = new GameUI("Subtraction");
                        break;
                    case "btnMultiplication":
                        gameUI = new GameUI("Multiplication");
                        break;
                    case "btnDivision":
                        gameUI = new GameUI("Division");
                        break;
                    default:
                        gameUI = new GameUI();
                        break;
                }

                gameUI.setPlayer(player, highScores);
                gameUI.ShowDialog();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// The event handler for the Back button
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void btnGameModeBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
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
