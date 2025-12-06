using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Common
{
    public sealed record Error(HttpStatusCode? Code, string? Description)
    {
        public static readonly Error None = new(null, string.Empty);
    }
}