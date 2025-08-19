namespace FarNetboxPasswordDecryptor;

internal static class Help
{
    private const string _helpMessage = """

        Decrypts (un-scrambles) stored passwords from FAR Manager NetBox session (.netbox) files.

        Usage:
            FarNetboxPasswordDecryptor [-v] session-file

        Switches:
            -v             Be verbose.
                           Output host name, user name, and password.
                           Without -v, output password only,

        Parameters:
            session-file   NetBox exported session (.netbox) file.
                           To export session file, just copy highlited session from NetBox panel to another file panel.
        """;

    public static void Print()
    {
        var lines = _helpMessage.Split('\n').Select(x => x.Replace("\r", string.Empty));
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
    }
}
