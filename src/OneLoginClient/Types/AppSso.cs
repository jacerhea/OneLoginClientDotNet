using System;

namespace OneLogin.Types
{
	public class AppSso
	{
		public string MetadataUrl { get; set; }

		public AppSsoCertificate Certificate { get; set; }
	}
}
