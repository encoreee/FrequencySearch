using System.Text;
using BenchmarkDotNet.Attributes;

namespace SearchEngineConsoleWrapper;

[MemoryDiagnoser]
public class ProcessorBenchmarks
{
    [Benchmark]
    public async Task SmallContentAsyncProcessing()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        await FileProcessor.ProcessFileAsync([@"C:\Nornik\SmallContent.txt", @"C:\Nornik\resultSmallContentAsync.txt"], CancellationToken.None);
    }

    [Benchmark]
    public async Task SmallContentSingleThreadProcessing()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        await FileProcessor.ProcessFile([@"C:\Nornik\SmallContent.txt", @"C:\Nornik\resultSmallContentSync.txt"] , CancellationToken.None);
    }

    [Benchmark]
    public async Task BigLenghtContentAsyncProcessing()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        await FileProcessor.ProcessFileAsync([@"C:\Nornik\BigLenghtContent.txt", @"C:\Nornik\resultBigLenghtContentAsync.txt"] , CancellationToken.None);
    }

    [Benchmark]
    public async Task BigLenghtContentSingleThreadProcessing()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        await FileProcessor.ProcessFile([@"C:\Nornik\BigLenghtContent.txt", @"C:\Nornik\resultBigLenghtContentSync.txt"] , CancellationToken.None);
    }

    [Benchmark]
    public async Task ManyRowsContentAsyncProcessing()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        await FileProcessor.ProcessFileAsync([@"C:\Nornik\ManyRowsContent.txt", @"C:\Nornik\resultManyRowsContentAsync.txt"] , CancellationToken.None);
    }

    [Benchmark]
    public async Task ManyRowsContentSingleThreadProcessing()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        await FileProcessor.ProcessFile([@"C:\Nornik\ManyRowsContent.txt", @"C:\Nornik\resultManyRowsContentSync.txt"] , CancellationToken.None);
    }
}
