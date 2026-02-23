namespace WebServerDomo11G.Server.HTTP
{
    public static class Header
    {
        public const string ContentLength = "Content-Length";
        public const string ContentType = "Content-Type";
        public const string Location = "Location";
        public const string Server = "Server";
        public const string Date = "Date";
    }

    public class HeaderItem
    {
        public HeaderItem(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public string Value { get; }
    }
}