using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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

        /// <summary>
        /// Generates a string to display all the student's scores
        /// </summary>
        /// <param name="preDisplay">Header string</param>
        /// <returns>String display</returns>
        public String GenerateDisplay(String preDisplay)
        {
            String display = preDisplay;

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

            return display;
        }

        /// <summary>
        /// Resets the values for the student score logic
        /// </summary>
        public void Reset()
        {
            StudentNames = null;
            StudentScores = null;
            ActiveStudent = 0;
        }

        /// <summary>
        /// Returns the active student's name
        /// </summary>
        /// <returns>String name</returns>
        public String GetActiveStudentName()
        {
            return StudentNames[ActiveStudent];
        }

        /// <summary>
        /// Returns the number of students assignments
        /// </summary>
        /// <returns>int length</returns>
        public int GetStudentAssignmentsCount()
        {
            return StudentScores.GetLength(1);
        }

        /// <summary>
        /// Generates the header for the students score display
        /// </summary>
        /// <returns>String header</returns>
        public String GenerateHeader()
        {
            String display = "STUDENT\t\t";
            for (int i = 0; i < GetStudentAssignmentsCount(); ++i)
            {
                display += "#" + (i + 1) + "\t";
            }
            display += "AVG\tGRADE";

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
        #endregion
    }
}
