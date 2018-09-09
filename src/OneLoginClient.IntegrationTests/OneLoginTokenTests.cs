using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace OneLogin.IntegrationTests
{
    public class OneLoginTokenTests
    {
        private static readonly OneLoginClient _oneLoginClient = new OneLoginClient("1e6c17c7ce20cc7a1faa070819555437fcdfcea1a7aa2ba355d49120fb979072", "a3ef28579190690be34df472064a145a640a1dd2cbf9a4c485cc40731dcd9ab6");

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
        public void Invalid_Region_Throws_An_ArgumentException_In_OneLoginClient_Constructor()
        {
            Action createClientWithEmptyClientSecret = () => new OneLoginClient("Client id", "Client Secret", region: "hello");
            createClientWithEmptyClientSecret.Should().Throw<ArgumentException>();
        }

        [Fact]
        public async Task GetTokenTest()
        {
            var token = (await _oneLoginClient.GenerateTokens())
                .EnsureSuccess();

            token.Data.Should().ContainSingle();
        }

       

        [Fact]
        public async Task GetCustomAttributes()
        {
            var rolesForUser = (await _oneLoginClient.GetCustomAttributes())
                .EnsureSuccess();
        }

        [Fact]
        public async Task GetAvailableAuthenticationFactorsTest()
        {
            var rolesForUser = (await _oneLoginClient.GetAvailableAuthenticationFactors(32715399))
                .EnsureSuccess();
        }

        [Fact]
        public async Task GetEnrolledAuthenticationFactors()
        {
            var rolesForUser = (await _oneLoginClient.GetEnrolledAuthenticationFactors(32715399))
                .EnsureSuccess();
        }

        [Fact]
        public async Task GetGroupsTest()
        {
            var groups = (await _oneLoginClient.GetGroups())
                .EnsureSuccess();
        }

        [Fact]
        public async Task GetGroupTest()
        {
            var groups = (await _oneLoginClient.GetGroup(434968))
                .EnsureSuccess();
        }
    }
}
