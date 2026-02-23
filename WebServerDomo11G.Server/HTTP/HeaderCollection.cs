using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WebServerDomo11G.Server.HTTP
{
    public class HeaderCollection : IEnumerable<HeaderItem>
    {
        private readonly List<HeaderItem> headers = new List<HeaderItem>();

        public void Add(string name, string value)
        {
            name = name?.Trim();
            value = value?.Trim();

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Header name cannot be null or empty", nameof(name));

            var existing = headers.FirstOrDefault(h => string.Equals(h.Name, name, StringComparison.OrdinalIgnoreCase));
            if (existing != null)
            {
                headers.Remove(existing);
            }
            headers.Add(new HeaderItem(name, value));
        }

        public IEnumerator<HeaderItem> GetEnumerator() => headers.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int Count => headers.Count;
    }
}