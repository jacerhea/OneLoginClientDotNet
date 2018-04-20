namespace OneLogin.Responses
{
    public class GetGroupsResponse : PaginationBaseResponse<Group>
    {
    }

    public class Group
    {
        public int id { get; set; }
        public string name { get; set; }
        public string reference { get; set; }
    }
}
