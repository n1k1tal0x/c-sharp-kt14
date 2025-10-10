using System;
using NUnit.Framework;
using App.Topics.StackQueue.T4_StackQueue;

namespace App.Tests.Topics.StackQueue.T4_StackQueue;

public class MyQueueTests
{
    [Test]
    public void EnqueueDequeue_OrderIsFIFO()
    {
        var q = new MyQueue<int>();
        q.Enqueue(1);
        q.Enqueue(2);
        q.Enqueue(3);
        Assert.That(q.Dequeue(), Is.EqualTo(1));
        Assert.That(q.Dequeue(), Is.EqualTo(2));
        Assert.That(q.Dequeue(), Is.EqualTo(3));
        Assert.That(q.IsEmpty, Is.True);
        Assert.That(q.Count, Is.EqualTo(0));
    }

    [Test]
    public void Peek_DoesNotRemove()
    {
        var q = new MyQueue<string>();
        q.Enqueue("a");
        q.Enqueue("b");
        Assert.That(q.Peek(), Is.EqualTo("a"));
        Assert.That(q.Count, Is.EqualTo(2));
        Assert.That(q.Dequeue(), Is.EqualTo("a"));
        Assert.That(q.Dequeue(), Is.EqualTo("b"));
    }

    [Test]
    public void MixedOperations_WorkAsExpected()
    {
        var q = new MyQueue<int>();
        q.Enqueue(10);
        q.Enqueue(20);
        Assert.That(q.Dequeue(), Is.EqualTo(10));
        q.Enqueue(30);
        Assert.That(q.Peek(), Is.EqualTo(20));
        Assert.That(q.Dequeue(), Is.EqualTo(20));
        Assert.That(q.Dequeue(), Is.EqualTo(30));
        Assert.That(q.IsEmpty, Is.True);
    }

    [Test]
    public void EmptyQueue_DequeueOrPeek_Throws()
    {
        var q = new MyQueue<int>();
        Assert.Throws<InvalidOperationException>(() => q.Dequeue());
        Assert.Throws<InvalidOperationException>(() => q.Peek());
    }
}
