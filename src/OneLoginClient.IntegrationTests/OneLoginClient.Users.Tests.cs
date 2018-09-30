using System;
using System.Threading.Tasks;
using FluentAssertions;
using OneLogin.Requests;
using Xunit;

namespace OneLogin.IntegrationTests
{
    public class OneLoginClientUsersTests
    {
        private static readonly OneLoginClient _oneLoginClient = new OneLoginClient("1e6c17c7ce20cc7a1faa070819555437fcdfcea1a7aa2ba355d49120fb979072", "a3ef28579190690be34df472064a145a640a1dd2cbf9a4c485cc40731dcd9ab6");

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
    }
}
