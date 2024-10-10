using System.Collections.Concurrent;

namespace FrequencySearchEngineAbstractions;

public interface IFrequencySearchEngine
{
    void SearchInContent(string? content, Dictionary<string, int>? frequencyContainer);
}
