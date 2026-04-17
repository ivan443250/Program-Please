using System;

namespace ElementaryCase
{
    public class VariableNotExistException : Exception
    {
        public override string Message => $"Variable with name {_name} not exist";

        private readonly string _name;

        public VariableNotExistException(string name)
        {
            _name = name;
        }
    }
}
