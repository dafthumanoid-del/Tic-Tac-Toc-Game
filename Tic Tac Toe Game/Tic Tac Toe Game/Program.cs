using System;
using Tic_Tac_Toe_Game;

class Play
{ 
    static void Main()
    {
        GameBoard.GamePlay();
        Console.WriteLine();
        Console.Write("종료하려면 Enter를 누르세요.");
        Console.ReadKey(true);
    }
}