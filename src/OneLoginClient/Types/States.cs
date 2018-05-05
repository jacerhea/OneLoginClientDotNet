using OneLogin.Descriptors;

namespace OneLogin.Types
{
    /// <summary>
    /// States describe a stage in a process (such as user account approval). User state determines the possible statuses a user account can be in.
    /// </summary>
    [SourceDocumentation("https://developers.onelogin.com/api-docs/1/users/set-state")]
    public enum States
    {
        Unapproved = 0,
        Approved = 1,
        Rejected = 2,
        Unlicensed = 3
    }
}
