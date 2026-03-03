csharp WebServerDomo11G.Server\HTTP\Cookie.cs
using System;

namespace WebServerDomo11G.Server.HTTP
{
    public class Cookie
    {
        public Cookie(string name, string value)
        {
            Name = name?.Trim() ?? throw new ArgumentException("Cookie name cannot be null or empty", nameof(name));
            Value = value?.Trim() ?? string.Empty;
        }

        public string Name { get; }
        public string Value { get; }

        public override string ToString() => $"{Name}={Value}";
    }
}