namespace OneLogin.Responses
{
    public abstract class BaseResponse<T>
    {
        public Status Status { get; set; }
        public T[] Data { get; set; }
    }
}
