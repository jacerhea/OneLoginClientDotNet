namespace OneLogin.Requests
{
    public class SetPasswordByIdUsingCleartextRequest
    {
        public string password { get; set; }
        public string password_confirmation { get; set; }
        public string validate_policy { get; set; }
    }

}