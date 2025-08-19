using System.Collections.Immutable;
using System.Globalization;

namespace FarNetboxPasswordDecryptor;

internal class Session
{
    const uint _mask = 0x5c;

    public Session(NetboxSavedSession.Session savedSession)
    {
        ArgumentNullException.ThrowIfNull(savedSession);
        (HostName, UserName, PasswordBytes) = Parse(savedSession);
    }

    public string HostName { get; }

    public string UserName { get; }

    public ReadOnlyMemory<byte> PasswordBytes { get; }

    private static (string HostName, string UserName, ReadOnlyMemory<byte> PasswordBytes) Parse(NetboxSavedSession.Session session)
    {
        if (string.IsNullOrEmpty(session.UserName))
        {
            throw new ArgumentException("No User Name found in saved NetBox session.");
        }

        if (string.IsNullOrEmpty(session.HostName))
        {
            throw new ArgumentException("No Host Name found in saved NetBox session.");
        }

        if (string.IsNullOrEmpty(session.Password))
        {
            throw new ArgumentException("Np Password found in saved NetBox session.");
        }
        if (session.Password.Length % 2 != 0)
        {
            throw new ArgumentException("Password string must have an even length.");
        }

        string hostName = UnescapeWithBom(session.HostName);
        string userName = UnescapeWithBom(session.UserName);
        byte[] password = DecodeHexAndUnscramble(session.Password);

        return (hostName, userName, password);
    }

    private static string UnescapeWithBom(string encodedString)
    {
        byte[] bytes = UnescapeToBytes(encodedString);

        using var ms = new MemoryStream(bytes);
        using var reader = new StreamReader(ms, true);

        string result = reader.ReadToEnd();
        return result;
    }

    private static byte[] UnescapeToBytes(string escaped)
    {
        var list = new List<byte>(escaped.Length);

        for (int i = 0; i < escaped.Length; i++)
        {
            char c = escaped[i];
            if (c != '%')
            {
                list.Add((byte)c);
                continue;
            }

            var hex = escaped.AsSpan(i + 1, 2);
            if (!byte.TryParse(hex, NumberStyles.HexNumber, null, out byte value))
            {
                throw new FormatException($"Invalid hex value: {hex}");
            }
            list.Add(value);
            i += 2;
        }

        return [.. list];
    }

    private static byte[] DecodeHexAndUnscramble(string passwordStringHex)
    {
        int length = passwordStringHex.Length / 2;
        byte[] bytes = new byte[length];

        for (int i = 0; i < length; i++)
        {
            var hex = passwordStringHex.AsSpan(i * 2, 2);
            if (!byte.TryParse(hex, NumberStyles.HexNumber, null, out byte value))
            {
                throw new FormatException($"Invalid hex value: {hex}");
            }

            bytes[i] = (byte)(value ^ _mask);
        }

        return bytes;
    }
}
