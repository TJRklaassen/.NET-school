using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_library
{
    public class TicTacToeEngine
    {
        public enum GameStatus { PlayerOPlays, PlayerXPlays, Equal, PlayerOWins, PlayerXWins }

        public GameStatus status;
        public List<string> cells = new List<string>();

        public TicTacToeEngine()
        {
            Reset();
        }

        public String Board()
        {
            string display = "-------------\r\n" +
                "| " + cells[0] + " | " + cells[1] + " | " + cells[2] + " |\r\n" +
                "-------------\r\n" +
                "| " + cells[3] + " | " + cells[4] + " | " + cells[5] + " |\r\n" +
                "-------------\r\n" +
                "| " + cells[6] + " | " + cells[7] + " | " + cells[8] + " |\r\n" +
                "-------------";

            return display;
        }

        public bool ChooseCell(int index)
        {
            if(cells[index] == " ")
            {
                if(status == GameStatus.PlayerOPlays)
                {
                    cells[index] = "O";
                    status = GameStatus.PlayerXPlays;
                }
                else
                {
                    cells[index] = "X";
                    status = GameStatus.PlayerOPlays;
                }

                DetermineWinner(0, 1, 2);
                DetermineWinner(3, 4, 5);
                DetermineWinner(6, 7, 8);
                DetermineWinner(0, 4, 8);
                DetermineWinner(2, 4, 6);
                DetermineWinner(0, 3, 6);
                DetermineWinner(1, 4, 7);
                DetermineWinner(2, 5, 8);
                CheckForTie();
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool DetermineWinner(int a, int b, int c)
        {
            if (cells[a] != " " && cells[a] == cells[b] && cells[a] == cells[c])
            {
                if (cells[a] == "O") status = GameStatus.PlayerOWins;
                else status = GameStatus.PlayerXWins;
                return true;
            }
            return false;
        }

        private void CheckForTie()
        {
            if (!cells.Contains(" "))
            {
                status = GameStatus.Equal;
            }
        }

        public void Reset()
        {
            status = GameStatus.PlayerOPlays;

            for (int i = 0; i < 9; i++)
            {
                cells.Insert(i, " ");
            }
        }
    }
}
