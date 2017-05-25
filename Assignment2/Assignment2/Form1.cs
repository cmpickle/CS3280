using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class DieGuessGame : Form
    {
        int gamesPlayed = 0;
        int gamesWon = 0;
        int gamesLost = 0;
        int onesRolled = 0;
        int twosRolled = 0;
        int threesRolled = 0;
        int foursRolled = 0;
        int fivesRolled = 0;
        int sixesRolled = 0;
        int onesGuessed = 0;
        int twosGuessed = 0;
        int threesGuessed = 0;
        int foursGuessed = 0;
        int fivesGuessed = 0;
        int sixesGuessed = 0;

        public DieGuessGame()
        {
            InitializeComponent();
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            int rollGuess;
            int rollResult;
            bool valid = Int32.TryParse(txtGuess.Text, out rollGuess);
            if (rollGuess < 1 || rollGuess > 6 || !valid)
            {
                lblInvalidInput.Visible = true;
                return;
            } else
            {
                lblInvalidInput.Visible = false;
            }

            rollResult = RollDice();

            DisplayResult(rollGuess, rollResult);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            gamesPlayed = 0;
            gamesWon = 0;
            gamesLost = 0;
            onesRolled = 0;
            twosRolled = 0;
            threesRolled = 0;
            foursRolled = 0;
            fivesRolled = 0;
            sixesRolled = 0;
            onesGuessed = 0;
            twosGuessed = 0;
            threesGuessed = 0;
            foursGuessed = 0;
            fivesGuessed = 0;
            sixesGuessed = 0;

            lblTimesPlayedVal.Text = "0";
            lblTimesWonVal.Text = "0";
            lblTimesLostVal.Text = "0";

            txtStats.Text = "FACE\tFREQUENCY\tPERCENT\tNUMBER OF TIMES GUESSED\n1\t0\t\t0.00%\t\t0\n2\t0\t\t0.00%\t\t0\n3\t0\t\t0" +
    ".00%\t\t0\n4\t0\t\t0.00%\t\t0\n5\t0\t\t0.00%\t\t0\n6\t0\t\t0.00%\t\t0";
        }

        private void DisplayResult(int rollGuess, int rollResult)
        {
            lblTimesPlayedVal.Text = "" + (++gamesPlayed);
            if(rollGuess == rollResult)
            {
                lblTimesWonVal.Text = "" + (++gamesWon);
            } else
            {
                lblTimesLostVal.Text = "" + (++gamesLost);
            }

            UpdateStats(rollGuess, rollResult);

            txtStats.Text = String.Format("FACE\tFREQUENCY\tPERCENT\tNUMBER OF TIMES GUESSED\n1\t{0}\t\t{1:f2}%\t\t{2}\n2\t{3}\t\t{4:f2}%\t\t{5}\n3\t{6}\t\t{7:f2}%\t\t{8}\n4\t{9}\t\t{10:f2}%\t\t{11}\n5\t{12}\t\t{13:f2}%\t\t{14}\n6\t{15}\t\t{16:f2}%\t\t{17}",
                onesRolled, ((double)onesRolled / gamesPlayed) * 100, onesGuessed,
                twosRolled, ((double)twosRolled / gamesPlayed) * 100, twosGuessed,
                threesRolled, ((double)threesRolled / gamesPlayed) * 100, threesGuessed,
                foursRolled, ((double)foursRolled / gamesPlayed) * 100, foursGuessed,
                fivesRolled, ((double)fivesRolled / gamesPlayed) * 100, fivesGuessed,
                sixesRolled, ((double)sixesRolled / gamesPlayed) * 100, sixesGuessed);
        }

        private void UpdateStats(int rollGuess, int rollResult)
        {
            switch (rollResult)
            {
                case 1:
                    ++onesRolled;
                    break;
                case 2:
                    ++twosRolled;
                    break;
                case 3:
                    ++threesRolled;
                    break;
                case 4:
                    ++foursRolled;
                    break;
                case 5:
                    ++fivesRolled;
                    break;
                case 6:
                    ++sixesRolled;
                    break;
            }

            switch (rollGuess)
            {
                case 1:
                    ++onesGuessed;
                    break;
                case 2:
                    ++twosGuessed;
                    break;
                case 3:
                    ++threesGuessed;
                    break;
                case 4:
                    ++foursGuessed;
                    break;
                case 5:
                    ++fivesGuessed;
                    break;
                case 6:
                    ++sixesGuessed;
                    break;
            }
        }

        private int RollDice()
        {
            int rollResult = 0;
            Random rand = new Random();

            for (int i = 1; i < 7; ++i)
            {
                rollResult = rand.Next(1, 7);
                pbDie.Image = Image.FromFile("die" + rollResult.ToString() + ".gif");

                pbDie.Refresh();
                Thread.Sleep(300);
            }

            return rollResult;
        }
    }
}
