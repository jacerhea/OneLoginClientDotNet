using System;

namespace OneLogin.Types
{
	public class AppSamlConfiguration : AppConfiguration
	{
		public string SignatureAlgorithm { get; set; }
		public int? CertificateId { get; set; }
	}
}
