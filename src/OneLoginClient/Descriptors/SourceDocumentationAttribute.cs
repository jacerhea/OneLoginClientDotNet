using System;

namespace OneLogin.Descriptors
{
    public class SourceDocumentationAttribute : Attribute
    {
        public Uri Url { get; }

        public SourceDocumentationAttribute(string url)
        {
            Url = new Uri(url, UriKind.Absolute);
        }
    }
}
