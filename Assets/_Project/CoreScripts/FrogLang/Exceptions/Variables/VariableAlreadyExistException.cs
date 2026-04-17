using System;

namespace ElementaryCase
{
    public class VariableAlreadyExistException : Exception
    {
        public override string Message => $"Variable with name {_name} already exist";

        private readonly string _name;

        public VariableAlreadyExistException(string name)
        {
            _name = name;
        }
    }
}
