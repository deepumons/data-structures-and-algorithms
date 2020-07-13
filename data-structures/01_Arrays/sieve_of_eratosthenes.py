import array as arr

def find_primes(n):

    prime = arr.array('i', [1] * n)

    for divisor in range(2, n, 1):
        # check for limiting condition
        if (divisor * divisor < n):
        # mark all the multiples of the prime number as not prime
            if (prime[divisor] == 1):
                for i in range(2, n, 1):
                    if (divisor * i < n):
                        prime[divisor * i] = 0
                        
                        
    for i in range(len(prime)):
        print(i, ": ", prime[i])
                    
find_primes(50)
    
    
    