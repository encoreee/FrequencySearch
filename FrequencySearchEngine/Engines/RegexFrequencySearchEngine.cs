using System.Collections.Concurrent;
using System.Text.RegularExpressions;
using FrequencySearchEngineAbstractions;

namespace FrequencySearchEngine.Engines;

public class RegexFrequencySearchEngine : IFrequencySearchAsyncEngine, IFrequencySearchEngine
{

    public Task SearchInContent(string? content, ConcurrentDictionary<string, int>? frequencyContainer)
    {
        if (content is null)
            return Task.CompletedTask;

        ArgumentNullException.ThrowIfNull(frequencyContainer);

        var pattern = new Regex(@"\w+");

        foreach (Match match in pattern.Matches(content))
        {
            frequencyContainer.TryGetValue(match.Value, out var currentCount);
            frequencyContainer[match.Value] = ++currentCount;
        }

        return Task.CompletedTask;
    }

    public void SearchInContent(string? content, Dictionary<string, int>? frequencyContainer)
    {
        if (content is null)
            return;

        ArgumentNullException.ThrowIfNull(frequencyContainer);

        var pattern = new Regex(@"\w+");

        foreach (Match match in pattern.Matches(content))
        {
            frequencyContainer.TryGetValue(match.Value, out var currentCount);
            frequencyContainer[match.Value] = ++currentCount;
        }
    }
}
