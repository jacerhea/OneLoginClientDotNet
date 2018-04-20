namespace OneLogin.Responses
{
    public abstract class BaseResponse<T> : BaseStatusResponse
    {
        public T[] Data { get; set; }
    }
}
