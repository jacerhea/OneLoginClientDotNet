using Newtonsoft.Json;
using OneLogin.Converters;
using System;
using System.Collections.Generic;

namespace OneLogin.Types
{
	[JsonConverter(typeof(AppConverter<AppDetail>))]
	public class AppDetail : AppSummary
	{
		[JsonIgnore]
		public AppSso SSO { get; protected set; }
		[JsonProperty(nameof(SSO))]
		private AppSso SSOSetter { set => SSO = value; }

		public AppConfiguration Configuration { get; set; }
		public Dictionary<string, AppParameter> Parameters { get; set; }
	}
}
