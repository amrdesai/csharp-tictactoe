using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Game
    {
        public char[,] playArea = {
            {'1', '2', '3' },
            {'4', '5', '6' },
            {'7', '8', '9' }
        };

        public int turns = 0;


      // Method: Set TicTacToe board
        public void SetGameBoard()
        {
            Console.Clear();
            Console.WriteLine("____________________________________");
            Console.WriteLine();
            Console.WriteLine(" Player #1 - 'O' || Player #2 - 'X' ");
            Console.WriteLine("____________________________________");
            
            Console.WriteLine();
            Console.WriteLine("         |       |       ");
            Console.WriteLine($"     {playArea[0, 0]}   |   {playArea[0, 1]}   |   {playArea[0, 2]}   ");
            Console.WriteLine("  _______|_______|_______");
            Console.WriteLine("         |       |       ");
            Console.WriteLine($"     {playArea[1, 0]}   |   {playArea[1, 1]}   |   {playArea[1, 2]}   ");
            Console.WriteLine("  _______|_______|_______");
            Console.WriteLine("         |       |       ");
            Console.WriteLine($"     {playArea[2, 0]}   |   {playArea[2, 1]}   |   {playArea[2, 2]}   ");
            Console.WriteLine("         |       |       ");
            Console.WriteLine();
            turns++;
        }

        // Method: Check which player's turn
        public void PlayerTurn(int player, int input)
        {
            char playerSign = ' ';


            // Select player character
            if (player == 1)
                playerSign = 'X';
            else if (player == 2)
                playerSign = 'O';

            
            // 
            switch (input)
            {
                case 1: playArea[0, 0] = playerSign; break;
                case 2: playArea[0, 1] = playerSign; break;
                case 3: playArea[0, 2] = playerSign; break;
                case 4: playArea[1, 0] = playerSign; break;
                case 5: playArea[1, 1] = playerSign; break;
                case 6: playArea[1, 2] = playerSign; break;
                case 7: playArea[2, 0] = playerSign; break;
                case 8: playArea[2, 1] = playerSign; break;
                case 9: playArea[2, 2] = playerSign; break;
            }
        }


        // Method: Game
        public void StartGame()
        {
            int player = 2; // Player 1 starts
            int input = 0;
            bool inputCorrect = true;

            // Run code as long as the game is running
            do
            {
                
                // 
                if(player == 2)
                {
                    player = 1;
                    PlayerTurn(player, input);
                } 
                else if(player == 1)
                {
                    player = 2;
                    PlayerTurn(player, input);
                };

                // Set game board
                SetGameBoard();


                #region
                // Check winning condition
                char[] playerChars = { 'X', 'O' };
                foreach (char playerChar in playerChars)
                {
                    if((playerChar == playArea[0,0]) && (playerChar == playArea[0, 1]) && (playerChar == playArea[0, 2])
                        || (playerChar == playArea[1, 0]) && (playerChar == playArea[1, 1]) && (playerChar == playArea[1, 2])
                        || (playerChar == playArea[2, 0]) && (playerChar == playArea[2, 1]) && (playerChar == playArea[2, 2])
                        || (playerChar == playArea[0, 0]) && (playerChar == playArea[1, 0]) && (playerChar == playArea[2, 0])
                        || (playerChar == playArea[0, 1]) && (playerChar == playArea[1, 1]) && (playerChar == playArea[2, 1])
                        || (playerChar == playArea[0, 2]) && (playerChar == playArea[1, 2]) && (playerChar == playArea[2, 2])
                        || (playerChar == playArea[0, 0]) && (playerChar == playArea[1, 1]) && (playerChar == playArea[2, 2])
                        || (playerChar == playArea[2, 0]) && (playerChar == playArea[1, 1]) && (playerChar == playArea[0, 2])
                        )
                    {
                        if(playerChar == 'X')
                        {
                            Console.WriteLine("\nPlayer 2 has won!");
                        } 
                        else
                        {
                            Console.WriteLine("\nPlayer 1 has won!");
                        }

                        // Todo reset playArea
                        Console.WriteLine("Press any key to reset the game...");
                        Console.ReadKey();
                        ResetPlayArea();

                        break;
                    }
                    else if (turns == 10)
                    {
                        Console.WriteLine("\nIt's a DRAW!!");
                    }
                }


                #endregion


                #region
                // Test if field is already taken
                do
                {
                    Console.WriteLine($"\nPlayer {player}: Choose your field!");
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a valid number!");
                    }

                    // Check if play area is already used
                    if (input == 1 && (playArea[0, 0] == '1'))
                        inputCorrect = true;
                    else if (input == 2 && (playArea[0, 1] == '2'))
                        inputCorrect = true;
                    else if (input == 3 && (playArea[0, 2] == '3'))
                        inputCorrect = true;
                    else if (input == 4 && (playArea[1, 0] == '4'))
                        inputCorrect = true;
                    else if (input == 5 && (playArea[1, 1] == '5'))
                        inputCorrect = true;
                    else if (input == 6 && (playArea[1, 2] == '6'))
                        inputCorrect = true;
                    else if (input == 7 && (playArea[2, 0] == '7'))
                        inputCorrect = true;
                    else if (input == 8 && (playArea[2, 1] == '8'))
                        inputCorrect = true;
                    else if (input == 9 && (playArea[2, 2] == '9'))
                        inputCorrect = true;
                    else
                    {
                        Console.WriteLine("Incorrect input, please user another field!");
                        inputCorrect = false;

                    }

                } while (!inputCorrect);
                #endregion

            } while (true);
        }

        // Method: Reset playArea
        public void ResetPlayArea()
        {
            char[,] initialPlayArea = {
            {'1', '2', '3' },
            {'4', '5', '6' },
            {'7', '8', '9' }
        };


        playArea = initialPlayArea;
            SetGameBoard();
            turns = 0;
        }

    }
}
