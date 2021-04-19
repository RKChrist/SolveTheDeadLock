using System;
using System.Threading;

namespace SolveTheDeadLock
{
    class Program
    {
        
        static void Main(string[] args)
        {
            AccountingModel ac = new AccountingModel() { ID = 1, Price = 100, Version = "1" };
            AccountingModel ac2 = new AccountingModel() { ID = 2, Price = 200, Version = "2" };
            AccountingRepo accountingRepo = new AccountingRepo();

            Thread transferMoney = new Thread(() => accountingRepo.TransferPrice(ac, ac2, 20));
            Thread transferMoney2 = new Thread(() => accountingRepo.TransferPrice(ac2, ac, 20));
            transferMoney.Start();
            transferMoney2.Start();

            transferMoney.Join();
            transferMoney2.Join();
            Console.WriteLine("Færdig med overførslerne");
        }


    }

}
