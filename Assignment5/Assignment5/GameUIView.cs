using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    interface GameUIView
    {
        void UpdateQuestion(String question);

        void UpdateScore(String score);

        void UpdateTimer(String time);

        void ClearTxtAnswer();

        void CloseWindow();
    }
}
