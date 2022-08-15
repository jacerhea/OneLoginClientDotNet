using System;

namespace OneLogin.Types
{
	public class AppParameter
	{
		public int Id { get; set; }
		public string UserAttributeMappings { get; set; }
		public string AttributesTransformations { get; set; }
		public string Label { get; set; }
		public bool? SkipIfBlank { get; set; }
		public bool? ProvisionedEntitlements { get; set; }
	}
}
