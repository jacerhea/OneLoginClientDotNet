using System;
using System.IO;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OneLogin;
using OneLogin.Requests;
using OneLogin.Responses;
using Xunit;

namespace OneLoginClient.UnitTests
{
    public class RequestSerializationTests
    {
        private Serializer _serializer = new Serializer();

        [Fact]
        public void Api_Source_Api_Example_Serializes_LockUserAccountRequest()
        {
            TestReserializationWithEquivalency<LockUserAccountRequest>("Data/Requests/LockUserAccount.json");
        }

        [Fact]
        public void Api_Source_Api_Example_Serializes_SetUserStateRequest()
        {
            TestReserializationWithEquivalency<SetUserStateRequest>("Data/Requests/SetUserState.json");
        }

        [Fact]
        public void Api_Source_Api_Example_Serializes_SetCustomAttributeRequest()
        {
            TestReserializationWithEquivalency<SetCustomAttributeRequest>("Data/Requests/SetCustomAttribute.json");
        }

        [Fact]
        public void Api_Source_Api_Example_Serializes_SetPasswordByIdUsingSaltAndSHA256()
        {
            TestReserializationWithEquivalency<SetPasswordByIdUsingSaltAndSHA256>("Data/Requests/SetPasswordSHA256.json");
        }

        [Fact]
        public void Api_Source_Api_Example_Serializes_SetPasswordByIdUsingCleartextRequest()
        {
            TestReserializationWithEquivalency<SetPasswordByIdUsingCleartextRequest>("Data/Requests/SetPasswordClearText.json");
        }

        [Fact]
        public void Api_Source_Api_Example_Serializes_RemoveRoleFromUser()
        {
            TestReserializationWithEquivalency<RemoveRoleFromUserRequest>("Data/Requests/RemoveRoleFromUser.json");
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
            Func<T> deserialize = () =>
            {
                using (var fileStream = File.OpenRead(path))
                {
                    return _serializer.DeserializeJsonFromStream<T>(fileStream);
                }
            };

            var deserializedObject = deserialize.Should().NotThrow().Subject;

            Func<string> serialized = () => _serializer.Serialize(deserializedObject);

            var serializedAsJson = serialized.Should().NotThrow().Subject;
            var expected = JToken.Parse(serializedAsJson);
            var actual = JToken.Parse(File.ReadAllText(path));

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
