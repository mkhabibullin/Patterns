using System;

namespace StateStructural.ConcreteStates
{
    public class RedState : State
    {
        private double ServiceFree { get; set; }

        public RedState(State state)
        {
            Balance = state.Balance;
            Account = state.Account;
            Initialize();
        }

        private void Initialize()
        {
            Interest = 0.0;
            LowerLimit = -100.0;
            UpperLimit = 0.0;
            ServiceFree = 15.0;
        }

        public override void Deposit(double amount)
        {
            Balance += amount;
            StateChangeCheck();
        }

        public override void Withdraw(double amount)
        {
            Balance -= amount - ServiceFree;
            Console.WriteLine("No funds available for withdrawal!");
        }

        public override void PayInterest()
        {
        }

        private void StateChangeCheck()
        {
            if (Balance > UpperLimit)
            {
                Account.State = new SilverState(this);
            }
        }
    }
}