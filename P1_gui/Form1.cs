using System;
using System.Windows.Forms;
using P1_library;

namespace P1_gui
{
    public partial class Form1 : Form
    {
        private TicTacToeEngine t = new TicTacToeEngine();

        public Form1()
        {
            InitializeComponent();
            UpdateBoard();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int cellIndex = -1;

            if (clickedButton == b1) cellIndex = 0;
            else if (clickedButton == b2) cellIndex = 1;
            else if (clickedButton == b3) cellIndex = 2;
            else if (clickedButton == b4) cellIndex = 3;
            else if (clickedButton == b5) cellIndex = 4;
            else if (clickedButton == b6) cellIndex = 5;
            else if (clickedButton == b7) cellIndex = 6;
            else if (clickedButton == b8) cellIndex = 7;
            else if (clickedButton == b9) cellIndex = 8;

            if(t.ChooseCell(cellIndex))
            {
                UpdateBoard();

                switch (t.status)
                {
                    case TicTacToeEngine.GameStatus.Equal:
                        Console.WriteLine("ja");
                        System.Windows.Forms.MessageBox.Show("Jammer! Niemand wint.", "Er is GEEN winnaar!");
                        t.Reset();
                        break;
                    case TicTacToeEngine.GameStatus.PlayerOWins:
                        System.Windows.Forms.MessageBox.Show("Gefeliciteerd! Speler O wint.", "Er is een winnaar!");
                        t.Reset();
                        break;
                    case TicTacToeEngine.GameStatus.PlayerXWins:
                        System.Windows.Forms.MessageBox.Show("Gefeliciteerd! Speler X wint.", "Er is een winnaar!");
                        t.Reset();
                        break;
                }

                UpdateBoard();
            }
        }

        private void UpdateBoard()
        {
            b1.Text = t.cells[0];
            b2.Text = t.cells[1];
            b3.Text = t.cells[2];
            b4.Text = t.cells[3];
            b5.Text = t.cells[4];
            b6.Text = t.cells[5];
            b7.Text = t.cells[6];
            b8.Text = t.cells[7];
            b9.Text = t.cells[8];
        }
    }
}
