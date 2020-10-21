namespace SUS.HTTP.Enums
{
    public enum HttpStatusCode
    {
        Ok = 200,
        Created = 201,
        Accepted = 202,
        NoContent= 204,
        MovedPermanently = 301,
        Found = 302,
        NotModified = 304,
        BadRequest = 400,
        UnAuthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        InternalServerError = 500,
        NotImplemented = 501,
        BadGetaway = 502,
        ServiceUnavailable = 503
    }
}
