using System;
using System.Collections.Generic;

namespace Framework.Core.Bus
{
    public class CommandValidationResult
    {
        public IList<string> ValidationErrors { get; set; } = new List<string>();

        public bool HasError()
        {
            return ValidationErrors.Count > 0;
        }
        public void AddError(string errorMessage)
        {
            ValidationErrors.Add(errorMessage);
        }
    }

    public class CommandExecutionException : Exception
    {
        public CommandExecutionException(string message, Exception innerException = null) : base(message, innerException)
        {

        }
    }
}
