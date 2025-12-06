using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Contract.Common
{
    public class QueryResult<T> where T : class
    {
        public bool IsSuccess { get; }

        public bool IsFailure => !IsSuccess;

        public T? Data { get; set; }

        public Error Error { get; set; } = Error.None;

        private QueryResult(bool isSuccess, T? data, Error error)
        {
            if (isSuccess && data == null || !isSuccess && data is not null)
            {
                throw new ArgumentException("Invalid results", nameof(error));
            }

            IsSuccess = isSuccess;
            Data = data;
            Error = error;
        }

        public static QueryResult<T> Success(T? data) => new QueryResult<T>(true, data, new Error(HttpStatusCode.OK, ""));

        public static QueryResult<T> Failure(Error error, T? data = null) => new QueryResult<T>(false, data, error);

    }


}
