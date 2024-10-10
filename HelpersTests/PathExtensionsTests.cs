using Helpers.Utils;

namespace HelpersTests;

[TestClass]
public class PathExtensionsTests
{
    [TestMethod]
    [DataRow(@"C:\filename.txt")]
    [DataRow(@"C:\root\filename.txt")]
    [DataRow("filename.txt")]
    [DataRow("/etc/myapp/filename.txt")]
    public void PathValidatePositiveTest(string path)
    {
        Assert.IsTrue(path.ValidateFilePath(validateExtension: true));
    }

    [TestMethod]
    [DataRow(@"C:\")]
    public void PathValidateNegativeExtensionTest(string path)
    {
        Assert.IsFalse(path.ValidateFilePath());
    }

    [TestMethod]
    [DataRow(@"C:\filename")]
    public void PathValidatePositiveFileNameTest(string path)
    {
        Assert.IsTrue(path.ValidateFilePath());
    }

    [TestMethod]
    [DataRow(@"C:\|")]
    public void PathValidateNegativeSymbolsTest(string path)
    {
        Assert.IsFalse(path.ValidateFilePath());
    }
}
