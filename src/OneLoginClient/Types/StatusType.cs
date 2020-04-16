namespace OneLogin.Types
{
    /// <summary>
    /// Determines the user’s ability to log in to OneLogin.
    /// </summary>
    public enum StatusType
    {
        /// <summary>
        /// Unactivated
        /// </summary>
        Unactivated = 0,

        /// <summary>
        ///  Active Only. users assigned this status can log in to OneLogin.
        /// </summary>
        ActiveOnly = 1,

        /// <summary>
        /// Suspended
        /// </summary>
        Suspended = 2,

        /// <summary>
        /// Locked
        /// </summary>
        Locked = 3,

        /// <summary>
        /// Password expired
        /// </summary>
        PasswordExpired = 4,

        /// <summary>
        /// Awaiting password reset. The user is required to reset their password
        /// </summary>
        AwaitingPasswordReset = 5,

        /// <summary>
        /// Password Pending. The user has not yet set a password
        /// </summary>
        PasswordPending = 7,

        /// <summary>
        /// Security questions required. The user has not yet set their security questions
        /// </summary>
        SecurityQuestionsRequired = 8
    }
}
