using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace OneLogin.IntegrationTests
{
    public class OneLoginTokenTests
    {
        private static readonly OneLoginClient _oneLoginClient = new OneLoginClient("fill in your client id", "fill in your client secret")

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
            var token = (await OneLoginClient.GenerateTokens())
                .EnsureSuccess();

            token.Data.Should().ContainSingle();
        }

        [Fact]
        public async Task GetUsersTest()
        {
            var usersResponse = (await OneLoginClient.GetUsers())
                .EnsureSuccess();

            usersResponse.Data.Should().HaveCountGreaterOrEqualTo(1);
        }

        [Fact]
        public async Task GetUserByEmail()
        {
            var usersResponse = (await OneLoginClient.GetUsers(email:"jrhea@performancetrust.com"))
                .EnsureSuccess();
            usersResponse.Data.Should().HaveCount(1);
        }

        [Fact]
        public async Task GetUserByIdTest()
        {
            var usersResponse = (await OneLoginClient.GetUserById(32715399))
                .EnsureSuccess();

            usersResponse.Data.Should().HaveCount(1);
        }

        [Fact]
        public async Task GetAppsForUserTest()
        {
            var getAppsForUserResponse = (await OneLoginClient.GetAppsForUser(32715399))
                .EnsureSuccess();
        }

        [Fact]
        public async Task GetGetRolesForUserTest()
        {
            var rolesForUser = (await OneLoginClient.GetRolesForUser(32715399))
                .EnsureSuccess();
        }

        [Fact]
        public async Task GetCustomAttributes()
        {
            var rolesForUser = (await OneLoginClient.GetCustomAttributes())
                .EnsureSuccess();
        }

        [Fact]
        public async Task GetAvailableAuthenticationFactorsTest()
        {
            var rolesForUser = (await OneLoginClient.GetAvailableAuthenticationFactors(32715399))
                .EnsureSuccess();
        }

        [Fact]
        public async Task GetEnrolledAuthenticationFactors()
        {
            var rolesForUser = (await OneLoginClient.GetEnrolledAuthenticationFactors(32715399))
                .EnsureSuccess();
        }

        [Fact]
        public async Task GetGroupsTest()
        {
            var groups = (await OneLoginClient.GetGroups())
                .EnsureSuccess();
        }

        [Fact]
        public async Task GetGroupTest()
        {
            var groups = (await OneLoginClient.GetGroup(434968))
                .EnsureSuccess();
        }
    }
}
