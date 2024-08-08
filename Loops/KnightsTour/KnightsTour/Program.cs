//Knights Tour
//Create a program to count the total number of valid knight moves on an 8x8 chessboard 

int[,] board = new int[8, 8];
int movesCounter = 0;

int[] knightMovementsRows =
{
    2, 2, 1, 1, -1, -1, -2, -2
};
int[] knightMovementsCol = { 1, -1, 2, -2, -2, 2, -1, 1 };
for (int row = 0; row < board.GetLength(0); row++)
{
    for (int col = 0; col < board.GetLength(1); col++)
    {
        for (int ki = 0; ki < knightMovementsRows.Length; ki++)
        {
            int moveX = knightMovementsRows[ki];
            int moveY = knightMovementsCol[ki];
            if (row + moveX >= 0 && row + moveX < 8 && col + moveY >= 0 && col + moveY < 8)
                    movesCounter++;
        }
    }
}
Console.WriteLine("Total count is: {0}", movesCounter);
