using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace App.Topics.Dictionary.T3_Dictionary;

public static class DictionaryTasks
{
    public static List<KeyValuePair<string, int>> TopNWords(string text, int n)
    {
        if (string.IsNullOrWhiteSpace(text) || n <= 0) { return new List<KeyValuePair<string, int>>(); }
        text = text.ToLowerInvariant();

        var words = Regex.Split(text, @"[^a-z0-9à-ÿ¸]+", RegexOptions.IgnoreCase).Where(w => !string.IsNullOrWhiteSpace(w));

        var freq = new Dictionary<string, int>();
        foreach (var word in words)
        {
            if (freq.ContainsKey(word))
                freq[word]++;
            else
                freq[word] = 1;
        }

        List<KeyValuePair<string, int>> sorted = freq.OrderByDescending(p => p.Value).ThenBy(p => p.Key).Take(n).ToList();

        return sorted;
    }
}
