using System;
using OneLogin.Responses;

namespace OneLogin
{
    public static class OneLoginClientExtensions
    {
        public static T EnsureSuccess<T, TK>(T source) where T: BaseResponse<TK>
        {
            if (source.Status.Error)
            {
                throw new Exception("Call failed.");
            }

            return source;
        }
    }
}
