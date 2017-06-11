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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment4
{
    /// <summary>
    /// Interaction logic for Tick Tack Toe
    /// </summary>
    public partial class TicTacToeGUI : Window, ITicTacToeView
    {
        TicTacToe tickTacToe = new TicTacToe();

        /// <summary>
        /// Constructor for the GUI
        /// </summary>
        public TicTacToeGUI()
        {
            InitializeComponent();
            tickTacToe.SetView(this);
        }

        /// <summary>
        /// The Tick Tac Toe tile button listener
        /// </summary>
        /// <param name="sender">Which tile was pressed</param>
        /// <param name="e">Event args</param>
        private void btnPos_Click(object sender, RoutedEventArgs e)
        {
            Button btnSender = (Button)sender;
            if (tickTacToe.PlayerChoose(btnSender) < 0)
            {
                return;
            }
        }

        /// <summary>
        /// The onClick listener for the Start Game button
        /// </summary>
        /// <param name="sender">The button clicked</param>
        /// <param name="e">Event args</param>
        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            tickTacToe.StartGame();
        }

        /// <summary>
        /// Updates the Game status text box
        /// </summary>
        /// <param name="status"></param>
        public void UpdateGameStatus(string status)
        {
            txtGameStatus.Text = status;
        }

        /// <summary>
        /// Resets the user interface for a new game
        /// </summary>
        public void Reset()
        {
            btnPos0.Content = "";
            btnPos1.Content = "";
            btnPos2.Content = "";
            btnPos3.Content = "";
            btnPos4.Content = "";
            btnPos5.Content = "";
            btnPos6.Content = "";
            btnPos7.Content = "";
            btnPos8.Content = "";

            btnPos0.Background = System.Windows.Media.Brushes.Black;
            btnPos1.Background = System.Windows.Media.Brushes.Black;
            btnPos2.Background = System.Windows.Media.Brushes.Black;
            btnPos3.Background = System.Windows.Media.Brushes.Black;
            btnPos4.Background = System.Windows.Media.Brushes.Black;
            btnPos5.Background = System.Windows.Media.Brushes.Black;
            btnPos6.Background = System.Windows.Media.Brushes.Black;
            btnPos7.Background = System.Windows.Media.Brushes.Black;
            btnPos8.Background = System.Windows.Media.Brushes.Black;
        }

        /// <summary>
        /// Updates the statistics group box based on the played games
        /// </summary>
        public void UpdateStatistics()
        {
            lblPlayer1WinsVal.Content = tickTacToe.Player1Wins;
            lblPlayer2WinsVal.Content = tickTacToe.Player2Wins;
            lblPlayerTiesVal.Content = tickTacToe.PlayerTies;
        }

        /// <summary>
        /// Highlights tiles in a winning row blue
        /// </summary>
        /// <param name="tiles"></param>
        public void WinTiles(int[] tiles)
        {
            foreach(int i in tiles)
            {
                Button btn;
                switch(i)
                {
                    case 0:
                        btn = btnPos0;
                        break;
                    case 1:
                        btn = btnPos1;
                        break;
                    case 2:
                        btn = btnPos2;
                        break;
                    case 3:
                        btn = btnPos3;
                        break;
                    case 4:
                        btn = btnPos4;
                        break;
                    case 5:
                        btn = btnPos5;
                        break;
                    case 6:
                        btn = btnPos6;
                        break;
                    case 7:
                        btn = btnPos7;
                        break;
                    case 8:
                        btn = btnPos8;
                        break;
                    default:
                        btn = btnPos0;
                        break;
                }
                
                btn.Background = System.Windows.Media.Brushes.Blue;
            }
        }
    }
}
