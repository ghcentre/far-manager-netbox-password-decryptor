using System.Xml.Serialization;

namespace FarNetboxPasswordDecryptor;

[XmlRoot(ElementName = "NetBox")]
public sealed class NetboxSavedSession
{
    public Session[]? Sessions { get; set; }

    public class Session
    {
        public string? HostName { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }
    }
}
