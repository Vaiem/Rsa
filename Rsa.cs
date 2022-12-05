public class Rsa : IRsa
    {
        public void RsaCriptor(int q, int p)
        {
            int N = SearcheN(q, p);
            int Fn = SearcheFn(q, p);
            int e = SearcheE(Fn); 
            int d = SearcheD(e, Fn);
            
        }

        private int SearcheE(int Fn)
        {
            int e = Fn/4;
            while (ReciprocalPrimes(e,Fn) != true)
            {
                e += 1;
            }
            return e;
        }

        private int SearcheN(int q, int p)
        {
            return q * p;
        }
        
        private int SearcheD(int e, int Fn)
        {
            int d = 2;
            int res = 0;
            while ( res != 1)
            {
                
                if (d == e)
                {
                    d++;
                }
                res = (d * e) % Fn;
                if (res == 1)
                {
                    if (checkSimplePrimes(d))
                    {
                        return d;
                    }
                }
                d++;
            }
            return 0;
        }
        
        private int SearcheFn(int p, int q)
        {
            return (p - 1) * (q - 1);
        }
         
        private bool ReciprocalPrimes(int e, int Fn)
        {
            if (checkSimplePrimes(e) != true)
            {
                return false;
            }
            
            while (e >= 1 && Fn >= 1)
            {
                if (e > Fn)
                {
                    e %= Fn;
                }
                else
                {
                    Fn  %= e;
                    
                }
            }

            return (e+Fn == 1);
        }

        private bool checkSimplePrimes(int Item)
        {
            for (int i = 2; i < Item; i++)
            {
                if (Item % i == 0)
                {
                    return false;
                }
            }

            return true;
 
        }

        public string Crypt(string m, string e, string n)
        {
            return BigInteger.ModPow(BigInteger.Parse(m), BigInteger.Parse(e), BigInteger.Parse(n)).ToString();
        }
        
        public string DeCrypt(string m, string d, string n)
        {
            return BigInteger.ModPow(BigInteger.Parse(m), BigInteger.Parse(d), BigInteger.Parse(n)).ToString();
        }
        
        
    }