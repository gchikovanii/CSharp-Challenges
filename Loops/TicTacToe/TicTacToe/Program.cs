string[,] table = new string[3, 3];
bool isPlaying = true;
Console.WriteLine("Player N1 enter your name");
string firstPlayer = Console.ReadLine();
Console.WriteLine("Player N2 enter your name");
string secondPlayer = Console.ReadLine();
//set by default first played and its X
string currentPlayer = firstPlayer;
string currentMarker = "X";

while (isPlaying)
{
    Console.Clear();
    PrintBoard(table);

    Console.Write("{0}, enter where you want to put {1} (row,col): ", currentPlayer, currentMarker);
    var toParse = Console.ReadLine();
    int[] parsedNums = ParseInput(toParse);
    if (parsedNums == null || table[parsedNums[0], parsedNums[1]] != null)
    {
        Console.WriteLine("Invalid move, please try again");
        continue;
    }
    table[parsedNums[0], parsedNums[1]] = currentMarker;

    if (ChekWinner(table))
    {
        Console.Clear();
        PrintBoard(table);
        Console.WriteLine("Winner is: {0}",currentPlayer);
        isPlaying = false;
        break;
    }
    if (CheckForDraw(table))
    {
        Console.Clear();
        PrintBoard(table);
        Console.WriteLine("It's a dead draw", firstPlayer);
        isPlaying = false;
        break;
    }
    currentPlayer = currentPlayer == firstPlayer ? secondPlayer : firstPlayer;
    currentMarker = currentMarker == "X" ? "O" : "X";
}


int[] ParseInput(string input)
{
    var parts = input.Split(',');
    if (parts.Length != 2)
        return null;
    if(int.TryParse(parts[0], out int row) && int.TryParse(parts[1], out int column))
    {
        if(row >= 0 && column >= 0 && row < 3 && column<3) 
            return [row, column];
    }
    return null;
}


void PrintBoard(string[,] board)
{
    Console.WriteLine("-------------");
    for (int i = 0; i < board.GetLength(0); i++)
    {
        Console.Write("|");

        for (int j = 0; j < board.GetLength(1); j++)
        {
            Console.Write(" {0} ", board[i,j] == null ? " " : board[i,j]);
            if (j < board.GetLength(1))
                Console.Write("|");
        }
        Console.WriteLine();
        if (i < board.GetLength(0))
            Console.WriteLine("-------------");
    }
}


bool ChekWinner(string[,] board)
{
    //chek in horizontal
    for (int i = 0; i < 3; i++)
    {
        if ((table[i, 0] != null && table[i, 0] == table[i, 1] && table[i, 1] == table[i, 2]) ||
            (table[0, i] != null && table[0, i] == table[1, i] && table[1, i] == table[2, i]))
        {
            return true;
        }
    }
    //check in diagonal
    if ((table[0, 0] != null && table[0, 0] == table[1, 1] && table[1, 1] == table[2, 2]) ||
            (table[0, 2] != null && table[0, 2] == table[1, 1] && table[1, 1] == table[2, 0]))
    {
        return true;
    }
    return false;
}
bool CheckForDraw(string[,] board)
{
    foreach (var i in board)
    {
        if (i == null)
            return false;
    }
    return true;
}
