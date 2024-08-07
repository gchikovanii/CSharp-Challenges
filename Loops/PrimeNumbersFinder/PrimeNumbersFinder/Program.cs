//Prime Number Finder
//Create a program that finds and prints all prime numbers between 1 and 10,000.

for (int i = 30; i < 10000; i++)
{
    bool isPrime = true;
    for (int j = 2; j * j <= i; j++)
    {
        if (i % j == 0)
        {
            isPrime = false;
            break;
        }
    }
    if (isPrime)
        Console.Write("{0} ", i);
}
