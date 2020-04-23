using System;
using P1_library;

namespace P1_console
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeEngine t = new TicTacToeEngine();

            while(true)
            {
                Console.WriteLine("Type a number from 0-8, new or quit");
                Console.WriteLine(t.status);
                Console.WriteLine(t.Board());

                string input = Console.ReadLine();
              
                if(input == "new")
                {
                    t.Reset();
                    Console.WriteLine();
                    continue;
                }

                if (input == "quit")
                {
                    break;
                }

                try
                {
                    int cellIndex = Int32.Parse(input);
                    if(t.ChooseCell(cellIndex))
                    {
                        switch (t.status)
                        {
                            case TicTacToeEngine.GameStatus.Equal:
                                Console.WriteLine();
                                Console.WriteLine("It's a tie!");
                                Console.WriteLine(t.Board());
                                t.Reset();
                                break;
                            case TicTacToeEngine.GameStatus.PlayerOWins:
                                Console.WriteLine();
                                Console.WriteLine("Player O wins!");
                                Console.WriteLine(t.Board());
                                t.Reset();
                                break;
                            case TicTacToeEngine.GameStatus.PlayerXWins:
                                Console.WriteLine();
                                Console.WriteLine("Player X wins!");
                                Console.WriteLine(t.Board());
                                t.Reset();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Choice.");
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid Choice.");
                }

                Console.WriteLine();
            }
        }
    }
}
