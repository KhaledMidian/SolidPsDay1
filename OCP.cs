////////////////////////////////////////////////////////////////////////////////////////////////
// OCP Violation
////////////////////////////////////////////////////////////////////////////////////////////////
public class PaymentProcessor
{
public void ProcessPayment(PaymentType type, double amount)
{
switch (type)
{
case PaymentType.CreditCard:
// Process credit card payment
break;
case PaymentType.PayPal:
// Process PayPal payment
break;
case PaymentType.BankTransfer:
// Process bank transfer payment
break;
// Add more cases for other payment types
}
}
}

public enum PaymentType
{
CreditCard,
PayPal,
BankTransfer
}

////////////////////////////////////////////////////////////////////////////////////////////////
// Identification and Resolving
////////////////////////////////////////////////////////////////////////////////////////////////

////////////////////////////////////////////////////////////////////////////////////////////////
// Identification:
////////////////////////////////////////////////////////////////////////////////////////////////

// In the original code, the PaymentProcessor class violates the Open-Closed Principle (OCP) 
// by directly handling different payment types using a switch statement. This violates the 
// principle because every time a new payment type is added, the PaymentProcessor class needs 
// to be modified, which is not scalable and violates the principle of open for extension 
// but closed for modification.

////////////////////////////////////////////////////////////////////////////////////////////////
//Resolving:
////////////////////////////////////////////////////////////////////////////////////////////////

// To address this issue, we introduce an interface IPaymentProcessor that defines a common 
// method PaymentProcess(double amount) for processing payments. 
public interface IPaymentProcess
{
    public void PaymentProcess(double amount);
}



// By a separating class (CreditCard, PayPal, BankTransfer) that implements the 
// IPaymentProcessor interface and provides its own implementation of the PaymentProcess 
// method. This allows us to adhere to the OCP because new payment types can be added by 
// creating new classes that implement the IPaymentProcessor interface without modifying 
// existing code.
// The IPaymentProcessor interface provides a contract for payment processors, ensuring 
// that they all have a PaymentProcess method.


public class CreditCard:IPaymentProcess
{
    // Credit card information
    public void PaymentProcess(double amount)
    {
        // Code to make the payment process
    }
}

public class PayPal:IPaymentProcess
{
    // PayPal information
    public void PaymentProcess(double amount)
    {
        // Code to make the payment process
    }
}

public class BankTransfer:IPaymentProcess
{
    // Bank transfer information
    public void PaymentProcess(double amount)
    {
        // Code to make the payment process
    }
}


public class PaymentProcessor
{
    public void PaymentProcess(IPaymentProcess paymentMethod,double amount)
    {
        paymentMethod.PaymentProcess(amount);
    }
}