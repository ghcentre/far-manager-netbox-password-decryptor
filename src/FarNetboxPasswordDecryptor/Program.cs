namespace FarNetboxPasswordDecryptor;

internal static class Program
{
    private const string _verboseSwitch = "-v";

    static int Main(string[] args)
    {
        try
        {
            (bool verbose, string? filePath) = CommandLineParser.Parse(args);
            if (string.IsNullOrEmpty(filePath))
            {
                Help.Print();
                return ExitCode.HelpRequested;
            }

            var savedSession = NetboxSessionReader.ReadFile(filePath);

            var session = new Session(savedSession);

            string password = NetboxSessionDecryptor.DecryptPassword(session);

            PasswordPrinter.Print(session, password, verbose);

            return ExitCode.Success;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine(exception.Message);
            return ExitCode.Exception;
        }
    }
}
