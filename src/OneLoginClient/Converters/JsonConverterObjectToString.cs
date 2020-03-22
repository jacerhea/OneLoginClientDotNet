using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OneLogin.Converters
{
    public class JsonConverterObjectToString : JsonConverter
    {
        /// <summary>
        /// Can convert object to json object
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(JTokenType));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Object)
            {
                return token.ToString();
            }
            return null;
        }

        /// <summary>
        /// Write json to JsonWriter
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //serializer.Serialize(writer, value);

            //serialize as actual JSON and not string data
            var token = JToken.Parse(value.ToString());
            writer.WriteToken(token.CreateReader());

        }
    }
}
