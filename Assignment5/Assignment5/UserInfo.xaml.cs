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
    /// Interaction logic for UserInfo.xaml
    /// </summary>
    public partial class UserInfo : Window
    {
        /// <summary>
        /// High score logic object
        /// </summary>
        private HighScoreLogic highScoreLogic = new HighScoreLogic();

#region constructor
        /// <summary>
        /// The default constructor
        /// </summary>
        public UserInfo()
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
        /// Constructs the GUI passing in the player's name
        /// </summary>
        /// <param name="player">The current user's name</param>
        public UserInfo(User player, HighScoreLogic highScoreLogic)
        {
            try
            {
                InitializeComponent();

                txtUserInfoName.Text = player.Name;
                this.highScoreLogic = highScoreLogic;
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
        /// The event handler for the Submit button
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void btnUserInfoSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtUserInfoName.Text == "")
                    return;
                Menu menu = new Menu(new User(txtUserInfoName.Text), highScoreLogic);
                this.Close();
                menu.Show();
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
