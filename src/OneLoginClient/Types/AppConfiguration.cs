using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace OneLogin.Types
{
	public class AppConfiguration
	{
		/// <summary>
		/// Additional configuration based on the connector requirements
		/// </summary>
		/// <remarks>Any property added to this dictionary will be passed in the same case that is provided</remarks>
		[JsonExtensionData]
		public Dictionary<string, object> CustomProperties { get; set; }
	}

}
