using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Asynchronous
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int min = 1, max = 1000;

            await GetPrimeNumbersAsync(min, max);
            
            Console.WriteLine("End");
        }
        static async Task<List<int>> GetPrimeNumbersAsync(int min, int max) 
        {
            List<int> results = new List<int>();
            
            var list = await Task.Factory.StartNew(() => {
                
                for (var i = min; i <= max; i++) {
                    if(IsPrimeNumber(i)) {
                        results.Add(i);
                        Console.WriteLine(i);
                    }
                }   

                return results;
            });

            return list;
        }
        static bool IsPrimeNumber(int number) 
        {
            if(number < 2) {
                return false;
            }

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for(var i = 2; i <= boundary; i++) {
                if(number % i == 0) {
                    return false;
                }
            }

            return true;
        }
    }
}
