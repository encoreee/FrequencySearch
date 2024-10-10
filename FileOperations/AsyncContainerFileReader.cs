using System.Collections.Concurrent;
using FrequencySearchEngineAbstractions;

namespace FileOperations;

public class AsyncContainerFileReader(IFrequencySearchAsyncEngine frequencySearchEngine, StreamReader streamReader)
{
    public async Task ReadToContainer(ConcurrentDictionary<string, int> frequencyContainer, CancellationToken cancellationToken)
    {
        var tasks = new List<Task>();
        while (await streamReader.ReadLineAsync(cancellationToken) is { } line)
        {
            var task = frequencySearchEngine.SearchInContent(line, frequencyContainer);
            tasks.Add(task);
        }

        await Task.WhenAll(tasks);
    }
}
