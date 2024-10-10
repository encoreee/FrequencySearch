using System.Collections.Concurrent;
using System.Text;
using FileOperations;
using FrequencySearchEngine.Engines;

namespace SearchEngineConsoleWrapper;

public static class FileProcessor
{
    public static async Task<int> ProcessFileAsync(string[] args, CancellationToken cancellationToken)
    {
        var frequencyContainer = new ConcurrentDictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);

        try
        {
            using var sr = new StreamReader(args[0], Encoding.GetEncoding("windows-1251"));
            var fileReader = new AsyncContainerFileReader(new ArrayFrequencySearchEngine(), sr);
            await fileReader.ReadToContainer(frequencyContainer, cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error occured while file reading file:\n{e.Message}");
            return 1;
        }

        try
        {
            await using var sw = new StreamWriter(args[1], true, Encoding.GetEncoding("windows-1251"));
            var fileWriter = new ContainerFileWriter(sw);
            await fileWriter.WriteContainerToFileAsync(frequencyContainer, cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error occured while file writing file:\n{e.Message}");
            return 1;
        }

        return 0;
    }

    public static async Task<int> ProcessFile(string[] args, CancellationToken cancellationToken)
    {
        var frequencyContainer = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);

        try
        {
            using var sr = new StreamReader(args[0], Encoding.GetEncoding("windows-1251"));
            var fileReader = new ContainerFileReader(new RegexFrequencySearchEngine(), sr);
            await fileReader.ReadToContainer(frequencyContainer, cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error occured while file reading file:\n{e.Message}");
            return 1;
        }

        try
        {
            await using var sw = new StreamWriter(args[1], true, Encoding.GetEncoding("windows-1251"));
            var fileWriter = new ContainerFileWriter(sw);
            fileWriter.WriteContainerToFile(frequencyContainer, cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error occured while file writing file:\n{e.Message}");
            return 1;
        }

        return 0;
    }
}
