//Pascal’s Triangle
//Write a program that prints Pascal's triangle up to the 15th row.

int upTo = 15;
int[,] pascalsTriangle = new int[upTo, upTo];

for (int i = 0; i < upTo; i++)
{
    pascalsTriangle[i,0] = 1; // at the begining must be 1 
    pascalsTriangle[i,i] = 1; // at the end must be 1
    for (int j = 1; j < i; j++)
    {
        pascalsTriangle[i,j] = pascalsTriangle[i - 1, j - 1] + pascalsTriangle[i-1,j];
    }
}

for (int i = 0; i < upTo; i++)
{
    for (int j = 0;j < upTo - i - 1; j++)
    {
        Console.Write(" ");
    }

    for (int k = 0; k <= i; k++)
    {
        Console.Write(pascalsTriangle[i,k] + " ");
    }
    Console.WriteLine();
}