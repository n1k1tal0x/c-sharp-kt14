using System;
using NUnit.Framework;
using App.Topics.LinkedList.T2b_DoubleLinkedList;
using NUnit.Framework.Legacy;

namespace App.Tests.Topics.LinkedList.T2b_DoubleLinkedList;

public class DoubleLinkedListTests
{
    [Test]
    public void Create_AddBefore_AddAfter_LinksAndOrder()
    {
        var node = new DoubleLinkedList<int>(2); // [2]
        node.AddBefore(1);                       // [1,2]
        node.AddAfter(3);                        // [1,2,3]

        CollectionAssert.AreEqual(new[] { 1, 2, 3 }, node.ToArray());

        Assert.That(node.Prev!.Value, Is.EqualTo(1));
        Assert.That(node.Next!.Value, Is.EqualTo(3));
        Assert.That(node.Prev!.Next, Is.SameAs(node));
        Assert.That(node.Next!.Prev, Is.SameAs(node));
    }

    [Test]
    public void AddFirst_AddLast_FromMiddle_BuildsEnds()
    {
        var node = new DoubleLinkedList<int>(2); // [2]
        node.AddBefore(1);                       // [1,2]
        node.AddAfter(3);                        // [1,2,3]

        node.AddFirst(0);                        // [0,1,2,3]
        node.AddLast(4);                         // [0,1,2,3,4]

        CollectionAssert.AreEqual(new[] { 0, 1, 2, 3, 4 }, node.ToArray());
        Assert.That(node.Value, Is.EqualTo(2));
        Assert.That(node.Prev!.Value, Is.EqualTo(1));
        Assert.That(node.Next!.Value, Is.EqualTo(3));
    }

    [Test]
    public void Count_IsSame_FromAnyNode()
    {
        var mid = new DoubleLinkedList<string>("b"); // [b]
        mid.AddBefore("a");                           // [a,b]
        mid.AddAfter("c");                            // [a,b,c]
        mid.AddLast("d");                             // [a,b,c,d]
        mid.AddFirst("0");                            // [0,a,b,c,d]

        // get head
        var head = mid;
        while (head.Prev != null) head = head.Prev;

        // get tail
        var tail = mid;
        while (tail.Next != null) tail = tail.Next;

        Assert.That(head.Count, Is.EqualTo(5));
        Assert.That(mid.Count, Is.EqualTo(5));
        Assert.That(tail.Count, Is.EqualTo(5));
    }

    [Test]
    public void HeadAndTail_Nulls_OnEnds()
    {
        var mid = new DoubleLinkedList<int>(1);
        mid.AddLast(2);
        mid.AddLast(3);
        mid.AddFirst(0);

        var head = mid; while (head.Prev != null) head = head.Prev;
        var tail = mid; while (tail.Next != null) tail = tail.Next;

        Assert.That(head.Prev, Is.Null);
        Assert.That(tail.Next, Is.Null);
        CollectionAssert.AreEqual(new[] { 0, 1, 2, 3 }, mid.ToArray());
    }
}
