////////////////////////////////////////////////////////////////////////////////////////////////
// SRP Violation
////////////////////////////////////////////////////////////////////////////////////////////////
public class Employee
{
public string Name { get; set; }
public decimal Salary { get; set; }
public string Department { get; set; }
public decimal CalculateYearlySalary()
{
return Salary * 12;
}
public void GenerateReport(string reportType)
{
// Code to generate report based on reportType
}
public void SendNotification(string recipient, string message)
{
// Code to send email notification
}
}

////////////////////////////////////////////////////////////////////////////////////////////////
//  Identification and Resolving
////////////////////////////////////////////////////////////////////////////////////////////////

////////////////////////////////////////////////////////////////////////////////////////////////
//Identification:
////////////////////////////////////////////////////////////////////////////////////////////////

//The original code violates the Single Responsibility Principle (SRP) 
//by having the Employee class responsible for multiple tasks,
//including calculating yearly salary, generating reports, 
//and sending notifications.

//To address this violation, 
//the code has been refactored into multiple classes, each responsible for a single task.


////////////////////////////////////////////////////////////////////////////////////////////////
//  Resolving:
////////////////////////////////////////////////////////////////////////////////////////////////

//1-Employee class:
//Contains properties for employee details (name, salary, department).
//No longer responsible for performing tasks unrelated to employee information.

public class Employee
{
public string Name { get; set; }
public decimal Salary { get; set; }
public string Department { get; set; }
}

//2-SalaryCalculator class:
//Responsible for calculating the yearly salary of an employee.
//Takes an Employee object as input and returns the calculated yearly salary.

public class SalaryCalculator
{
    public decimal CalculateYearlySalary(Employee employee)
    {
        return Salary * 12;
    }

    public decimal CalculatedailySalary(Employee employee)
    {
        return Salary / 30 ;
    }

}

//3-ReportGenerator class:
//Handles the generation of reports for an employee.
//Takes an Employee object and a report type as input and generates 
//the report based on the specified type.


public class ReportGenerator
{
    public decimal GenerateReport(Employee employee,string reportType)
    {
        // Code to generate report based on reportType
    }

}

//4-PostMan class:
//Responsible for sending notifications to employees.
//Takes recipient and message parameters and sends the notification.

public class PostMan
{
   public void SendNotification(Employee employee,string recipient, string message)
    {
    // Code to send email notification
    }

}