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
using System.Windows.Navigation;
using System.Windows.Shapes;

/// <summary>
/// This program is used to store students names and assignment scores. You may enter each
/// value and display in in a scrollable text box. This for may be reset with the reset 
/// button.
/// </summary>
namespace Assignment7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// This contains the arrays for the data storage as well as the onClick listeners.
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Class level variables
        /// <summary>
        /// Logic for the Students and their scores
        /// </summary>
        StudentScoreLogic logic;

        /// <summary>
        /// The file name that the user saved their results to
        /// </summary>
        String fileName;
        #endregion

        #region Constructor
        /// <summary>
        /// The Constructor to initiallize the WPF application
        /// </summary>
        public MainWindow()
        {
            try
            {
                InitializeComponent();

                logic = new StudentScoreLogic();
                logic.AttachWindow(this);
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        #region Event Handlers
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
            try
            {
                logic.ActiveStudent = 0;
                lblStudentName.Content = "Student #1";
                int numStudents;
                int numAssignments;

                if (!int.TryParse(txtNumberOfStudents.Text, out numStudents) || numStudents > 10 || numStudents < 1)
                {
                    lblStudentsNumError.Visibility = Visibility.Visible;
                    return;
                }
                else
                {
                    lblStudentsNumError.Visibility = Visibility.Collapsed;
                }

                if (!int.TryParse(txtNumberOfAssignments.Text, out numAssignments) || numAssignments > 99 || numAssignments < 1)
                {
                    lblAssignmentsNumError.Visibility = Visibility.Visible;
                    return;
                }
                else
                {
                    lblAssignmentsNumError.Visibility = Visibility.Collapsed;
                }

                logic.PopulateStudentInfo(numStudents, numAssignments);

                UpdateFieldsForCount();

                EnableStudentSections();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
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
            try
            {
                ResetForm();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
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
            try
            {
                logic.ActiveStudent = 0;

                updateStudentNamelbl();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
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
            try
            {
                if (logic.ActiveStudent < 1)
                {
                    return;
                }
                --logic.ActiveStudent;

                updateStudentNamelbl();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
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
            try
            {
                if (logic.ActiveStudent > logic.GetNumberOfStudents() - 2)  //one less for indices and one more less because the last element shouldn't go to the "next" student
                {
                    return;
                }
                ++logic.ActiveStudent;

                updateStudentNamelbl();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
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
            try
            {
                logic.ActiveStudent = logic.GetNumberOfStudents() - 1; // -1 since it is indices 

                updateStudentNamelbl();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
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
            try
            {
                logic.StudentNames[logic.ActiveStudent] = txtStudentName.Text;

                txtStudentName.Text = "";

                updateStudentNamelbl();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
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
            try
            {
                int assignNum;
                int assignScore;
                if (!int.TryParse(txtEnterAssignmentNum.Text, out assignNum) || assignNum < 1 || assignNum > logic.StudentScores.GetLength(1))
                {
                    lblErrorEnterAssignmentNum.Visibility = Visibility.Visible;
                    return;
                }
                lblErrorEnterAssignmentNum.Visibility = Visibility.Collapsed;

                if (!int.TryParse(txtAssignmentScore.Text, out assignScore) || assignScore < 0 || assignScore > 100)
                {
                    lblErrorEnterAssignmentScore.Visibility = Visibility.Visible;
                    return;
                }
                lblErrorEnterAssignmentScore.Visibility = Visibility.Collapsed;

                logic.StudentScores[logic.ActiveStudent, assignNum - 1] = assignScore;

                txtEnterAssignmentNum.Text = "";
                txtAssignmentScore.Text = "";
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
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
            try
            {
                AddHeaderToDisplayScores();

                txtDisplayedScores.Text = logic.GenerateDisplay(txtDisplayedScores.Text);
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// The Event handler for the Output to File button
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void btnOutputToFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                logic.OutputToFile();

                btnOutputToFile.IsEnabled = false;

                fileName = txtOutputToFile.Text;

                txtOutputToFile.Text = "Writing to File.";
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        #region public methods
        /// <summary>
        /// Updates the UI to show that the save finished
        /// </summary>
        public void DisplaySaveFinished()
        {
            try
            {
                txtOutputToFile.Text = fileName;

                btnOutputToFile.IsEnabled = true;
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Updates all of the text fields that are effected by either the student
        /// count or the assignment count
        /// </summary>
        private void UpdateFieldsForCount()
        {
            try
            {
                lblStudentName.Content = logic.StudentNames[0];
                lblEnterAssignmentNum.Content = String.Format("Enter Assignment Number (1-{0}):", logic.GetStudentAssignmentsCount());
                lblErrorEnterAssignmentNum.Content = String.Format("*Enter an assignment number from 1 to {0}", logic.GetStudentAssignmentsCount());

                AddHeaderToDisplayScores();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Clears the DisplayScores text box and adds a new header with the
        /// appropriate number of assignments
        /// 
        /// *studentScores CANNOT BE NULL
        /// </summary>
        private void AddHeaderToDisplayScores()
        {
            try
            {
                txtDisplayedScores.Text = logic.GenerateHeader();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Enables the bottom sections that are dependant on the 
        /// number of students and assignments
        /// </summary>
        private void EnableStudentSections()
        {
            try
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
                btnOutputToFile.IsEnabled = true;
                txtOutputToFile.IsEnabled = true;
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Disables the bottom sections that are dependant on the
        /// number of students and assignments
        /// </summary>
        private void DisableStudentSections()
        {
            try
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
                btnOutputToFile.IsEnabled = false;
                txtOutputToFile.IsEnabled = false;
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Update the student name label to the active student
        /// </summary>
        private void updateStudentNamelbl()
        {
            try
            {
                lblStudentName.Content = logic.GetActiveStudentName();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Resets the entire program to its starting state
        /// </summary>
        private void ResetForm()
        {
            try
            {
                logic.Reset();

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
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region error handling
        /// <summary>
        /// Handle the error.
        /// </summary>
        /// <param name="sClass">The class in which the error occurred in.</param>
        /// <param name="sMethod">The method in which the error occurred in.</param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                //Would write to a file or database here.
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }
        #endregion
    }
}
