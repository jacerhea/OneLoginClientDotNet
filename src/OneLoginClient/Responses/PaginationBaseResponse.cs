namespace OneLogin.Responses
{
    public abstract class PaginationBaseResponse<T> : BaseResponse<T>
    {
        public Pagination Pagination { get; set; }
    }
}
