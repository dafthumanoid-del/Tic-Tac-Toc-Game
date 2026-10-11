using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Tic_Tac_Toe_Game
{
    internal class GameBoard
    {
        public static void GamePlay()
        {
            string[] dotBoard = new string[9];

            for (int i = 0; i < dotBoard.Length; i++)
            {
                dotBoard[i] = ".";
            }

            int[,] winconditions = new int[,] // 승리 조건                                               
            {
                {0, 1, 2},
                {3, 4, 5},
                {6, 7, 8},
                {0, 3, 6},
                {1, 4, 7},
                {2, 5, 8},
                {0, 4, 8},
                {2, 4, 6},
            };

            string playerX = "플레이어 X";
            string playerO = "플레이어 O";
            bool playerWin = false;
            bool playerdraw = false;
            bool playerTurn = true;
            string currentPlayer = playerTurn ? "X" : "O";

            while (true)
            {
                Console.Clear();
                GameTitle.Title();
                NumberBoard.NumberDisplay();
                Console.WriteLine("현재 보드:");

                for (int i = 0; i < dotBoard.Length; i++)
                {
                    Console.Write(dotBoard[i]);

                    if ((i + 1) % 3 != 0)
                    {
                        Console.Write(" | ");
                    }
                    else
                    {
                        Console.WriteLine();
                        if (i < dotBoard.Length - 1)
                        {
                            Console.WriteLine(new string('-', 9));
                        }
                    }
                }
                if (playerWin)
                {
                    Console.WriteLine();
                    Console.WriteLine($"플레이어 {currentPlayer} 승리!");
                    break;
                }
                else if (playerdraw)
                {
                    Console.WriteLine();
                    Console.WriteLine($"무승부입니다!");
                    break;
                }

                Console.WriteLine();
                //--------------------------------------------------------------------
                // 게임 시스템
                while (true)
                {
                    Console.WriteLine($"{(playerTurn ? playerX : playerO)}의 차례입니다.");
                    Console.Write("위치를 선택하세요 (1~9): ");
                    string number = Console.ReadLine();

                    bool check = int.TryParse(number, out int Number);

                    if (check == false)
                    {
                        Console.WriteLine("숫자로 위치를 입력하세요.");
                        Console.WriteLine();
                        continue;
                    }
                    else if (Number < 1 || Number > 9)
                    {
                        Console.WriteLine("1부터 9까지의 번호를 입력하세요.");
                        Console.WriteLine();
                        continue;
                    }
                    else if (dotBoard[Number - 1] == "X" || dotBoard[Number - 1] == "O")
                    {
                        Console.WriteLine("이미 선택한 칸입니다. 빈칸을 선택하세요.");
                        Console.WriteLine();
                        continue;
                    }
                    dotBoard[Number - 1] = playerTurn ? "X" : "O";
                    playerTurn = !playerTurn;
                    break;
                }
                for (int i = 0; i < winconditions.GetLength(0); i++)
                {
                    int win1 = (int)winconditions[i, 0];
                    int win2 = (int)winconditions[i, 1];
                    int win3 = (int)winconditions[i, 2];

                    if (dotBoard[win1] == currentPlayer && dotBoard[win2] == currentPlayer && dotBoard[win3] == currentPlayer)
                    {
                        playerWin = true;
                        break;
                    }
                }
                if (!playerWin)
                {
                    bool isFull = true;
                    foreach (string cell in dotBoard)
                    {
                        if (cell == ".")
                        {
                            isFull = false;
                            break;
                        }
                    }
                    if (isFull)
                    {
                        playerdraw = true;
                    }
                }
            }
        }
    }
}
