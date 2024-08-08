//Knights Tour
//Create a program to solve the Knight's Tour problem on an 8x8 chessboard 


int[,] board = new int[8,8];
int movesCounter = 0;

int[] knightMovementsRows = 
{
    2, 2, 1, 1, -1, -1, -2, -2 
};
int[] knightMovementsCol = {  1, -1, 2, -2, -2, 2, -1, 1 };
for (int row = 0; row < board.GetLength(0); row++)
{
    for (int col = 0; col < board.GetLength(1); col++)
    {
        for (int ki = 0; ki < knightMovementsRows.Length; ki++)
        {
            if ((row + knightMovementsRows[ki] >= 0 && row + knightMovementsRows[ki] <= 8) && (col + knightMovementsCol[ki] >= 0 && col + knightMovementsCol[ki] <= 8))
                movesCounter++;
        }
    }
}
Console.WriteLine("Total count is: {0}", movesCounter);

