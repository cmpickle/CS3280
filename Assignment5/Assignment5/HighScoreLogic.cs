using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    /// <summary>
    /// Stores the high scores and sorts them.
    /// </summary>
    public class HighScoreLogic
    {
        private List<UserScore> scores;

        /// <summary>
        /// The default constructor
        /// </summary>
        public HighScoreLogic()
        {
            try
            {
                scores = new List<UserScore>();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Add a score to the scores list
        /// </summary>
        /// <param name="score"></param>
        public void AddScore(UserScore score)
        {
            try
            {
                scores.Add(score);
                scores.Sort();
                scores.Reverse();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Get a string array of the high scores
        /// </summary>
        /// <returns>String array of the high scores</returns>
        public String[] GetHighScoreArray()
        {
            String[] result;
            try
            {
                result = new String[scores.Count];
                for (int i = 0; i < scores.Count; ++i)
                {
                    result[i] = scores.ElementAt<UserScore>(i).ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

            return result;
        }

        #region error handling
        /// <summary>
        /// The error handling method. This prints out a user readable stack trace for debugging purposes.
        /// </summary>
        /// <param name="sClass">The class the error originated from</param>
        /// <param name="sMethod">The method the error originated from</param>
        /// <param name="sMessage">The error message</param>
        private void HandleError(String sClass, String sMethod, String sMessage)
        {
            try
            {
                Console.Out.WriteLine(sClass + "." + sMethod + " -> " + Environment.NewLine + sMessage);
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText("C:\\" + System.AppDomain.CurrentDomain.FriendlyName + "Error.txt", Environment.NewLine + "HandleError Exception: " + e.Message);
            }
        }
        #endregion
    }
}
