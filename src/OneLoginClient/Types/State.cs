namespace OneLogin.Types
{
    /// <summary>
    /// Represents the user’s stage in a process (such as user account approval).
    /// User state determines the possible statuses a user account can be in.
    /// </summary>
    public enum State
    {
        /// <summary>
        /// Unapproved
        /// </summary>
        Unapproved = 0,

        /// <summary>
        /// Approved
        /// </summary>
        Approved = 1,

        /// <summary>
        /// Rejected
        /// </summary>
        Rejected = 2,

        /// <summary>
        /// Unlicensed
        /// </summary>
        Unlicensed = 3
    }
}
