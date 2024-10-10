using System.Collections.Concurrent;
using System.Text;
using FileOperations;
using FrequencySearchEngine.Engines;
using Moq;

namespace FrequencySearchEngineTest;

[TestClass]
public class ContainerReaderTests
{
    [TestInitialize]
    public void TestInitialize()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }

    [TestMethod]
    public async Task WriteContainerToFileAsync()
    {
        var dictionary = new ConcurrentDictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);

        var mockFileManager = new Mock<IFileManager>();
        var fakeFileBytes = Encoding.GetEncoding(1251).GetBytes("code Code cOde coDe codE CODE");

        var fakeMemoryStream = new MemoryStream(fakeFileBytes);

        mockFileManager.Setup(fileManager => fileManager.StreamReader(It.IsAny<string>()))
            .Returns(() => new StreamReader(fakeMemoryStream));

        var reader = new AsyncContainerFileReader(new RegexFrequencySearchEngine(), mockFileManager.Object.StreamReader(Path.GetRandomFileName()));

        await reader.ReadToContainer(dictionary, CancellationToken.None);

        Assert.AreEqual(1, dictionary.Count);
        Assert.AreEqual(6, dictionary["code"]);
    }

    [TestMethod]
    public async Task WriteContainerToFileSync()
    {
        var dictionary = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);

        var mockFileManager = new Mock<IFileManager>();
        var fakeFileBytes = Encoding.GetEncoding(1251).GetBytes("code Code cOde coDe codE CODE");

        var fakeMemoryStream = new MemoryStream(fakeFileBytes);

        mockFileManager.Setup(fileManager => fileManager.StreamReader(It.IsAny<string>()))
            .Returns(() => new StreamReader(fakeMemoryStream));

        var reader = new ContainerFileReader(new RegexFrequencySearchEngine(), mockFileManager.Object.StreamReader(Path.GetRandomFileName()));

        await reader.ReadToContainer(dictionary, CancellationToken.None);

        Assert.AreEqual(1, dictionary.Count);
        Assert.AreEqual(6, dictionary["code"]);
    }
}

public interface IFileManager
{
    StreamReader StreamReader(string path);
}
