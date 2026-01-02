using System.Net;

namespace Application.Contract.Common
{
    public sealed record Error(HttpStatusCode? Code, string? Description)
    {
        public static readonly Error None = new(null, string.Empty);
    }
}