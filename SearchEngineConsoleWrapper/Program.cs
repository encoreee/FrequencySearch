using System.Text;
using BenchmarkDotNet.Running;
using FrequencySearchEngine;
using Helpers.Utils;
using SearchEngineConsoleWrapper;

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

try
{
    switch (args.Length)
    {
        case > 2:
            throw new ArgumentException("Too many arguments");
        case < 2:
            throw new ArgumentException("Too few arguments");
    }

    if (!args[0].ValidateFilePath())
    {
        throw new ArgumentException("Input file path is not valid");
    }

    if (!args[1].ValidateFilePath())
    {
        throw new ArgumentException("Output file path is not valid");
    }
}

catch (Exception e)
{
    Console.WriteLine($"Error occured while parsing program arguments\n{e.Message}\nArgs should be: <inputFilePath> <outputFilePath>");
    return 1;
}

var cts = new CancellationTokenSource();

Console.CancelKeyPress += (s, e) =>
{
    Console.WriteLine("Canceling...");
    cts.Cancel();
    e.Cancel = true;
};

var status = await FileProcessor.ProcessFileAsync(args, cts.Token);

return status;

//Диагностика
//var summary = BenchmarkRunner.Run<ProcessorBenchmarks>();
//var summary = BenchmarkRunner.Run<EngineBenchmarks>();
