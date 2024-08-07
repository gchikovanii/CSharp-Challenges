//Sieve of Eratosthenes
//Implement the Sieve of Eratosthenes to find all prime numbers less than 1,000.

int upTo = 1000;
bool[] isPrime = new bool[upTo + 1];

// Initialize all entries as true(except 0 and 1, they are not prime)
for (int i = 2; i <= upTo; i++)
{
    isPrime[i] = true;
}

//select non primes and mark with false
for (int i = 2; i * i <= upTo; i++)
{
	if (isPrime[i])
	{
        for (int j = i * i; j <= upTo; j += i)
        {
            isPrime[j] = false;
        }
    }
}


for(int i = 2; i <= upTo; i++)
{
	if(isPrime[i])	
		Console.Write("{0} ",i);
}


















//int upTo = 1000;
//bool[] isPrime = new bool[upTo + 1];
//for (int i = 2; i <= upTo; i++)
//{
//    isPrime[i] = true;
//}
//for (int i = 2; i * i < upTo; i++)
//{
//    if (isPrime[i])
//    {
//        for (int j = i*i; j <= upTo ; j+=i)
//        {
//            isPrime[j] = false;
//        }
//    }
//}for (int i = 0; i < upTo; i++)
//{
//    if(isPrime[i])
//        Console.Write("{0} ", i);
//}