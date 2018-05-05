using System.Runtime.Serialization;

namespace OneLogin.Responses
{

    [DataContract]
    public abstract class PaginationBaseResponse<T> : BaseResponse<T>, IPageable
    {
        /// <summary>
        /// When you call a resource API, the response message will include a pagination element like the one shown here:
        /// </summary>
        [DataMember(Name = "pagination")]
        public Pagination Pagination { get; set; }
    }

    public interface IPageable
    {
        /// <summary>
        /// When you call a resource API, the response message will include a pagination element like the one shown here:
        /// </summary>
        [DataMember(Name = "pagination")]
        Pagination Pagination { get; set; }
    }
}
