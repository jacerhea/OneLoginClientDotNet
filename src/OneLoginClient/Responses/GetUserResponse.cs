namespace OneLogin.Responses
{
    /// <summary>
    /// This call returns up to 50 users per page.
    /// For details about using the pagination element to easily “page” through users, see <a href="https://developers.onelogin.com/api-docs/1/getting-started/using-query-parameters#pagination">Pagination</a>.
    /// For details about each element in the User resource, see <a href="https://developers.onelogin.com/api-docs/1/users/user-resource">User Resource</a>.
    /// </summary>
    /// <inheritdoc cref="OneLogin.Responses.PaginationBaseResponse{T}" />
    public class GetUserResponse : BaseResponse<User>
    {

    }
  }
