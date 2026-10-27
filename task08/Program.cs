namespace task08
{
    public class Account
    {
        public string Name { get; set; }
        public double Balance { get; set; }

        public Account(string name = "Unnamed Account", double balance = 0.0)
        {
            this.Name = name;
            this.Balance = balance;
        }

        public virtual bool Deposit(double amount)
        {
            if (amount < 0)
                return false;
            else
            {
                Balance += amount;
                return true;
            }
        }

        public virtual bool Withdraw(double amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class SavingsAccount : Account
    {
        public double InterestRate { get; set; }
        public SavingsAccount(string name = "Unnamed Savings Account",double balance = 0.0,double interestRate = 0.0): base(name, balance)
        {
            InterestRate = interestRate;
        }

        public override bool Deposit(double amount)
        {
            amount += amount * InterestRate / 100;
            return base.Deposit(amount);
        }
    }

    public class CheckingAccount : Account
    {
        private const double Fee = 1.50;

        public CheckingAccount(string name = "Unnamed Checking Account", double balance = 0.0): base(name, balance)
        {

        }

        public override bool Withdraw(double amount)
        {
            return base.Withdraw(amount + Fee);
        }
    }


    public class TrustAccount : Account
    {
        public double InterestRate { get; set; }
        private int WithdrawCount = 0;

        public TrustAccount(string name = "Unnamed Trust Account",double balance = 0.0,double interestRate = 0.0): base(name, balance)
        {
            InterestRate = interestRate;
        }

        public override bool Deposit(double amount)
        {
            if (amount < 0)
                return false;

            amount += amount * InterestRate / 100;

            if (amount >= 5000)
                amount += 50;

            return base.Deposit(amount);
        }

        public override bool Withdraw(double amount)
        {
            if (WithdrawCount >= 3 || amount <= 0 || amount >= Balance * 0.20)
                return false;

            if (base.Withdraw(amount))
            {
                WithdrawCount++;
                return true;
            }

            return false;
        }
    }



    public static class AccountUtil
    {
        public static void Deposit(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to Accounts =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc}");
            }
        }
        public static void Withdraw(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            // Accounts
            var accounts = new List<Account>();
            accounts.Add(new Account());
            accounts.Add(new Account("Larry"));
            accounts.Add(new Account("Moe", 2000));
            accounts.Add(new Account("Curly", 5000));

            AccountUtil.Deposit(accounts, 1000);
            AccountUtil.Withdraw(accounts, 2000);

            // Savings
            var savAccounts = new List<SavingsAccount>();
            savAccounts.Add(new SavingsAccount());
            savAccounts.Add(new SavingsAccount("Superman"));
            savAccounts.Add(new SavingsAccount("Batman", 2000));
            savAccounts.Add(new SavingsAccount("Wonderwoman", 5000, 5.0));

            AccountUtil.Deposit(savAccounts.Cast<Account>().ToList(), 1000);
            AccountUtil.Withdraw(savAccounts.Cast<Account>().ToList(), 2000);

            // Checking
            var checAccounts = new List<CheckingAccount>();
            checAccounts.Add(new CheckingAccount());
            checAccounts.Add(new CheckingAccount("Larry2"));
            checAccounts.Add(new CheckingAccount("Moe2", 2000));
            checAccounts.Add(new CheckingAccount("Curly2", 5000));

            AccountUtil.Deposit(checAccounts.Cast<Account>().ToList(), 1000);
            AccountUtil.Withdraw(checAccounts.Cast<Account>().ToList(), 2000);
            AccountUtil.Withdraw(checAccounts.Cast<Account>().ToList(), 2000);

            // Trust
            var trustAccounts = new List<TrustAccount>();
            trustAccounts.Add(new TrustAccount());
            trustAccounts.Add(new TrustAccount("Superman2"));
            trustAccounts.Add(new TrustAccount("Batman2", 2000));
            trustAccounts.Add(new TrustAccount("Wonderwoman2", 5000, 5.0));

            AccountUtil.Deposit(trustAccounts.Cast<Account>().ToList(), 1000);
            AccountUtil.Deposit(trustAccounts.Cast<Account>().ToList(), 6000);
            AccountUtil.Withdraw(trustAccounts.Cast<Account>().ToList(), 2000);
            AccountUtil.Withdraw(trustAccounts.Cast<Account>().ToList(), 3000);
            AccountUtil.Withdraw(trustAccounts.Cast<Account>().ToList(), 500);

            Console.WriteLine();
        }

    }
}
