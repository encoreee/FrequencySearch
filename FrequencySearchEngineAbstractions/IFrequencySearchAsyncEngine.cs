using System.Collections.Concurrent;

namespace FrequencySearchEngineAbstractions;

public interface IFrequencySearchAsyncEngine
{
    Task SearchInContent(string? content, ConcurrentDictionary<string, int>? frequencyContainer);
}
