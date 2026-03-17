using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: The Enqueue function shall add an item to the back of the queue. 
    //When Dequeued, the function shall remove the item with the highest priority and return it's value.
    // Expected Result: C,B,A.
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 4);
        priorityQueue.Enqueue("B", 9);
        priorityQueue.Enqueue("C", 10);

        var result1 = priorityQueue.Dequeue();
        var result2 = priorityQueue.Dequeue();

        Assert.AreEqual("C", result1);
        Assert.AreEqual("B", result2);
    }

    [TestMethod]
    // Scenario: If there are more than one item with the highest priority, then the item
    // closest to the front of thequeue will be removed.
    // Expected Result: B, C, A
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 10);
        priorityQueue.Enqueue("C", 10);

        var result1 = priorityQueue.Dequeue();
        var result2 = priorityQueue.Dequeue();
        var result3 = priorityQueue.Dequeue();

        Assert.AreEqual("B", result1);
        Assert.AreEqual("C", result2);
        Assert.AreEqual("A", result3);
    }

    // Add more test cases as needed below.

    [TestMethod]
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
           priorityQueue.Dequeue();
           Assert.Fail("Exception should have been thrown");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}