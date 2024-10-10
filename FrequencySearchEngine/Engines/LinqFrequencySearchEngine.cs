using System.Collections.Concurrent;
using FrequencySearchEngineAbstractions;

namespace FrequencySearchEngine.Engines;

public class LinqFrequencySearchEngine : IFrequencySearchAsyncEngine
{
    public Task SearchInContent(string? content, ConcurrentDictionary<string, int>? frequencyContainer)
    {
        if (content is null)
            return Task.CompletedTask;

        ArgumentNullException.ThrowIfNull(frequencyContainer);

        var localDictionary = content.Split()
            .Where(x => x != string.Empty)
            .GroupBy(x => x, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(x => x.Key, x => x.Count(), StringComparer.OrdinalIgnoreCase);

        foreach (var pair in localDictionary)
        {
            if (frequencyContainer.TryGetValue(pair.Key, out var currentCount))
            {
                frequencyContainer[pair.Key] += pair.Value;
            }
            else
            {
                frequencyContainer[pair.Key] = pair.Value;
            }
        }

        return Task.CompletedTask;
    }
}
