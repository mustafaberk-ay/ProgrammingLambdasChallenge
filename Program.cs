using System;

namespace ProgrammingLambdasChallenge
{
    internal class Program
    {
        //define a delegate
        public delegate void myEventHandler(int value);

        class PiggyBank
        {
            private int _balance;
            public event myEventHandler balanceChanged;
            public int Balance
            {
                get { return _balance; }
                set
                { 
                    _balance = value;
                    this.balanceChanged(_balance);
                }
            }


        }
        static void Main(string[] args)
        {
            PiggyBank obj = new PiggyBank();
            obj.balanceChanged += (val) =>
            {
                if(val > 500)
                {
                    Console.WriteLine("You have reached your savings goal! You have {0}", val);
                }
                else
                {
                    Console.WriteLine("The balance amount is {0}", val);
                }
            };

            string userInput;
            do
            {
                Console.WriteLine("How much to deposit?");
                userInput = Console.ReadLine();
                if(userInput == "exit")
                {
                    return;
                }
                obj.Balance += Convert.ToInt32(userInput);
            }
            while (true);
        }
    }
}