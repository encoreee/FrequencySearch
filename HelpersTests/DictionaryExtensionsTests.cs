using System.Collections.Concurrent;
using Helpers.Utils;

namespace HelpersTests;

[TestClass]
public class DictionaryExtensionsTests
{
    [TestMethod]
    public void ConcurentFrequencyReversePositiveTest()
    {
    var dictionary = new ConcurrentDictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
        dictionary.TryAdd("test1", 1);
        dictionary.TryAdd("test12", 2);
        dictionary.TryAdd("test13", 3);
        dictionary.TryAdd("test2", 1);
        dictionary.TryAdd("test22", 2);
        dictionary.TryAdd("test23", 3);
        dictionary.TryAdd("test3", 1);
        dictionary.TryAdd("test32", 2);
        dictionary.TryAdd("test33", 3);

        var reversedDictionary = dictionary.FrequencyReverse();

        Assert.AreEqual(3, reversedDictionary.Count);
        var topCount = 3;
        foreach (var pair in reversedDictionary)
        {
            Assert.AreEqual(topCount--, pair.Key);
        }

        CollectionAssert.AreEqual(reversedDictionary[3], new SortedSet<string>() {"test13", "test23", "test33"});
        CollectionAssert.AreEqual(reversedDictionary[2], new SortedSet<string>() {"test12", "test22", "test32"});
        CollectionAssert.AreEqual(reversedDictionary[1], new SortedSet<string>() {"test1", "test2", "test3"});
    }

    [TestMethod]
    public void FrequencyReversePositiveTest()
    {
        var dictionary = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
        dictionary.TryAdd("test1", 1);
        dictionary.TryAdd("test12", 2);
        dictionary.TryAdd("test13", 3);
        dictionary.TryAdd("test2", 1);
        dictionary.TryAdd("test22", 2);
        dictionary.TryAdd("test23", 3);
        dictionary.TryAdd("test3", 1);
        dictionary.TryAdd("test32", 2);
        dictionary.TryAdd("test33", 3);

        var reversedDictionary = dictionary.FrequencyReverse();

        Assert.AreEqual(3, reversedDictionary.Count);
        var topCount = 3;
        foreach (var pair in reversedDictionary)
        {
            Assert.AreEqual(topCount--, pair.Key);
        }

        CollectionAssert.AreEqual(reversedDictionary[3], new SortedSet<string>() {"test13", "test23", "test33"});
        CollectionAssert.AreEqual(reversedDictionary[2], new SortedSet<string>() {"test12", "test22", "test32"});
        CollectionAssert.AreEqual(reversedDictionary[1], new SortedSet<string>() {"test1", "test2", "test3"});
    }
}
