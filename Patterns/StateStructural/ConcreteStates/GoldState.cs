using StateStructural.Context;

namespace StateStructural.ConcreteStates
{
    public class GoldState : State
    {
        public GoldState(State state) : this(state.Balance, state.Account)
        {
        }

        public GoldState(double balance, Account account)
        {
            Balance = balance;
            Account = account;
            Initialize();
        }

        private void Initialize()
        {
            Interest = 0.05;
            LowerLimit = 1000.0;
            UpperLimit = 10000000.0;
        }

        public override void Deposit(double amount)
        {
            Balance += amount;
            StateChengeCheck();
        }

        public override void Withdraw(double amount)
        {
            Balance -= amount;
            StateChengeCheck();
        }

        public override void PayInterest()
        {
            Balance += Interest*Balance;
            StateChengeCheck();
        }

        private void StateChengeCheck()
        {
            if (Balance < 0.0)
            {
                Account.State = new RedState(this);
            }
            else if (Balance < LowerLimit)
            {
                Account.State = new SilverState(this);
            }
        }
    }
}