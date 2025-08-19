using System.Xml.Serialization;

namespace FarNetboxPasswordDecryptor;

internal static class NetboxSessionReader
{
    public static NetboxSavedSession.Session ReadFile(string filePath)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(filePath);

        var serializer = new XmlSerializer(typeof(NetboxSavedSession));
        using var fileStream = File.OpenRead(filePath);

        var netbox =
            (NetboxSavedSession?)serializer.Deserialize(fileStream)
            ?? throw new InvalidOperationException($"Invalid NetBox session file '{filePath}'.");

        var session =
            netbox.Sessions?[0]
            ?? throw new InvalidOperationException($"Netbox session file does not contain any session. File: '{filePath}'.");

        if (string.IsNullOrEmpty(session.Password))
        {
            throw new InvalidOperationException("Netbox session file does not contain saved password. File: '{filePath}'.");
        }

        return session;
    }
}
