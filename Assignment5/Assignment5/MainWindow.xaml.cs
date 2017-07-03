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
    public partial class MainWindow : Window
    {
        SoundPlayer mainTheme = new SoundPlayer("Star Wars Main Theme.wav");
        public MainWindow()
        {
            mainTheme.Play();

            InitializeComponent();
        }

        private void btnPlayGame_Click(object sender, RoutedEventArgs e)
        {
            ChooseGame chooseGame = new ChooseGame();
            mainTheme.Stop();
            chooseGame.ShowDialog();
            mainTheme.Play();
            //try
            //{



            //}
            //catch (Exception e)
            //{

            //}
            //finally
            //{

            //}
        }

        private void btnHighScores_Click(object sender, RoutedEventArgs e)
        {
            HighScores highScores = new HighScores();
            highScores.ShowDialog();
        }

        private void btnEnterUserInfo_Click(object sender, RoutedEventArgs e)
        {
            UserInfo userInfo = new UserInfo();
            userInfo.ShowDialog();
        }

        private void Method1()
        {
            try
            {

            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

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
    }
}
