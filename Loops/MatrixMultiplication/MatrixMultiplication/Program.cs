//Matrix Multiplication
//Implement matrix multiplication. Your program should take two matrices of size 3x3 and output their product.

int length = 3;
int[,] matrix = new int[3,3];
for (int i = 0; i < length; i++)
{
    for (int j = 0; j < length; j ++)
    {
        Console.Write("Enter element at position {0} {1}: ",i,j);
        int number = int.Parse(Console.ReadLine());
        matrix[i,j] = number;
    }
}
Console.WriteLine("Fill second matrix");
int[,] matrixTwo = new int[3, 3];
for (int i = 0; i < length; i++)
{
    for (int j = 0; j < length; j++)
    {
        Console.Write("Enter element at position {0} {1}: ", i, j);
        int number = int.Parse(Console.ReadLine());
        matrixTwo[i, j] = number;
    }
}

Console.WriteLine("Multiplying 3x3 matrix on 3x3 matrix");
Console.WriteLine("Calculating...");
Thread.Sleep(1000);

int[,] resultMatrix = new int[3, 3];

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrixTwo.GetLength(1); j++)
    {
        int sum = 0;
        for (int k = 0; k < matrix.GetLength(1); k++)
        {
            sum += matrix[i, k] * matrixTwo[k,j];
        }
        resultMatrix[i, j] = sum;
    }
    Console.WriteLine();
}


//Displaying result
for (int i = 0; i < resultMatrix.GetLength(0); i++)
{
    for (int j = 0; j < resultMatrix.GetLength(1); j++)
    {
        Console.Write(resultMatrix[i,j] + " ");
    }
    Console.WriteLine();
}