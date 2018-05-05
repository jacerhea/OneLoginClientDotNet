namespace OneLogin.Requests
{
    public class EnrollAnAuthenticationFactorRequest
    {
        public int factor_id { get; set; }
        public string display_name { get; set; }
        public string number { get; set; }
    }
}
