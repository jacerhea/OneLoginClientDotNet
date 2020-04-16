using System;
using System.IO;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OneLogin.Responses;
using Xunit;

namespace OneLogin.IntegrationTests
{
    public class SerializationTests
    {
        [Fact]
        public void Api_Source_Api_Example_Serializes_GetRolesForUser()
        {
            TestReserializationWithEquivalency<GetRolesForUser>("Data/GetRolesForUser.200.json");
        }

        [Fact]
        public void Api_Source_Api_Example_Serializes_GetUserById()
        {
            TestReserialization<GetUserResponse>("Data/GetUserById.200.json");
        }

        [Fact]
        public void Api_Source_Api_Example_Serializes_GetUsers()
        {
            TestReserialization<GetUsersResponse>("Data/GetUsers.200.json");
        }

        [Fact]
        public void Api_Source_Api_Example_Serializes_BadRequest()
        {
            TestReserializationWithEquivalency<BaseStatusResponse>("Data/BadRequest.400.json");
        }

        [Fact]
        public void Api_Source_Api_Example_Serializes_BadRequest401()
        {
            TestReserializationWithEquivalency<BaseStatusResponse>("Data/BadRequest.401.json");
        }

        [Fact]
        public void Api_Source_Api_Example_Serializes_GetCustomAttributes()
        {
            TestReserializationWithEquivalency<GetCustomAttributesResponse>("Data/GetCustomAttributes.200.json");
        }

        private void TestReserialization<T>(string path)
        {
            var json = File.ReadAllText(path);

            Func<T> reserialize = () => JsonConvert.DeserializeObject<T>(json);
            var deserializedObject = reserialize.Should().NotThrow().Subject;

            Func<string> deserialize = () => JsonConvert.SerializeObject(deserializedObject);
            var reserializedJson = deserialize.Should().NotThrow().Subject;

            var expected = JToken.Parse(json);
            var actual = JToken.Parse(reserializedJson);
        }

        private void TestReserializationWithEquivalency<T>(string path)
        {
            var json = File.ReadAllText(path);

            Func<T> reserialize = () => JsonConvert.DeserializeObject<T>(json);
            var deserializedObject = reserialize.Should().NotThrow().Subject;

            Func<string> deserialize = () => JsonConvert.SerializeObject(deserializedObject);
            var reserializedJson = deserialize.Should().NotThrow().Subject;

            var expected = JToken.Parse(json);
            var actual = JToken.Parse(reserializedJson);

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
