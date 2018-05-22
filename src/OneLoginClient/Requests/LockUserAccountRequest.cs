using System.Runtime.Serialization;

namespace OneLogin.Requests
{
    /// <summary>
    /// Use this call to lock a user’s account based on the policy assigned to the user, for a specific time you define in the request, or until you unlock it.
    /// </summary>
    [DataContract]
    public class LockUserAccountRequest
    {
        /// <summary>
        /// Set to the number of minutes for which you want to lock the user account.
        /// </summary>
        [DataMember(Name = "locked_until")]
        public int LockedUntil { get; set; }
    }
}
