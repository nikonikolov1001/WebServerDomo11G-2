using System;
using System.Collections.Generic;

namespace WebServerDomo11G.Server.HTTP
{
    public class Session
    {
        public const string SessionCookieName = "SID";
        public const string SessionCurrentDateKey = "CurrentDate";

        public Session(string id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }

        public string Id { get; }

        private readonly Dictionary<string, string> data;

        public string this[string key]
        {
            get => data.TryGetValue(key, out var value) ? value : null;
            set => data[key] = value;
        }

        public bool ContainsKey(string key) => data.ContainsKey(key);
    }
}
