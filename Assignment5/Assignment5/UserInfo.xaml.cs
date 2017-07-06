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
    /// Interaction logic for UserInfo.xaml
    /// </summary>
    public partial class UserInfo : Window
    {
        public UserInfo()
        {
            InitializeComponent();
        }

        public UserInfo(String playerName)
        {
            InitializeComponent();

            txtUserInfoName.Text = playerName;
        }

        private void btnUserInfoSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (txtUserInfoName.Text == "")
                return;
            Menu menu = new Menu(txtUserInfoName.Text);
            this.Close();
            menu.Show();
        }
    }
}
