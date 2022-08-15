using System;

namespace OneLogin.Types
{
	public enum AppAuthMethod
	{
		Password = 0,
		OpenId = 1,
		SAML = 2,
		API = 3,
		Google = 4,
		FormsBasedApp = 6,
		WSFED = 7,
		OpenIdConnect = 8
	}
}
