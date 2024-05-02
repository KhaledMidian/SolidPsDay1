
////////////////////////////////////////////////////////////////////////////////////////////////
// LSP Violation
////////////////////////////////////////////////////////////////////////////////////////////////

public class Account
{
    public decimal Balance { get; protected set; }
    public virtual void Deposit(decimal amount)
        {
            Balance += amount;
        }
    public virtual void Withdraw(decimal amount)
    {
        if (Balance >= amount)
            {
                 Balance -= amount;
            }
        else
            {
                throw new InvalidOperationException("Insufficient balance.");
            }
    }
}
public class SavingsAccount : Account
{
    public decimal InterestRate { get; set; }
    public override void Withdraw(decimal amount)

    {
        // Impose a withdrawal fee
        amount += 5.0m;
        base.Withdraw(amount);
    }
}


////////////////////////////////////////////////////////////////////////////////////////////////
// Identification and Resolving
////////////////////////////////////////////////////////////////////////////////////////////////

// In the original implementation, the Account class violates the Liskov Substitution Principle (LSP)
// because the Withdraw method in the SavingsAccount subclass modifies the behavior of the base class
// without preserving the expected behavior defined in the base class. This violates the principle
// that derived classes should be substitutable for their base classes without affecting the behavior
// of the system.



////////////////////////////////////////////////////////////////////////////////////////////////
//  Resolving:
////////////////////////////////////////////////////////////////////////////////////////////////

// To identify and resolve this violation, we introduce an abstract class called WithdrawClass,
// which defines the common behavior for classes that support deposit and withdrawal operations.
// The Withdraw method is declared as abstract, allowing concrete subclasses to implement their
// own withdrawal logic while ensuring that they adhere to the same method signature.

public abstract WithdrawClass
{
    public abstract decimal Balance { get; protected set; }

    // Define a method for depositing funds into the account
    public abstract void Deposit(decimal amount);

    // Declare the Withdraw method as abstract to be implemented by concrete subclasses
    public abstract void Withdraw(decimal amount);
}

// The Account class now inherits from the WithdrawClass and provides a concrete implementation
// of the Withdraw method. It checks if the withdrawal amount is less than or equal to the current
// balance before allowing the withdrawal operation. If the balance is insufficient, it throws
// an InvalidOperationException.

public class Account : WithdrawClass
{
    public override void Deposit(decimal amount);
    {
        Balance += amount;
    }
    public override void Withdraw(decimal amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
        }
        else
        {
            throw new InvalidOperationException("Insufficient balance.");
        }
    }
}

// The SavingsAccount class also inherits from WithdrawClass and provides its own implementation
// of the Withdraw method. In addition to the withdrawal logic inherited from the base class, it
// imposes a withdrawal fee of $5.0 before processing the withdrawal.

public class SavingsAccount : WithdrawClass
{
    public decimal InterestRate { get; set; }

    public override void Deposit(decimal amount);
    {
        Balance += amount;
    }
    public override void Withdraw(decimal amount)
    {
        // Impose a withdrawal fee
        amount += 5.0m;
        
        // Call the Withdraw method of the base class to perform the withdrawal
        base.Withdraw(amount);
    }
}
