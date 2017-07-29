using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment7
{
    /// <summary>
    /// This class deals with the business logic for students and their scores
    /// </summary>
    class StudentScoreLogic
    {
        #region class fields
        /// <summary>
        /// The names of the students
        /// </summary>
        public String[] StudentNames { get; set; }

        /// <summary>
        /// The scores of the students stored in each student's index
        /// </summary>
        public int[,] StudentScores { get; set; }

        /// <summary>
        /// The index of the student that is currently being edited
        /// </summary>
        public int ActiveStudent { get; set; }

        /// <summary>
        /// Reference to the Main Window
        /// </summary>
        public MainWindow mainWindow;

        /// <summary>
        /// Delegate for updating file save messages
        /// </summary>
        private delegate void UpdateFileMessage();

        /// <summary>
        /// Message to send to Output File textbox
        /// </summary>
        private String updateMessage;

        /// <summary>
        /// The name of the output string
        /// </summary>
        public String OutputFileName { get; set; }
        #endregion

        #region constructor
        /// <summary>
        /// The default constructor
        /// </summary>
        public StudentScoreLogic()
        {
            try
            {
                ActiveStudent = 0;
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region public methods
        /// <summary>
        /// Populates the student names and scores arrays
        /// </summary>
        /// <param name="numStudents">The number of students to populate</param>
        /// <param name="numAssignments">The number of assignments to populate</param>
        public void PopulateStudentInfo(int numStudents, int numAssignments)
        {
            try
            {
                StudentNames = new String[numStudents];
                for (int i = 0; i < numStudents; ++i)
                {
                    StudentNames[i] = String.Format("Student #{0}", i + 1);
                }

                StudentScores = new int[numStudents, numAssignments];
                for (int i = 0; i < numStudents; ++i)
                {
                    for (int j = 0; j < numAssignments; ++j)
                    {
                        StudentScores[i, j] = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Generates a string to display all the student's scores
        /// </summary>
        /// <param name="preDisplay">Header string</param>
        /// <returns>String display</returns>
        public String GenerateDisplay(String preDisplay)
        {
            String display = preDisplay;

            try
            {
                for (int i = 0; i < StudentNames.Length; ++i)
                {
                    double sum = 0;
                    display += Environment.NewLine;

                    display += StudentNames[i] + "\t\t";

                    for (int j = 0; j < StudentScores.GetLength(1); ++j)
                    {
                        display += StudentScores[i, j] + "\t";
                        sum += StudentScores[i, j];
                    }

                    double average = (sum / StudentScores.GetLength(1));
                    display += average + "\t";

                    String letterGrade;
                    if (average >= 93)
                    {
                        letterGrade = "A";
                    }
                    else if (average >= 90)
                    {
                        letterGrade = "A-";
                    }
                    else if (average >= 87)
                    {
                        letterGrade = "B+";
                    }
                    else if (average >= 83)
                    {
                        letterGrade = "B";
                    }
                    else if (average >= 80)
                    {
                        letterGrade = "B-";
                    }
                    else if (average >= 77)
                    {
                        letterGrade = "C=";
                    }
                    else if (average >= 73)
                    {
                        letterGrade = "C";
                    }
                    else if (average >= 70)
                    {
                        letterGrade = "C-";
                    }
                    else if (average >= 67)
                    {
                        letterGrade = "D+";
                    }
                    else if (average >= 63)
                    {
                        letterGrade = "D";
                    }
                    else if (average >= 60)
                    {
                        letterGrade = "D-";
                    }
                    else
                    {
                        letterGrade = "F";
                    }
                    display += letterGrade;
                }
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

            return display;
        }

        /// <summary>
        /// Resets the values for the student score logic
        /// </summary>
        public void Reset()
        {
            try
            {
                StudentNames = null;
                StudentScores = null;
                ActiveStudent = 0;
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Returns the active student's name
        /// </summary>
        /// <returns>String name</returns>
        public String GetActiveStudentName()
        {
            try
            {
                return StudentNames[ActiveStudent];
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Returns the number of students assignments
        /// </summary>
        /// <returns>int length</returns>
        public int GetStudentAssignmentsCount()
        {
            try
            {
                return StudentScores.GetLength(1);
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Generates the header for the students score display
        /// </summary>
        /// <returns>String header</returns>
        public String GenerateHeader()
        {
            String display = "STUDENT\t\t";

            try
            {
                for (int i = 0; i < GetStudentAssignmentsCount(); ++i)
                {
                    display += "#" + (i + 1) + "\t";
                }
                display += "AVG\tGRADE";
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

            return display;
        }

        /// <summary>
        /// Returns the number of students
        /// </summary>
        /// <returns>int students</returns>
        public int GetNumberOfStudents()
        {
            return StudentNames.Length;
        }

        /// <summary>
        /// Outputs the students and their scores to a file.
        /// </summary>
        public void OutputToFile()
        {
            try
            {
                Thread writeFileThread = new Thread(new ThreadStart(saveFile));
                writeFileThread.Start();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Gives the student score logic a reference to the Main Window to update its UI
        /// </summary>
        /// <param name="mainWindow"></param>
        public void AttachWindow(MainWindow mainWindow)
        {
            try
            {
                this.mainWindow = mainWindow;
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Updates the Main Window UI to show the results of the save opperation
        /// </summary>
        public void UpdateDisplay()
        {
            try
            {
                mainWindow.UpdateDisplay(updateMessage);
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region private methods
        /// <summary>
        /// Saves the file
        /// </summary>
        private void saveFile()
        {
            try
            {
                // Used to demonstrate a task that takes time to complete its work
                Thread.Sleep(2000);

                String filePath = @"C:\Users\Public" + "\\" + OutputFileName;

                if (!File.Exists(filePath)) {
                    using (StreamWriter FileWrite = new StreamWriter(filePath))
                    {
                        FileWrite.Write(GenerateDisplay(GenerateHeader()));
                    }
                }
                else
                {
                    updateMessage = "File Already Exists";
                    mainWindow.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new UpdateFileMessage(UpdateDisplay));
                    return;
                }

                updateMessage = "File Saved";
                mainWindow.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new UpdateFileMessage(UpdateDisplay));
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
    }
}
