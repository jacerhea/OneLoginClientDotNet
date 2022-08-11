using System.IO;
using Newtonsoft.Json;

namespace OneLogin
{
    /// <summary>
    /// Serializes and deserializes objects into and from the JSON format.
    /// </summary>
    public class Serializer
    {
        private static readonly JsonSerializer _serializer = new JsonSerializer { NullValueHandling = NullValueHandling.Ignore, ContractResolver = new SnakeCaseContractResolver() };

        /// <summary>
        /// Serializes the specified object to a JSON string.
        /// </summary>
        /// <param name="value">The object to serialize.</param>
        /// <returns>A JSON string representation of the object.</returns>
        public string Serialize(object value)
        {
            using (var sw = new StringWriter())
            {
                _serializer.Serialize(sw, value);
                return sw.ToString();
            }
        }

        /// <summary>
        /// Deserializes the JSON structure contained by the specified <see cref="Stream"/>
        /// into an instance of the specified type.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> containing the object.</param>
        /// <typeparam name="T">The type of the object to deserialize.</typeparam>
        /// <returns>The instance of <typeparamref name="T"/> being deserialized.</returns>
        public T DeserializeJsonFromStream<T>(Stream stream)
        {
            using (var streamReader = new StreamReader(stream))
            {
                return DeserializeJsonFromStreamReader<T>(streamReader);
            }
        }

        /// <summary>
        /// Deserializes the JSON structure contained by the specified <see cref="StreamReader"/>
        /// into an instance of the specified type.
        /// </summary>
        /// <param name="streamReader">The <see cref="StreamReader"/> containing the object.</param>
        /// <typeparam name="T">The type of the object to deserialize.</typeparam>
        /// <returns>The instance of <typeparamref name="T"/> being deserialized.</returns>
        public T DeserializeJsonFromStreamReader<T>(StreamReader streamReader)
        {
            using (var jsonTextReader = new JsonTextReader(streamReader))
            {
                return _serializer.Deserialize<T>(jsonTextReader);
            }
        }
    }
}
