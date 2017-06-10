using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Assignment4
{
    /// <summary>
    /// Represents a game of tick tack toe
    /// </summary>
    class TicTacToe
    {
#region Static Fields
        /// <summary>
        /// Used to determine if the game is currently being played
        /// </summary>
        Boolean isStarted = false;
        /// <summary>
        /// Used to determine whether it is Player1 or Player2's turn
        /// </summary>
        Boolean isPlayer1Turn = true;
        /// <summary>
        /// Represents the gameboard - indices 0-2 are the top row, indices 3-5 are the middle row and indices 6-8 are the bottom row
        /// </summary>
        int[] board = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        /// <summary>
        /// Interface for interacting with the Tick Tac Toe GUI
        /// </summary>
        ITicTacToeView ticTacToeView;
        /// <summary>
        /// Statuses for the GameStatus console
        /// </summary>
        String[] statuses = new String[] { " Player 1 wins!" + Environment.NewLine + " To play again press the start game button.", " Player 2 wins!" + Environment.NewLine + " To play again press the start game button.", " Its a tie!" + Environment.NewLine + " To play again press the start game button.", " Player 1's turn", " Player 2's turn" };
        /// <summary>
        /// The number of times Player 1 has won
        /// </summary>
        int player1Wins = 0;
        /// <summary>
        /// The number of times Player 2 has won
        /// </summary>
        int player2Wins = 0;
        /// <summary>
        /// The number of times the game ended in a tie
        /// </summary>
        int playerTies = 0;

#region Accessor Methods
        /// <summary>
        /// Public accessor methods for isStarted
        /// </summary>
        public bool IsStarted { get => isStarted; set => isStarted = value; }
        /// <summary>
        /// Public accessor methods for isPlayer1Turn
        /// </summary>
        public bool IsPlayer1Turn { get => isPlayer1Turn; set => isPlayer1Turn = value; }
        /// <summary>
        /// Public accessor method for Player1Wins
        /// </summary>
        public int Player1Wins { get => player1Wins; }
        /// <summary>
        /// Public accessor method for Player2Wins
        /// </summary>
        public int Player2Wins { get => player2Wins; }
        /// <summary>
        /// Public accessor method for Player2Wins
        /// </summary>
        public int PlayerTies { get => playerTies; }
        #endregion
        #endregion

        /// <summary>
        /// Sets the Tic Tac Toe View to the TicTacToeGUI.xaml
        /// </summary>
        /// <param name="view"></param>
        public void SetView(ITicTacToeView view)
        {
            ticTacToeView = view;
        }

        /// <summary>
        /// Resets the game board and starts a match of Tic Tac Toe
        /// </summary>
        public void StartGame()
        {
            ticTacToeView.Reset();
            isPlayer1Turn = true;
            ticTacToeView.UpdateGameStatus(statuses[3]);
            board = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            isStarted = true;
        }

        /// <summary>
        /// The function sets the game tile to the player's symbol if it hasn't been previously selected
        /// </summary>
        /// <param name="sender">The game tile clicked</param>
        /// <returns>-1 if previously selected, 1 if X, and 2 if O</returns>
        public int PlayerChoose(Button sender)
        {
            int location = btnPos(sender);

            if(board[location] != 0 || !isStarted)
            {
                return -1;
            }
            
            board[location] = (isPlayer1Turn) ? 1 : 2;
            sender.Foreground = (isPlayer1Turn) ? System.Windows.Media.Brushes.Orange : System.Windows.Media.Brushes.YellowGreen;
            sender.Content = (isPlayer1Turn) ? "X" : "O";
            if(checkPlayerWins()>0)
            {
                return 3;
            }
            if(checkTie())
            {
                return 4;
            }
            isPlayer1Turn = !isPlayer1Turn;
            int turn = (isPlayer1Turn) ? 3 : 4;
            ticTacToeView.UpdateGameStatus(statuses[turn]);
            return (!isPlayer1Turn) ? 1 : 2; // Since we are switching players turn in previous step we must invert it here
        }

        /// <summary>
        /// A helper function to determine which position was selected
        /// </summary>
        /// <param name="btn">The button that was clicked</param>
        /// <returns>The integer location of the button clicked 0-8</returns>
        private int btnPos(Button btn)
        {
            switch(btn.Name)
            {
                case "btnPos0":
                    return 0;
                case "btnPos1":
                    return 1;
                case "btnPos2":
                    return 2;
                case "btnPos3":
                    return 3;
                case "btnPos4":
                    return 4;
                case "btnPos5":
                    return 5;
                case "btnPos6":
                    return 6;
                case "btnPos7":
                    return 7;
                case "btnPos8":
                    return 8;
                default:
                    return 0;
            }
        }

#region Player win functions
        /// <summary>
        /// Checks if a player has won the game
        /// </summary>
        /// <returns>The player that won the game otherwise 0</returns>
        private int checkPlayerWins()
        {
            int winner = 0;
            int result;

            result = checkPlayerHorizontalWins();
            if (result > 0)
            {
                winner = result;
            }
            result = checkPlayerVerticalWins();
            if (result > 0)
            {
                winner = result;
            }
            result = checkPlayerDiagonalWins();
            if (result > 0)
            {
                winner = result;
            }

            if(winner>0)
            {
                ticTacToeView.UpdateGameStatus(statuses[winner - 1]);
                isStarted = false;
                switch(winner)
                {
                    case 1:
                        ++player1Wins;
                        break;
                    case 2:
                        ++player2Wins;
                        break;
                    default:
                        break;
                }
                ticTacToeView.UpdateStatistics();
            }

            return winner;
        }

        /// <summary>
        /// Checks if there were any horizontal wins
        /// </summary>
        /// <returns>The player that won otherwise 0</returns>
        private int checkPlayerHorizontalWins()
        {
            if(board[0] > 0 && board[0] == board[1] && board[1] == board[2])
            {
                ticTacToeView.WinTiles(new int[] { 0, 1, 2 });
                return board[0];
            }
            if (board[3] > 0 && board[3] == board[4] && board[4] == board[5])
            {
                ticTacToeView.WinTiles(new int[] { 3, 4, 5 });
                return board[3];
            }
            if (board[6] > 0 && board[6] == board[7] && board[7] == board[8])
            {
                ticTacToeView.WinTiles(new int[] { 6, 7, 8 });
                return board[6];
            }

            return 0;
        }

        /// <summary>
        /// Checks if there were any horizontal wins
        /// </summary>
        /// <returns>The player that won otherwise 0</returns>
        private int checkPlayerVerticalWins()
        {
            if (board[0] > 0 && board[0] == board[3] && board[3] == board[6])
            {
                ticTacToeView.WinTiles(new int[] { 0, 3, 6 });
                return board[0];
            }
            if (board[1] > 0 && board[1] == board[4] && board[4] == board[7])
            {
                ticTacToeView.WinTiles(new int[] { 1, 4, 7 });
                return board[1];
            }
            if (board[2] > 0 && board[2] == board[5] && board[5] == board[8])
            {
                ticTacToeView.WinTiles(new int[] { 2, 5, 8 });
                return board[2];
            }

            return 0;
        }

        /// <summary>
        /// Checks if there were any horizontal wins
        /// </summary>
        /// <returns>The player that won otherwise 0</returns>
        private int checkPlayerDiagonalWins()
        {
            if (board[0] > 0 && board[0] == board[4] && board[4] == board[8])
            {
                ticTacToeView.WinTiles(new int[] { 0, 4, 8 });
                return board[0];
            }
            if (board[2] > 0 && board[2] == board[4] && board[4] == board[6])
            {
                ticTacToeView.WinTiles(new int[] { 2, 4, 6 });
                return board[2];
            }

            return 0;
        }
#endregion

        /// <summary>
        /// Determines if there was a tie
        /// If no wins have occured and the board is filled in the game is a tie
        /// </summary>
        private Boolean checkTie()
        {
            foreach(int i in board)
            {
                if (i == 0)
                    return false;
            }

            ticTacToeView.UpdateGameStatus(statuses[2]);
            ++playerTies;
            isStarted = false;
            ticTacToeView.UpdateStatistics();
            return true;
        }
    }
}
