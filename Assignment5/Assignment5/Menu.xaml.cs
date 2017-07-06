using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Menu : Window
    {
#region class fields
        /// <summary>
        /// The name of the current player
        /// </summary>
        User player;
        /// <summary>
        /// The Sound Player for the main theme
        /// </summary>
        SoundPlayer mainTheme;
#endregion

        #region constructor
        /// <summary>
        /// The default constructor
        /// </summary>
        public Menu()
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
        /// The constructor that takes a string for the current player's name
        /// </summary>
        /// <param name="player">The current player</param>
        public Menu(User player)
        {
            try
            {

                this.player = player;

                mainTheme = new SoundPlayer("Star Wars Main Theme.wav");
                mainTheme.Play();

                InitializeComponent();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
            finally
            {
                mainTheme.Stop();
            }
        }
#endregion

        #region event handlers
        /// <summary>
        /// The event handler for the play game button
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void btnPlayGame_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ChooseGame chooseGame = new ChooseGame(player);
                //mainTheme.Stop();
                chooseGame.ShowDialog();
                //mainTheme.Play();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
            finally
            {

            }
        }

        /// <summary>
        /// The event handler of the high scores button
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void btnHighScores_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HighScores highScores = new HighScores();
                highScores.ShowDialog();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// The event handler of the Edit User Info button
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void btnEditUserInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserInfo userInfo = new UserInfo(player);
                this.Close();
                userInfo.Show();
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
                MessageBox.Show(sClass + "." + sMethod + " -> " + Environment.NewLine + sMessage);
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText("C:\\" + System.AppDomain.CurrentDomain.FriendlyName + "Error.txt", Environment.NewLine + "HandleError Exception: " + e.Message);
            }
        }
#endregion
    }
}
