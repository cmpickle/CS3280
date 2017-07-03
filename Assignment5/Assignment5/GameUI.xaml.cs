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
    public partial class GameUI : Window
    {
        String gameType;

        public GameUI()
        {
            InitializeComponent();
        }

        public GameUI(String type)
        {
            gameType = type;

            InitializeComponent();

            base.Title = gameType + " Game";
        }
    }
}
