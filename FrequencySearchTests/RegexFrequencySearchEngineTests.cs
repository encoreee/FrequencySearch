using System.Collections.Concurrent;
using FrequencySearchEngine.Engines;
using FrequencySearchEngineAbstractions;

namespace FrequencySearchEngineTest;

[TestClass]
public class RegexFrequencySearchEngineTests
{
    private readonly IFrequencySearchAsyncEngine _searchEngine = new RegexFrequencySearchEngine();

    [TestMethod]
    [DataRow("Наше нАше наШЕ дело не так однозначно")]
    [DataRow("Наше, нАше, наШЕ, дело не так однозначно")]
    [DataRow("Наше нАше наШЕ дело не так однозначно!!!!")]
    [DataRow("Наше$$ нАше@ наШЕ& дело% не так однозначно!!!!")]
    public void SearchInContentPositiveTest(string content)
    {
        var dictionary = new ConcurrentDictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);

        Assert.IsTrue(dictionary.IsEmpty);
        _searchEngine.SearchInContent(content, dictionary);

        Assert.IsTrue(dictionary.Count == 5);
        Assert.AreEqual(3,dictionary["наше"]);
        Assert.AreEqual(1,dictionary["дело"]);
        Assert.AreEqual(1,dictionary["не"]);
        Assert.AreEqual(1,dictionary["так"]);
        Assert.AreEqual(1,dictionary["однозначно"]);

        dictionary.TryGetValue("программирование", out var value);
    }

    [TestMethod]
    public void SearchInNullableContentTest()
    {
        var dictionary = new ConcurrentDictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);

        Assert.IsTrue(dictionary.IsEmpty);
        _searchEngine.SearchInContent(null, dictionary);

        Assert.IsTrue(dictionary.IsEmpty);
    }
}
