using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OneLogin.Types;
using System;
using System.Reflection;

namespace OneLogin.Converters
{
	public class AppConverter<T> : JsonConverter where T : AppDetail, new()
	{
		public override bool CanConvert(Type objectType)
		{
			// ToDo: Build modern target framework without GetTypeInfo hack
			return typeof(AppDetail).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
		}

		public override bool CanWrite => false;

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{

			JObject jObject = JObject.Load(reader);

			AppConfiguration configTarget = null;
			if (jObject.ContainsKey("auth_method"))
			{
				var authMethod = (int)jObject["auth_method"];
				switch (authMethod)
				{
					case 2:
						configTarget = new AppSamlConfiguration();
						break;
				}
			}

			var target = new T() { Configuration = configTarget };
			serializer.Populate(jObject.CreateReader(), target);
			return target;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}
