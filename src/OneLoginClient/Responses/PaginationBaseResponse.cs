namespace OneLogin.Responses
{
    public abstract class PaginationBaseResponse<T> : BaseResponse<T>, IPageable
    {
        public Pagination Pagination { get; set; }
    }

    public interface IPageable
    {
        Pagination Pagination { get; set; }
    }
}
