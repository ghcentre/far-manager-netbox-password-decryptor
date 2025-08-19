namespace FarNetboxPasswordDecryptor;

internal static class CommandLineParser
{
    private const string _verboseSwitch = "-v";

    public static CommandLineParserResult Parse(string[] args)
    {
        ArgumentNullException.ThrowIfNull(args);

        if (args.Length == 0 || args.Length > 2)
        {
            return CommandLineParserResult.Empty;
        }

        if (args.Length == 1)
        {
            return new CommandLineParserResult(false, args[0]);
        }

        if (args[0] == _verboseSwitch)
        {
            return new CommandLineParserResult(true, args[1]);
        }

        if (args[1] == _verboseSwitch)
        {
            return new CommandLineParserResult(true, args[0]);
        }

        return CommandLineParserResult.Empty;
    }
}
