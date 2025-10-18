using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using App.Topics.Collections.T1_Collections;

namespace App.Tests.Topics.Collections.T1_Collections;

public class CollectionsTasksTests
{
    [Test]
    public void NonGeneric_MixedInput_Unique_PreserveOrder()
    {
        var input = new ArrayList { " a ", 1, null, "B", "b", "A", " a", new object() };
        var result = CollectionsTasks.FilterUniqueStringsNonGeneric(input);

        var arr = result.Cast<object>().ToArray();
        Assert.That(arr, Is.EqualTo(new object[] { "a", "B" }));
    }

    [Test]
    public void NonGeneric_OnlyNonStrings_ReturnsEmpty()
    {
        var input = new ArrayList { 1, 2, 3, new object() };
        var result = CollectionsTasks.FilterUniqueStringsNonGeneric(input);
        Assert.That(result.Count, Is.EqualTo(0));
    }

    [Test]

    public void Generic_StringsWithSpacesAndDuplicates_CaseInsensitive()
    {
        IEnumerable<string> input = new[] { " a ", "A", "B", " b", "b ", "", "  " };
        var result = CollectionsTasks.FilterUniqueStringsGeneric(input);
        Assert.That(result, Is.EqualTo(new List<string> { "a", "B" }));
    }

    [Test]
    public void Generic_EmptyInput_ReturnsEmpty()
    {
        IEnumerable<string> input = new string[0];
        var result = CollectionsTasks.FilterUniqueStringsGeneric(input);
        Assert.That(result, Is.Empty);
    }
}
