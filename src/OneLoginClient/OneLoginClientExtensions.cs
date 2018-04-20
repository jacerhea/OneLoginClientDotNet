using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OneLogin.Responses;

namespace OneLogin
{
    public static class OneLoginClientExtensions
    {
        public static T EnsureSuccess<T>(this T source) where T : BaseStatusResponse
        {
            if (source.Status.Error)
            {
                throw new Exception("Call failed.");
            }

            return source;
        }
    }
}
