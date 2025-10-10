using System;
using System.Collections.Generic;
using NUnit.Framework;
using App.Topics.LinkedList.T2_LinkedList;

namespace App.Tests.Topics.LinkedList.T2_LinkedList;

public class LinkedListTasksTests
{
    [Test]
    public void RemoveDuplicates_MixedValues_PreservesFirstOccurrences()
    {
        var list = new LinkedList<int>(new[] { 3, 1, 2, 3, 2, 4, 1, 5, 5 });
        var result = LinkedListTasks.RemoveDuplicates(list);
        CollectionAssert.AreEqual(new[] { 3, 1, 2, 4, 5 }, result);
    }

    [Test]
    public void RemoveDuplicates_AllUnique_ReturnsSameOrder()
    {
        var list = new LinkedList<int>(new[] { 1, 2, 3 });
        var result = LinkedListTasks.RemoveDuplicates(list);
        CollectionAssert.AreEqual(new[] { 1, 2, 3 }, result);
    }

    [Test]
    public void RemoveDuplicates_AllSame_ReturnsSingle()
    {
        var list = new LinkedList<int>(new[] { 7, 7, 7, 7 });
        var result = LinkedListTasks.RemoveDuplicates(list);
        CollectionAssert.AreEqual(new[] { 7 }, result);
    }

    [Test]
    public void RemoveDuplicates_Empty_ReturnsEmpty()
    {
        var list = new LinkedList<int>();
        var result = LinkedListTasks.RemoveDuplicates(list);
        CollectionAssert.AreEqual(Array.Empty<int>(), result);
    }

    [Test]
    public void RemoveDuplicates_Null_Throws()
    {
        Assert.Throws<ArgumentNullException>(() => LinkedListTasks.RemoveDuplicates(null!));
    }
}
