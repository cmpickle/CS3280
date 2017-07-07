using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    /// <summary>
    /// Stores a user's score, game type, and time of completion
    /// </summary>
    public class UserScore : IComparable<UserScore>
    {
        /// <summary>
        /// The player's name
        /// </summary>
        private String userName;
        /// <summary>
        /// The user's score
        /// </summary>
        private int score;
        /// <summary>
        /// The time in seconds it took to complete the game
        /// </summary>
        private int seconds;
        /// <summary>
        /// The type of game played
        /// </summary>
        private String gameType;

        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="score">The player's score</param>
        /// <param name="seconds">The game completion time in seconds</param>
        /// <param name="gameType">The game type</param>
        public UserScore(String userName, int score, int seconds, String gameType)
        {
            try
            {
                this.userName = userName;

                this.score = score;

                this.seconds = seconds;

                this.gameType = gameType;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public int CompareTo(UserScore other)
        {
            if(this.score.CompareTo(other.score) != 0)
            {
                return this.score.CompareTo(other.score);
            }
            else if (this.seconds != other.seconds)
            {
                return other.seconds - this.seconds;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Returns the string representation of a UserScore
        /// </summary>
        /// <returns>The string representation</returns>
        public override String ToString()
        {
            try
            {
                TimeSpan span = TimeSpan.FromSeconds(seconds);
                return "" + userName + "\t" + score + "\t" + (10 - score) + "\t" + span.ToString("mm':'ss") + "\t" + gameType;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
