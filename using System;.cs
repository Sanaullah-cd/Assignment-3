using System;

// Class only stores order data
public class Order
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public Order(string productName, int quantity, double price)
    {
        ProductName = productName;
        Quantity = quantity;
        Price = price;
    }
}

// Class for order price calculation
public class OrderCalculator
{
    public double CalculateTotalPrice(Order order)
    {
        return order.Quantity * order.Price * 0.9; // 10% discount
    }
}

// Class for payment processing
public class PaymentProcessor
{
    public void ProcessPayment(string paymentDetails)
    {
        Console.WriteLine("Payment processed using: " + paymentDetails);
    }
}

// Class for notifications
public class NotificationService
{
    public void SendConfirmationEmail(string email)
    {
        Console.WriteLine("Confirmation email sent to: " + email);
    }
}


// Employee class delegates salary calculation to a strategy
public class Employee
{
    public string Name { get; set; }
    public double BaseSalary { get; set; }
    public ISalaryCalculator SalaryCalculator { get; set; }

    public Employee(string name, double baseSalary, ISalaryCalculator salaryCalculator)
    {
        Name = name;
        BaseSalary = baseSalary;
        SalaryCalculator = salaryCalculator;
    }

    public double CalculateSalary()
    {
        return SalaryCalculator.CalculateSalary(this);
    }
}

// Interface for salary calculation strategy
public interface ISalaryCalculator
{
    double CalculateSalary(Employee employee);
}

// Different implementations
public class PermanentSalaryCalculator : ISalaryCalculator
{
    public double CalculateSalary(Employee employee) => employee.BaseSalary * 1.2;
}

public class ContractSalaryCalculator : ISalaryCalculator
{
    public double CalculateSalary(Employee employee) => employee.BaseSalary * 1.1;
}

public class InternSalaryCalculator : ISalaryCalculator
{
    public double CalculateSalary(Employee employee) => employee.BaseSalary * 0.8;

}


    // Separate interfaces for each capability
public interface IPrinter
{
    void Print(string content);
}

public interface IScanner
{
    void Scan(string content);
}

public interface IFax
{
    void Fax(string content);
}

// All-in-one printer (supports all features)
public class AllInOnePrinter : IPrinter, IScanner, IFax
{
    public void Print(string content) => Console.WriteLine("Printing: " + content);
    public void Scan(string content) => Console.WriteLine("Scanning: " + content);
    public void Fax(string content) => Console.WriteLine("Faxing: " + content);
}

// Basic printer (only supports printing)
public class BasicPrinter : IPrinter
{
    public void Print(string content) => Console.WriteLine("Printing: " + content);
}


using System.Collections.Generic;

// Abstraction for message sending
public interface IMessageSender
{
    void SendMessage(string message);
}

// Implementations
public class EmailSender : IMessageSender
{
    public void SendMessage(string message) => Console.WriteLine("Email sent: " + message);
}

public class SmsSender : IMessageSender
{
    public void SendMessage(string message) => Console.WriteLine("SMS sent: " + message);
}

// High-level module depends on abstraction
public class NotificationService
{
    private readonly List<IMessageSender> _messageSenders;

    public NotificationService(List<IMessageSender> messageSenders)
    {
        _messageSenders = messageSenders;
    }

    public void SendNotification(string message)
    {
        foreach (var sender in _messageSenders)
        {
            sender.SendMessage(message);
        }
    }
}