
namespace FarNetboxPasswordDecryptor;

internal readonly struct CommandLineParserResult(bool verbose, string? filePath)
{
    public bool Verbose { get; } = verbose;
    public string? FilePath { get; } = filePath;

    public static readonly CommandLineParserResult Empty = new(false, null);

    internal void Deconstruct(out bool verbose, out string? filePath)
    {
        verbose = Verbose;
        filePath = FilePath;
    }
}
