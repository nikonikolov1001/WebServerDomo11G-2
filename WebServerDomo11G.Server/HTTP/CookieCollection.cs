using System;
using System.Collections;
using System.Collections.Generic;

namespace WebServerDomo11G.Server.HTTP
{
    public class CookieCollection : IEnumerable<Cookie>
    {
        private readonly Dictionary<string, Cookie> cookies = new(StringComparer.OrdinalIgnoreCase);

        public void Add(string name, string value)
        {
            name = name?.Trim();
            value = value?.Trim();

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Cookie name cannot be null or empty", nameof(name));

            cookies[name] = new Cookie(name, value);
        }

        public IEnumerator<Cookie> GetEnumerator() => cookies.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int Count => cookies.Count;

        public Cookie? Get(string name) => cookies.TryGetValue(name, out var cookie) ? cookie : null;

        public Cookie? this[string name] => Get(name);

        public bool Contains(string name) => cookies.ContainsKey(name);
    }
}
