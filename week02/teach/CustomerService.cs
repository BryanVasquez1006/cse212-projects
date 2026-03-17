using System.Diagnostics;

/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Create CustomerService with invalid size (0)
        // Expected Result: max_size should default to 10 
        Console.WriteLine("Test 1");
        var cs = new CustomerService(0);
        var csResult = cs.ToString();

        if (csResult.Contains("max_size=10"))
        {
            Console.WriteLine("✅ Test passed!");
        }
        else
        {
            Console.WriteLine("❌ Test failed: max_size was not set to 10");
        }
        // Defect(s) Found: evaluation in AddNewCustomer method was incorrect.

        Console.WriteLine("=================");

        // Test 2
        // Scenario: The AddNewCustomer method shall enqueue a new customer into the queue
        // Expected Result: A new customer added to the queue
        // Defect(s) Found: 
        Console.WriteLine("Test 2");
        var csTest2 = new CustomerService(2);
        Console.SetIn(new StringReader(
            @"Bryan
            A123
            Internet is down"));
        csTest2.AddNewCustomer();
        var csTest2Result = csTest2.ToString();

        if (csTest2Result.Contains("size=1"))
        {
            Console.WriteLine("Test passed! A new customer was added");
        }
        else
        {
            Console.WriteLine("Test failed! No customer was added.");
        }

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below

        //Test 3
        //Scenario: The queue should not add another customer when reaching their maximum.
        //Expected Result: An error message should be displayed.
        Console.WriteLine("Test 3");
        var csTest3 = new CustomerService(1);
        Console.SetIn(new StringReader(
            @"Bryan
            A123
            Internet is down
            Christian
            C123
            TV broken"            
        ));
        csTest3.AddNewCustomer();
        csTest3.AddNewCustomer();
        var csTest3Result = csTest3.ToString();
        if (csTest3Result.Contains("size=1"))
        {
            Console.WriteLine("Test passed, no more cx can be added");
        }
        else
        {
            Console.WriteLine("Test failed, a CX was added on the queue");
        }
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer()
    {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id:");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer()
    {
        _queue.RemoveAt(0);
        var customer = _queue[0];
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}