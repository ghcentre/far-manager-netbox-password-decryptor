using System.Text;

namespace FarNetboxPasswordDecryptor;

internal static class NetboxSessionDecryptor
{
    public static string DecryptPassword(Session session)
    {
        ArgumentNullException.ThrowIfNull(session);

        // byte array format:
        // index    length description
        // -----    ------ -----------
        // 00       1      signature (always 0xff) 
        // 01       1      signature (always 0x00)
        // 02       1      length of Encoding.UTF8.GetBytes(user + host + password) (LN)
        // 03       1      reserved area length in bytes (RS)
        // 04       RS     reserved area
        // 04+RS    LN     Encoding.UTF8.GetBytes(user + host + password)
        // 04+RS+LN any    reserved aea

        var bytes = session.PasswordBytes.Span;
        WarnIfSignatureMismatch(bytes);

        int combinedLength = bytes[2];
        int reservedLength = bytes[3];
        int start = 4 + reservedLength;

        var combinedBytes = bytes.Slice(start, combinedLength);
        string combined = Encoding.UTF8.GetString(combinedBytes);

        int passwordStart = session.UserName.Length + session.HostName.Length;
        
        string password = combined[passwordStart..];
        return password;
    }

    private static void WarnIfSignatureMismatch(ReadOnlySpan<byte> bytes)
    {
        if (bytes[0] != 0xff || bytes[1] != 0x00)
        {
            Console.Error.WriteLine("WARNING: invalid saved password signature. Result may be unaccurate.");
        }
    }
}
