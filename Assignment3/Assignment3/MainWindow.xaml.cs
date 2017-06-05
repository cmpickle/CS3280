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

namespace Assignment3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Class level variables
        String[] studentNames;
        int[,] studentScores;
        int activeStudent = 0;
        #endregion

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region OnClickListeners
        private void btnSubmitCounts_Click(object sender, RoutedEventArgs e)
        {
            int numStudents;
            int numAssignments;

            if(!int.TryParse(txtNumberOfStudents.Text, out numStudents) || numStudents > 10 || numStudents < 1)
            {
                lblStudentsNumError.Visibility = Visibility.Visible;
                return;
            } else
            {
                lblStudentsNumError.Visibility = Visibility.Collapsed;
            }

            if(!int.TryParse(txtNumberOfAssignments.Text, out numAssignments) || numAssignments > 99 || numAssignments < 1)
            {
                lblAssignmentsNumError.Visibility = Visibility.Visible;
                return;
            } else
            {
                lblAssignmentsNumError.Visibility = Visibility.Collapsed;
            }

            studentNames = new String[numStudents];
            for(int i=0; i<numStudents; ++i)
            {
                studentNames[i] = String.Format("Student #{0}", i + 1);
            }

            studentScores = new int[numStudents, numAssignments];
            for(int i=0; i<numStudents; ++i)
            {
                for(int j=0; j<numAssignments; ++j)
                {
                    studentScores[i, j] = 0;
                }
            }

            AddHeaderToDisplayScores();

            EnableStudentSections();
        }

        private void btnFirstStudent_Click(object sender, RoutedEventArgs e)
        {
            activeStudent = 0;

            updateStudentNamelbl();
        }

        private void btnPrevStudent_Click(object sender, RoutedEventArgs e)
        {
            if(activeStudent<1)
            {
                return;
            }
            --activeStudent;

            updateStudentNamelbl();
        }

        private void btnNextStudent_Click(object sender, RoutedEventArgs e)
        {
            if(activeStudent>studentNames.Length-2)  //one less for indices and one more less because the last element shouldn't go to the "next" student
            {
                return;
            }
            ++activeStudent;

            updateStudentNamelbl();
        }

        private void btnLastStudent_Click(object sender, RoutedEventArgs e)
        {
            activeStudent = studentNames.Length - 1; // -1 since it is indices 

            updateStudentNamelbl();
        }

        private void btnSaveName_Click(object sender, RoutedEventArgs e)
        {
            studentNames[activeStudent] = txtStudentName.Text;

            txtStudentName.Text = "";

            updateStudentNamelbl();
        }

        private void btnSaveScore_Click(object sender, RoutedEventArgs e)
        {
            int assignNum;
            int assignScore;
            if(!int.TryParse(txtEnterAssignmentNum.Text, out assignNum) || assignNum < 1 || assignNum > studentScores.GetLength(1))
            {
                lblErrorEnterAssignmentNum.Visibility = Visibility.Visible;
                return;
            }
            lblErrorEnterAssignmentNum.Visibility = Visibility.Collapsed;

            if(!int.TryParse(txtAssignmentScore.Text, out assignScore) || assignScore < 0 || assignScore > 100)
            {
                lblErrorEnterAssignmentScore.Visibility = Visibility.Visible;
                return;
            }
            lblErrorEnterAssignmentScore.Visibility = Visibility.Collapsed;

            studentScores[activeStudent, assignNum-1] = assignScore;

            txtEnterAssignmentNum.Text = "";
            txtAssignmentScore.Text = "";
        }

        private void btnDisplayScores_Click(object sender, RoutedEventArgs e)
        {
            String display = txtDisplayedScores.Text;
            double sum = 0;

            for(int i=0; i<studentNames.Length; ++i)
            {
                display += Environment.NewLine;

                display += studentNames[i] + "\t\t";

                for(int j=0; j<studentScores.GetLength(1); ++j)
                {
                    display += studentScores[i,j] + "\t";
                    sum += studentScores[i, j];
                }

                display += (sum / studentScores.GetLength(1));
            }

            txtDisplayedScores.Text = display;
        }
        #endregion

        #region Helper Methods
        private void AddHeaderToDisplayScores()
        {
            lblStudentName.Content = studentNames[0];
            lblEnterAssignmentNum.Content = String.Format("Enter Assignment Number (1-{0}):", studentScores.GetLength(1));

            String display = "STUDENT\t\t";
            for (int i = 0; i < studentNames.Length; ++i)
            {
                display += "#" + (i + 1) + "\t";
            }
            display += "AVG\tGRADE";

            txtDisplayedScores.Text = display;
        }

        private void EnableStudentSections()
        {
            btnFirstStudent.IsEnabled = true;
            btnPrevStudent.IsEnabled = true;
            btnNextStudent.IsEnabled = true;
            btnLastStudent.IsEnabled = true;
            txtStudentName.IsEnabled = true;
            btnSaveName.IsEnabled = true;
            txtEnterAssignmentNum.IsEnabled = true;
            txtAssignmentScore.IsEnabled = true;
            btnSaveScore.IsEnabled = true;
            btnDisplayScores.IsEnabled = true;
        }

        private void DisableStudentSections()
        {
            btnFirstStudent.IsEnabled = false;
            btnPrevStudent.IsEnabled = false;
            btnNextStudent.IsEnabled = false;
            btnLastStudent.IsEnabled = false;
            txtStudentName.IsEnabled = false;
            btnSaveName.IsEnabled = false;
            txtEnterAssignmentNum.IsEnabled = false;
            txtAssignmentScore.IsEnabled = false;
            btnSaveScore.IsEnabled = false;
            btnDisplayScores.IsEnabled = false;
        }

        private void updateStudentNamelbl()
        {
            lblStudentName.Content = studentNames[activeStudent];
        }
        #endregion
    }
}
