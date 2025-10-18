//using System.Collections.Generic;
//using NUnit.Framework;
//using App.Topics.Dictionary.T3_Dictionary;

//namespace App.Tests.Topics.Dictionary.T3_Dictionary;

//public class DictionaryTasksTests
//{
//    [Test]
//    public void TopNWords_BasicCountsAndSorting()
//    {
//        string text = "Hello, hello world! HELLO-world.";
//        var result = DictionaryTasks.TopNWords(text, 2);
//        var expected = new List<KeyValuePair<string, int>>
//        {
//            new("hello", 3),
//            new("world", 2)
//        };
//        Assert.That(result, Is.EqualTo(expected));
//    }

//    [Test]
//    public void TopNWords_TieBreaker_ByWordAsc()
//    {
//        string text = "a b c a b x";
//        var result = DictionaryTasks.TopNWords(text, 2);
//        var expected = new List<KeyValuePair<string, int>>
//        {
//            new("a", 2),
//            new("b", 2)
//        };
//        Assert.That(result, Is.EqualTo(expected));
//    }

//    [Test]
//    public void TopNWords_NGreaterThanDistinct_ReturnsAll()
//    {
//        string text = "one two two three three three";
//        var result = DictionaryTasks.TopNWords(text, 10);
//        var expected = new List<KeyValuePair<string, int>>
//        {
//            new("three", 3),
//            new("two", 2),
//            new("one", 1)
//        };
//        Assert.That(result, Is.EqualTo(expected));
//    }

//    [Test]
//    public void TopNWords_NonLettersAndCase()
//    {
//        string text = "C#,.NET C#-C# .net";
//        var result = DictionaryTasks.TopNWords(text, 3);
//        var expected = new List<KeyValuePair<string, int>>
//        {
//            new("c", 3),
//            new("net", 2)
//        };
//        Assert.That(result, Is.EqualTo(expected));
//    }

//    [Test]
//    public void TopNWords_ZeroOrNegativeN_ReturnsEmpty()
//    {
//        Assert.That(DictionaryTasks.TopNWords("a b", 0), Is.Empty);
//        Assert.That(DictionaryTasks.TopNWords("a b", -5), Is.Empty);
//    }

//    [Test]
//    public void TopNWords_NullOrWhitespace_ReturnsEmpty()
//    {
//        Assert.That(DictionaryTasks.TopNWords(null!, 5), Is.Empty);
//        Assert.That(DictionaryTasks.TopNWords("   ", 5), Is.Empty);
//    }
//}
