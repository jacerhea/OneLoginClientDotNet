using System;
using System.Threading.Tasks;
using FluentAssertions;
using OneLogin.Requests;
using Xunit;

namespace OneLogin.IntegrationTests
{
    public class OneLoginClientUsersTests
    {
        private static readonly OneLoginClient _oneLoginClient = new OneLoginClient("fill in your client id", "fill in your client secret");

        [Fact]
        public async Task User_Can_Be_Created()
        {
            var user = await _oneLoginClient.CreateUser(new CreateUserRequest
            {
                Email = "test@test.com",
                Username = "OneLoginClientTest",
                FirstName = "FirstNameTest",
                LastName = "LastNameTest",
                Company = "CompanyNameTest",
                Department = "DepartmentTest",
                DirectoryId = null,
                DistinguishedName = "DistinguishedNameTest",
                ExternalId = "ExternalIdTest",
                GroupId = null,
                InvalidLoginAttempts = 1,
                LocaleCode = "us",
                Title = "TitleTest",
                Phone = "1-555-123-4567"
            });

            Action ensureSuccess = () => user.EnsureSuccess();
            ensureSuccess.Should().NotThrow();
        }

        [Fact]
        public async Task GetUsersTest()
        {
            var usersResponse = (await _oneLoginClient.GetUsers())
                .EnsureSuccess();

            usersResponse.Data.Should().HaveCountGreaterOrEqualTo(1);
        }

        [Fact]
        public async Task GetUserByEmail()
        {
            var usersResponse = (await _oneLoginClient.GetUsers(email: "jrhea@performancetrust.com"))
                .EnsureSuccess();
            usersResponse.Data.Should().HaveCount(1);
        }



        [Fact]
        public async Task GetUserByIdTest()
        {
            var usersResponse = (await _oneLoginClient.GetUserById(32715399))
                .EnsureSuccess();

            usersResponse.Data.Should().HaveCount(1);
        }

        [Fact]
        public async Task GetAppsForUserTest()
        {
            var getAppsForUserResponse = (await _oneLoginClient.GetAppsForUser(32715399))
                .EnsureSuccess();
        }

        [Fact]
        public async Task GetGetRolesForUserTest()
        {
            var rolesForUser = (await _oneLoginClient.GetRolesForUser(32715399))
                .EnsureSuccess();
        }

        [Fact]
        public async Task UpdateUserByIdTest()
        {
            var updateResponse = await _oneLoginClient.UpdateUserById(32715399, new UpdateUserByIdRequest
            {
                FirstName = "FirstNameTest" // Don't actually change it so we don't affect the integration environment
            });

            updateResponse.EnsureSuccess();
            updateResponse.Data.Should().HaveCount(1);
        }


    }
}
