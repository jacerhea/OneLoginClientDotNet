using System;
using FluentAssertions;
using Xunit;

namespace OneLogin.IntegrationTests
{
    public class OneLoginTokenTests
    {
        [Fact]
        public void Empty_ClientId_Throws_An_Exception_In_OneLoginClient()
        {
            Action createClientWithEmptyClientId = () => new Client(String.Empty, "Client Secret");
            createClientWithEmptyClientId.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Empty_ClientSecret_Throws_An_Exception_In_OneLoginClient()
        {
            Action createClientWithEmptyClientSecret = () => new Client("Client id", "    ");
            createClientWithEmptyClientSecret.Should().Throw<ArgumentNullException>();
        }
    }
}
