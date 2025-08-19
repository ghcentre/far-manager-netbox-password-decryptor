namespace FarNetboxPasswordDecryptor;

internal readonly struct ExitCode(int code)
{
    private readonly int _code = code;

    public static implicit operator int(ExitCode value) => value._code;
    public static implicit operator ExitCode(int code) => new(code);

    public static readonly ExitCode Success = 0;
    public static readonly ExitCode HelpRequested = 4;
    public static readonly ExitCode Exception = 64;
}
