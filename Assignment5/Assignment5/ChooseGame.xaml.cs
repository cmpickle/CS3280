using System;
using System.Collections.Generic;
using System.Linq;
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
        private String playerName;

        public ChooseGame(String playerName)
        {
            InitializeComponent();

            this.playerName = playerName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

            gameUI.setPlayerName(playerName);
            gameUI.ShowDialog();
        }
    }
}
