using System.Collections.Concurrent;
using FileOperations;
using FrequencySearchEngineAbstractions;
using Moq;

namespace FrequencySearchEngineTest;

[TestClass]
public class ContainerWriterTests
{
    private ConcurrentDictionary<string, int>? _dictionary;

    [TestInitialize]
    public void TestInitialize()
    {
        _dictionary = new ConcurrentDictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
        _dictionary.TryAdd("test1", 1);
        _dictionary.TryAdd("test2", 2);
        _dictionary.TryAdd("test3", 3);
    }

    [TestMethod]
    public async Task WriteContainerToFileAsync()
    {
        Assert.IsNotNull(_dictionary);

        var streamWriter = new Mock<StreamWriter>(Path.GetRandomFileName());
        var containerWriter = new ContainerFileWriter(streamWriter.Object);

        await containerWriter.WriteContainerToFileAsync(_dictionary, CancellationToken.None);

        streamWriter.Verify(x => x.WriteLineAsync(It.IsAny<string>()), Times.Exactly(_dictionary.Count));
        streamWriter.Verify(x => x.WriteLineAsync("test3,3"), Times.Once);
        streamWriter.Verify(x => x.WriteLineAsync("test2,2"), Times.Once);
        streamWriter.Verify(x => x.WriteLineAsync("test1,1"), Times.Once);
    }

    [TestMethod]
    public void WriteContainerToFileSync()
    {
        var dictionary = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
        dictionary.TryAdd("test1", 1);
        dictionary.TryAdd("test2", 2);
        dictionary.TryAdd("test3", 3);

        var streamWriter = new Mock<StreamWriter>(Path.GetRandomFileName());
        var containerWriter = new ContainerFileWriter(streamWriter.Object);

        containerWriter.WriteContainerToFile(dictionary , CancellationToken.None);

        streamWriter.Verify(x => x.WriteLineAsync(It.IsAny<string>()), Times.Exactly(dictionary.Count));
        streamWriter.Verify(x => x.WriteLineAsync("test3,3"), Times.Once);
        streamWriter.Verify(x => x.WriteLineAsync("test2,2"), Times.Once);
        streamWriter.Verify(x => x.WriteLineAsync("test1,1"), Times.Once);
    }
}
