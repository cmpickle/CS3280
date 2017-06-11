using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    /// <summary>
    /// The interface for interacting with the TicTacToe GUI
    /// </summary>
    interface ITicTacToeView
    {
        /// <summary>
        /// How to update the game status text box
        /// </summary>
        /// <param name="status">The status to be set</param>
        void UpdateGameStatus(String status);

        /// <summary>
        /// How to reset the game for a new game
        /// </summary>
        void Reset();

        /// <summary>
        /// How to update the game statistics
        /// </summary>
        void UpdateStatistics();

        /// <summary>
        /// How to highlight the tiles of a winning set
        /// </summary>
        /// <param name="tiles">The tiles to higlight</param>
        void WinTiles(int[] tiles);
    }
}
