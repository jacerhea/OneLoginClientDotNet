using Newtonsoft.Json.Serialization;
using System.Text.RegularExpressions;

namespace OneLogin
{
    internal class SnakeCaseContractResolver : DefaultContractResolver
    {
        protected internal Regex converter = new Regex(@"((?<=[a-z])(?<b>[A-Z0-9])|(?<=[^_])(?<b>[A-Z][a-z]))");
        protected override string ResolvePropertyName(string propertyName)
        {
            return converter.Replace(propertyName, "_${b}").ToLower();
        }
    }
}
