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
    /// Interaction logic for HighScores.xaml
    /// </summary>
    public partial class HighScores : Window
    {
        /// <summary>
        /// The high scores object.
        /// </summary>
        private HighScoreLogic highScores;

#region constructor
        /// <summary>
        /// The default constructor
        /// </summary>
        public HighScores(HighScoreLogic highScores)
        {
            try
            {
                this.highScores = highScores;

                InitializeComponent();

                FillHighScores();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// The constructor after a game
        /// </summary>
        public HighScores(HighScoreLogic highScores, UserScore score)
        {
            try
            {
                this.highScores = highScores;

                InitializeComponent();

                FillHighScores();

                lblYourScore.Visibility = Visibility.Visible;
                lblCurrentScore.Content = score.ToString();
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
        /// The event handler for the Back button
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void btnHighScoreBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

#region private methods
        /// <summary>
        /// Fills the high score list
        /// </summary>
        private void FillHighScores()
        {
            try
            {
                String[] scores = highScores.GetHighScoreArray();

                lbl1.Content = (scores.Length > 0) ? scores[0] : "";
                lbl2.Content = (scores.Length > 1) ? scores[1] : "";
                lbl3.Content = (scores.Length > 2) ? scores[2] : "";
                lbl4.Content = (scores.Length > 3) ? scores[3] : "";
                lbl5.Content = (scores.Length > 4) ? scores[4] : "";
                lbl6.Content = (scores.Length > 5) ? scores[5] : "";
                lbl7.Content = (scores.Length > 6) ? scores[6] : "";
                lbl8.Content = (scores.Length > 7) ? scores[7] : "";
                lbl9.Content = (scores.Length > 8) ? scores[8] : "";
                lbl10.Content = (scores.Length > 9) ? scores[9] : "";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
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
