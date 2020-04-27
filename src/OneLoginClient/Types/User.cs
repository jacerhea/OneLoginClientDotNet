using System.Runtime.Serialization;

namespace OneLogin.Types
{
    [DataContract]
    public class UserConcise
    {

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
