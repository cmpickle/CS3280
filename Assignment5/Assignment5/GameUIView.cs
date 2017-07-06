using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    interface GameUIView
    {
        /// <summary>
        /// Updates the question label
        /// </summary>
        /// <param name="question">The new question string</param>
        void UpdateQuestion(String question);

        /// <summary>
        /// Updates the score label
        /// </summary>
        /// <param name="score">The new score string</param>
        void UpdateScore(String score);

        /// <summary>
        /// Updates the timer label
        /// </summary>
        /// <param name="time">The new timer value</param>
        void UpdateTimer(String time);

        /// <summary>
        /// Clears the txtAnser box
        /// </summary>
        void ClearTxtAnswer();

        /// <summary>
        /// Closes the window
        /// </summary>
        void CloseWindow();

        /// <summary>
        /// Shows an error message in a message box
        /// </summary>
        /// <param name="error">The error string</param>
        void ShowError(String error);
    }
}
