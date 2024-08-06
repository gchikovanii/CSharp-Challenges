//Fibonacci Sequence Generator
//Write a program that generates the first 50 numbers of the Fibonacci sequence.
int fibonacciNumber = 0;
int firstNum = 0;
int secondNum = 1;
int temp;
while (fibonacciNumber != -1)
{
    Console.WriteLine ("Enter fibonacci sequence number or -1 for exit: ");
    bool convert = Int32.TryParse(Console.ReadLine(), out fibonacciNumber);
    if (fibonacciNumber == -1)
        break;
    else if (convert == false || fibonacciNumber < 0 )
    {
        Console.WriteLine("Incorrect data");
        continue;
    }
    else if (fibonacciNumber >= 47)
    {
        Console.WriteLine("Maxium number is 47");
        continue;
    }
    else
    {
        Console.Write("{0}, {1}", firstNum, secondNum);
        for (int i = 2; i < fibonacciNumber; i++)
        {
            temp = firstNum + secondNum;
            firstNum = secondNum;
            secondNum = temp;
            Console.Write(", {0}", temp);
        }
        Console.WriteLine();
        firstNum = 0;
        secondNum = 1;
    }
}