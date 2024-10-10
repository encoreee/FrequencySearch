using System.Collections.Concurrent;
using BenchmarkDotNet.Attributes;
using FrequencySearchEngine.Engines;

namespace FrequencySearchEngine;

[MemoryDiagnoser]
public class EngineBenchmarks
{
    private readonly string _testContent =
        "This handy tool helps you create dummy text for all your layout needs We are gradually adding new functionality and we welcome your suggestions and feedback";

    [Benchmark]
    public async Task LinqSearch()
    {
        var engine = new LinqFrequencySearchEngine();
        await engine.SearchInContent(_testContent, new ConcurrentDictionary<string, int>());
    }

    [Benchmark]
    public async Task ArraySplitSearch()
    {
        var engine = new ArrayFrequencySearchEngine();
        await engine.SearchInContent(_testContent, new ConcurrentDictionary<string, int>());
    }

    [Benchmark]
    public async Task RegexSearch()
    {
        var engine = new RegexFrequencySearchEngine();
        await engine.SearchInContent(_testContent, new ConcurrentDictionary<string, int>());
    }
}
