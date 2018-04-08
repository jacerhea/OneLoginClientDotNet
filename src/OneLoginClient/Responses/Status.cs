namespace OneLogin.Responses
{
    public class Status
    {
        public bool Error { get; set; }

        public long Code { get; set; }

        public string Type { get; set; }

        public string Message { get; set; }
    }
}
