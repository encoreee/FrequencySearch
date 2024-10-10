using System.Collections.Concurrent;
using Helpers.Utils;

namespace FileOperations;

public class ContainerFileWriter(StreamWriter streamWriter)
{
    public async Task WriteContainerToFileAsync(ConcurrentDictionary<string, int> frequencyContainer, CancellationToken cancellationToken)
    {
        foreach (var section in frequencyContainer.FrequencyReverse())
        {
            foreach (var word in section.Value)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await streamWriter.WriteLineAsync($"{word.ToLower()},{section.Key}");
            }
        }
    }

    public void WriteContainerToFile(Dictionary<string, int> frequencyContainer, CancellationToken cancellationToken)
    {
        foreach (var section in frequencyContainer.FrequencyReverse())
        {
            foreach (var word in section.Value)
            {
                streamWriter.WriteLineAsync($"{word.ToLower()},{section.Key}");
            }
        }
    }
}
