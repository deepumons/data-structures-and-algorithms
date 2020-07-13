class SieveOfEratosthenes
{
	public static void Main(string[] args)
	{
		int n = 50;		
		
		// Declare and initialize an array
		bool[] primes = new bool[n];
		
		// Assume all elements as prime, untill proven otherwise		
		for(int i = 0; i < n; i++)
			primes[i] = true;
			
		for(int i = 2; i * i < n; i++)
			// If the number is prime, mark all its multiples as non prime
			if(primes[i] == true)			
				for(int j = 2; i * j < n; j++)
						primes[i*j] = false;
		
		System.Console.WriteLine("List of all prime numbers before {0}:", n);
		
		for(int i = 2; i < n; i++)
			if(primes[i] == true)
				System.Console.WriteLine(i);
	}
}