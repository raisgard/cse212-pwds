using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.
[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities, then dequeue all of them.
    // Expected Result: Items should be dequeued in order of priority: highest first, then next highest, etc.
    // Defect(s) Found: Items were dequeued in insertion order (FIFO) instead of by priority.
    public void TestPriorityQueue_DequeueHighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 2);
        priorityQueue.Enqueue("High", 3);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with the same priority, then dequeue them.
    // Expected Result: Items with equal priority should be dequeued in the order they were added (FIFO).
    // Defect(s) Found: Items with equal priority were dequeued out of order.
    public void TestPriorityQueue_FIFOWIthSamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Mix of priorities and FIFO behavior.
    // Expected Result: Always remove the current highest priority, respecting FIFO for ties.
    // Defect(s) Found: Highest priority element not always chosen; FIFO not respected for ties.
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low1", 1);
        priorityQueue.Enqueue("High1", 3);
        priorityQueue.Enqueue("Medium", 2);
        priorityQueue.Enqueue("High2", 3);

        Assert.AreEqual("High1", priorityQueue.Dequeue()); // Highest, earliest
        Assert.AreEqual("High2", priorityQueue.Dequeue()); // Next highest, next earliest
        Assert.AreEqual("Medium", priorityQueue.Dequeue()); // Then medium
        Assert.AreEqual("Low1", priorityQueue.Dequeue()); // Then low
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: InvalidOperationException with message "The queue is empty." should be thrown.
    // Defect(s) Found: No exception thrown, or wrong exception/message.
    public void TestPriorityQueue_EmptyQueueThrows()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
        catch (Exception ex)
        {
            Assert.Fail($"Unexpected exception type thrown: {ex.GetType()}");
        }
    }
}
