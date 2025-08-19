namespace FarNetboxPasswordDecryptor;

internal static class PasswordPrinter
{
    public static void Print(Session session, string password, bool verbose)
    {
        ArgumentNullException.ThrowIfNull(session);

        if (!verbose)
        {
            Console.Write(password);
            return;
        }

        Console.WriteLine($"""

            Host Name: {session.HostName}
            User Name: {session.UserName}
            Password:  {password}
            """);
    }
}
