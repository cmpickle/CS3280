using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    interface ITicTacToeView
    {
        void UpdateGameStatus(String status);

        void Reset();

        void UpdateStatistics();

        void WinTiles(int[] tiles);
    }
}
