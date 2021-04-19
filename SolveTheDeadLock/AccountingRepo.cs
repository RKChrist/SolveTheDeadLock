using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SolveTheDeadLock
{
    public class AccountingRepo
    {
        public void TransferPrice(AccountingModel ac1, AccountingModel ac2, int sum)
        {
            Console.WriteLine("Transfer in process");

            lock (ac1)
            {
                Thread.Sleep(1000);

                lock (ac2)
                {
                    Console.WriteLine($"Finished transfering {sum}");
                }

            }

           
        }
    }
}
