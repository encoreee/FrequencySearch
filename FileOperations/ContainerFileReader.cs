using FrequencySearchEngineAbstractions;

namespace FileOperations;

public class ContainerFileReader(IFrequencySearchEngine frequencySearchEngine, StreamReader streamReader)
{
    public async Task ReadToContainer(Dictionary<string, int> frequencyContainer, CancellationToken cancellationToken)
    {
        while (await streamReader.ReadLineAsync(cancellationToken) is { } line)
        {
            frequencySearchEngine.SearchInContent(line, frequencyContainer);
        }
    }
}
