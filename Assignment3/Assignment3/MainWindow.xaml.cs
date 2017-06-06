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

/// <summary>
/// This program is used to store students names and assignment scores. You may enter each
/// value and display in in a scrollable text box. This for may be reset with the reset 
/// button.
/// </summary>
namespace Assignment3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// This contains the arrays for the data storage as well as the onClick listeners.
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Class level variables
        /// <summary>
        /// The names of the students
        /// </summary>
        String[] studentNames;
        /// <summary>
        /// The scores of the students stored in each student's index
        /// </summary>
        int[,] studentScores;
        /// <summary>
        /// The index of the student that is currently being edited
        /// </summary>
        int activeStudent = 0;
        #endregion

        #region Constructor
        /// <summary>
        /// The Constructor to initiallize the WPF application
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region OnClickListeners
        /// <summary>
        /// The onClick listenter for "Submit Counts"
        /// 
        /// This submits the numer of students and assignments and updates the backing
        /// data structures as well as the gui to match the entered values.
        /// </summary>
        /// <param name="sender">The click sender</param>
        /// <param name="e">The event arg</param>
        private void btnSubmitCounts_Click(object sender, RoutedEventArgs e)
        {
            activeStudent = 0;
            lblStudentName.Content = "Student #1";
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

            UpdateFieldsForCount();

            EnableStudentSections();
        }

        /// <summary>
        /// The onClick listenter for "Reset Scores"
        /// 
        /// This Resets the form and backing data
        /// </summary>
        /// <param name="sender">The click sender</param>
        /// <param name="e">The event arg</param>
        private void btnResetScores_Click(object sender, RoutedEventArgs e)
        {
            ResetForm();
        }

        /// <summary>
        /// The onClick listenter for "First Student"
        /// 
        /// This sets the active student index to 0 ie the first student
        /// </summary>
        /// <param name="sender">The click sender</param>
        /// <param name="e">The event arg</param>
        private void btnFirstStudent_Click(object sender, RoutedEventArgs e)
        {
            activeStudent = 0;

            updateStudentNamelbl();
        }

        /// <summary>
        /// The onClick listenter for "Prev Student"
        /// 
        /// This sets the active student index to one less unless on the first student
        /// </summary>
        /// <param name="sender">The click sender</param>
        /// <param name="e">The event arg</param>
        private void btnPrevStudent_Click(object sender, RoutedEventArgs e)
        {
            if(activeStudent<1)
            {
                return;
            }
            --activeStudent;

            updateStudentNamelbl();
        }

        /// <summary>
        /// The onClick listenter for "Next Student"
        /// 
        /// This sets the active student index to one more unless on the last student
        /// </summary>
        /// <param name="sender">The click sender</param>
        /// <param name="e">The event arg</param>
        private void btnNextStudent_Click(object sender, RoutedEventArgs e)
        {
            if(activeStudent>studentNames.Length-2)  //one less for indices and one more less because the last element shouldn't go to the "next" student
            {
                return;
            }
            ++activeStudent;

            updateStudentNamelbl();
        }

        /// <summary>
        /// The onClick listenter for "Last Student"
        /// 
        /// This sets the active student index to the last student
        /// </summary>
        /// <param name="sender">The click sender</param>
        /// <param name="e">The event arg</param>
        private void btnLastStudent_Click(object sender, RoutedEventArgs e)
        {
            activeStudent = studentNames.Length - 1; // -1 since it is indices 

            updateStudentNamelbl();
        }

        /// <summary>
        /// The onClick listenter for "Save Name"
        /// 
        /// This saves the name for the current active student
        /// </summary>
        /// <param name="sender">The click sender</param>
        /// <param name="e">The event arg</param>
        private void btnSaveName_Click(object sender, RoutedEventArgs e)
        {
            studentNames[activeStudent] = txtStudentName.Text;

            txtStudentName.Text = "";

            updateStudentNamelbl();
        }

        /// <summary>
        /// The onClick listenter for "Save Score"
        /// 
        /// This sets the specified score for the current active student
        /// </summary>
        /// <param name="sender">The click sender</param>
        /// <param name="e">The event arg</param>
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

        /// <summary>
        /// The onClick listenter for "Display Score"
        /// 
        /// This displays all the scores for each student as well as their average
        /// score and letter grade
        /// </summary>
        /// <param name="sender">The click sender</param>
        /// <param name="e">The event arg</param>
        private void btnDisplayScores_Click(object sender, RoutedEventArgs e)
        {
            AddHeaderToDisplayScores();

            String display = txtDisplayedScores.Text;

            for(int i=0; i<studentNames.Length; ++i)
            {
                double sum = 0;
                display += Environment.NewLine;

                display += studentNames[i] + "\t\t";

                for(int j=0; j<studentScores.GetLength(1); ++j)
                {
                    display += studentScores[i,j] + "\t";
                    sum += studentScores[i, j];
                }

                double average = (sum / studentScores.GetLength(1));
                display += average + "\t";

                String letterGrade;
                if(average >= 93)
                {
                    letterGrade = "A";
                } else if(average >= 90)
                {
                    letterGrade = "A-";
                } else if(average >= 87)
                {
                    letterGrade = "B+";
                } else if(average >= 83)
                {
                    letterGrade = "B";
                } else if(average >= 80)
                {
                    letterGrade = "B-";
                } else if(average >= 77)
                {
                    letterGrade = "C=";
                } else if(average >= 73)
                {
                    letterGrade = "C";
                } else if(average >= 70)
                {
                    letterGrade = "C-";
                } else if(average >= 67)
                {
                    letterGrade = "D+";
                } else if(average >= 63)
                {
                    letterGrade = "D";
                } else if(average >= 60)
                {
                    letterGrade = "D-";
                } else
                {
                    letterGrade = "F";
                }
                display += letterGrade;
            }

            txtDisplayedScores.Text = display;
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Updates all of the text fields that are effected by either the student
        /// count or the assignment count
        /// </summary>
        private void UpdateFieldsForCount()
        {
            lblStudentName.Content = studentNames[0];
            lblEnterAssignmentNum.Content = String.Format("Enter Assignment Number (1-{0}):", studentScores.GetLength(1));
            lblErrorEnterAssignmentNum.Content = String.Format("*Enter an assignment number from 1 to {0}", studentScores.GetLength(1));

            AddHeaderToDisplayScores();
        }

        /// <summary>
        /// Clears the DisplayScores text box and adds a new header with the
        /// appropriate number of assignments
        /// 
        /// *studentScores CANNOT BE NULL
        /// </summary>
        private void AddHeaderToDisplayScores()
        {
            String display = "STUDENT\t\t";
            for (int i = 0; i < studentScores.GetLength(1); ++i)
            {
                display += "#" + (i + 1) + "\t";
            }
            display += "AVG\tGRADE";

            txtDisplayedScores.Text = display;
        }

        /// <summary>
        /// Enables the bottom sections that are dependant on the 
        /// number of students and assignments
        /// </summary>
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

        /// <summary>
        /// Disables the bottom sections that are dependant on the
        /// number of students and assignments
        /// </summary>
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

        /// <summary>
        /// Update the student name label to the active student
        /// </summary>
        private void updateStudentNamelbl()
        {
            lblStudentName.Content = studentNames[activeStudent];
        }

        /// <summary>
        /// Resets the entire program to its starting state
        /// </summary>
        private void ResetForm()
        {
            studentNames = null;
            studentScores = null;
            activeStudent = 0;

            DisableStudentSections();

            lblStudentName.Content = "Student #1";
            lblEnterAssignmentNum.Content = "Enter Assignment Number (1-5):";
            txtDisplayedScores.Text = "STUDENT\t\t#1\t#2\t#3\t#4\t#5\tAVG\tGRADE";

            txtNumberOfStudents.Text = "";
            txtNumberOfAssignments.Text = "";
            txtStudentName.Text = "";
            txtEnterAssignmentNum.Text = "";
            txtAssignmentScore.Text = "";

            lblStudentsNumError.Visibility = Visibility.Collapsed;
            lblAssignmentsNumError.Visibility = Visibility.Collapsed;
            lblErrorEnterAssignmentNum.Visibility = Visibility.Collapsed;
            lblErrorEnterAssignmentScore.Visibility = Visibility.Collapsed;
        }
        #endregion
    }
}
