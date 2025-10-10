using System;
using NUnit.Framework;
using App.Topics.LinkedList.T2b_DoubleLinkedList;
using NUnit.Framework.Legacy;

namespace App.Tests.Topics.LinkedList.T2b_DoubleLinkedList;

public class DoubleLinkedListTests
{
    [Test]
    public void Empty_Current_Throws()
    {
        var list = new DoubleLinkedList<int>();
        Assert.Throws<InvalidOperationException>(() => { var _ = list.Current; });
        Assert.That(list.IsEmpty, Is.True);
        Assert.That(list.Count, Is.EqualTo(0));
    }

    [Test]
    public void Empty_AddBeforeOrAfterCurrent_Throws()
    {
        var list = new DoubleLinkedList<int>();
        Assert.Throws<InvalidOperationException>(() => list.AddBeforeCurrent(1));
        Assert.Throws<InvalidOperationException>(() => list.AddAfterCurrent(1));
    }

    [Test]
    public void AddFirst_AddLast_ToArray_AndNavigation()
    {
        var list = new DoubleLinkedList<int>();
        list.AddFirst(2);         // [2]
        list.AddFirst(1);         // [1,2]
        list.AddLast(3);          // [1,2,3]

        Assert.That(list.IsEmpty, Is.False);
        Assert.That(list.Count, Is.EqualTo(3));
        CollectionAssert.AreEqual(new[] { 1, 2, 3 }, list.ToArray());

        list.MoveFirst();
        Assert.That(list.Current, Is.EqualTo(1));
        Assert.That(list.MoveNext(), Is.True);
        Assert.That(list.Current, Is.EqualTo(2));
        Assert.That(list.MoveNext(), Is.True);
        Assert.That(list.Current, Is.EqualTo(3));
        Assert.That(list.MoveNext(), Is.False); // на последнем
        Assert.That(list.Current, Is.EqualTo(3));
        Assert.That(list.MovePrev(), Is.True);
        Assert.That(list.Current, Is.EqualTo(2));
        Assert.That(list.MovePrev(), Is.True);
        Assert.That(list.Current, Is.EqualTo(1));
        Assert.That(list.MovePrev(), Is.False); // на первом
        Assert.That(list.Current, Is.EqualTo(1));
    }

    [Test]
    public void AddBeforeCurrent_And_AddAfterCurrent_PreserveCurrent()
    {
        var list = new DoubleLinkedList<int>();
        list.AddLast(1);          // [1]
        list.AddLast(3);          // [1,3]

        list.MoveLast();          // current -> 3
        list.AddBeforeCurrent(2); // [1,2,3], current stays at 3
        CollectionAssert.AreEqual(new[] { 1, 2, 3 }, list.ToArray());
        Assert.That(list.Current, Is.EqualTo(3));

        list.MoveFirst();         // current -> 1
        list.AddAfterCurrent(10); // [1,10,2,3], current stays at 1
        CollectionAssert.AreEqual(new[] { 1, 10, 2, 3 }, list.ToArray());
        Assert.That(list.Current, Is.EqualTo(1));

        Assert.That(list.MoveNext(), Is.True);  // current -> 10
        Assert.That(list.Current, Is.EqualTo(10));
    }

    [Test]
    public void SingleElement_MovePrevNext_ReturnFalse()
    {
        var list = new DoubleLinkedList<string>();
        list.AddFirst("only");
        list.MoveFirst();
        Assert.That(list.MovePrev(), Is.False);
        Assert.That(list.MoveNext(), Is.False);
        Assert.That(list.Current, Is.EqualTo("only"));
    }

    [Test]
    public void AddAfterCurrent_WhenAtLast_Appends()
    {
        var list = new DoubleLinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);
        list.MoveLast();          // current -> 2
        list.AddAfterCurrent(3);  // [1,2,3]

        Assert.That(list.Current, Is.EqualTo(2)); // current not changed
        CollectionAssert.AreEqual(new[] { 1, 2, 3 }, list.ToArray());
        list.MoveNext();
        Assert.That(list.Current, Is.EqualTo(3));
    }
}
