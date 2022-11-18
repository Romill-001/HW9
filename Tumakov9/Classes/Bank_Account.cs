using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov9
{
    public class Bank_Account
    {
        private System.Collections.Queue Queue;
        private byte ID { get; set; }
        private decimal Balance { get; set; }
        public enum Acc_Type : byte
        {
            Сберегательный,
            Накопительный
        }
        private Acc_Type Type { get; set; }
        private static HashSet<byte> Last_Random_ID = new HashSet<byte>(0);

        public Bank_Account() { }
        public Bank_Account(byte iD, decimal balance, Acc_Type type)
        {
            ID = iD;
            Balance = balance;
            Type = type;

        }
        public void Print() => Console.WriteLine($"Id: {ID}\nBalace: {Balance}\nType: {Type}");
        public void generateID()
        {
            Random r = new Random();
            ID = (byte)r.Next(0, 255);
        }
        public byte new_ID()
        {
            Random r = new Random();
            ID = (byte)r.Next(0, 255);
            if (!Last_Random_ID.Contains(ID))
            {
                ID++;
            }
            return ID;
        }
        public void Add(decimal cash)
        {
            Balance += cash;
            Console.WriteLine($"Done! Balance: {Balance}");
            Queue.Enqueue(new BankTransaction(cash));


        }
        public void Lower(decimal cash)
        {
            if (Balance > 0)
            {
                if (Balance - cash > 0)
                {
                    Balance -= cash;
                    Console.WriteLine($"Done! Balance: {Balance}");
                }
                else
                {
                    Console.WriteLine($"Not enougth money! Balance: {Balance}");
                }
            }
            else
            {
                Console.WriteLine("Something is wrong!");
            }
            Queue.Enqueue(new BankTransaction(cash));
        }
        public void Transition(Bank_Account acc1, decimal perevod)
        {
            if (acc1.Balance > perevod)
            {
                acc1.Balance -= perevod;
                Balance += perevod;
            }
            else
            {
                Console.WriteLine("Not enought money");
            }
            Queue.Enqueue(new BankTransaction(perevod));
        }
        public void Dispose()
        {
            foreach (var i in Queue)
            {
                StreamWriter t = new StreamWriter("path.txt");
                t.WriteLine(i.ToString());
            }
            GC.SuppressFinalize(this);
        }

    }
}
