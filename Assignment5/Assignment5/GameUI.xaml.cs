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
    /// Interaction logic for GameUI.xaml
    /// </summary>
    public partial class GameUI : Window, GameUIView
    {
        String gameType;
        private Game game;

        public GameUI()
        {
            InitializeComponent();
        }

        public GameUI(String type)
        {
            gameType = type;

            InitializeComponent();

            game = new Game(gameType);
            game.AttatchView(this);

            base.Title = gameType + " Game";
        }

        private void btnGameSubmit_Click(object sender, RoutedEventArgs e)
        {
            game.SubmitAnswer(txtAnswer.Text);
        }

        public void UpdateQuestion(String question)
        {
            lblProblem.Content = question;
        }

        public void UpdateScore(string score)
        {
            lblScore.Content = score;
        }
    }
}
