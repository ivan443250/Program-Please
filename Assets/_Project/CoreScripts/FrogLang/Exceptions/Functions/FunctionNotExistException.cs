using System;

namespace ElementaryCase
{
    public class FunctionNotExistException : Exception
    {
        public override string Message => $"Function with name {_functionName} does not exist";

        private readonly string _functionName;

        public FunctionNotExistException(string functionName)
        {
            _functionName = functionName;
        }
    }
}
