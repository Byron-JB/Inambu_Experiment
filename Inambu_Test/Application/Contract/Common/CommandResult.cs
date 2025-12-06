using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Common
{
    public class CommandResult
    {
        private CommandResult(bool isSuccess, Error? error, object? returnValue)
        {
            if (isSuccess && error != null || !isSuccess && error == null)
            {
                throw new ArgumentException("Invalid error", nameof(error));
            }

            IsSuccess = isSuccess;
            Error = error ?? Error.None;
            ReturnValue = returnValue;
        }

        public static CommandResult Success(object returnValue) => new CommandResult(true, null, returnValue);

        public static CommandResult Failure(Error error, object returnValue) => new CommandResult(false, error, returnValue);

        public bool IsSuccess { get; }

        public bool IsFailure => !IsSuccess;

        public object? ReturnValue { get; set; }

        public Error Error { get; set; } = Error.None;
    }

}
