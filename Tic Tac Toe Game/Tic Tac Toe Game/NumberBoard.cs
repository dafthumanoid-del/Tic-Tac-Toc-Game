using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe_Game
{
    internal class NumberBoard
    {
        public static void NumberDisplay()
        {
            int[] numBoard = new int[9];

            for (int i = 0; i < numBoard.Length; i++) // 배열에 1, 2, 3, 4, 5, 6, 7, 8, 9 넣기
            {
                numBoard[i] = i + 1;
            }

            Console.WriteLine("위치 번호:");

            for (int i = 0; i < numBoard.Length; i++)
            {
                Console.Write(numBoard[i]);

                if ((i + 1) % 3 != 0)
                {
                    Console.Write(" | ");
                }
                else
                {
                    Console.WriteLine();
                    if (i < numBoard.Length - 1)
                    {
                        Console.WriteLine(new string('-', 9));
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
