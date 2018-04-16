using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace OneLogin.IntegrationTests
{
    public class OneLoginTokenTests
    {
        [Fact]
        public void Empty_ClientId_Throws_An_Exception_In_OneLoginClient()
        {
            Action createClientWithEmptyClientId = () => new OneLoginClient(string.Empty, "Client Secret");
            createClientWithEmptyClientId.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Empty_ClientSecret_Throws_An_Exception_In_OneLoginClient()
        {
            Action createClientWithEmptyClientSecret = () => new OneLoginClient("Client id", "    ");
            createClientWithEmptyClientSecret.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task GetTokenTest()
        {
            var token = await _oneLoginClient.GenerateTokens();
        }

        [Fact]
        public async Task GetUsersTest()
        {
            var usersResponse = await _oneLoginClient.GetUsers();
        }

        [Fact]
        public async Task GetUserByIdTest()
        {
            var usersResponse = await _oneLoginClient.GetAppsForUser(32715399);
        }
    }
}
