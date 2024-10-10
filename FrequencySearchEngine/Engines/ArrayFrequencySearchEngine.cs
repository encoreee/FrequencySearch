using System.Collections.Concurrent;
using System.Text.RegularExpressions;
using FrequencySearchEngineAbstractions;

namespace FrequencySearchEngine.Engines;

public class ArrayFrequencySearchEngine : IFrequencySearchAsyncEngine
{
    public Task SearchInContent(string? content, ConcurrentDictionary<string, int>? frequencyContainer)
    {
        if (content is null)
            return Task.CompletedTask;

        ArgumentNullException.ThrowIfNull(frequencyContainer);

        foreach (var word in content.Split(" ", StringSplitOptions.RemoveEmptyEntries))
        {
            frequencyContainer.TryGetValue(word, out var currentCount);
            frequencyContainer[word] = ++currentCount;
        }

        return Task.CompletedTask;
    }


}
