using System;

namespace ElementaryCase
{
    public class ConvertException : Exception
    {
        public override string Message => $"Cannot convert {_variableName} [{_variableValue}] to {_needType}";

        private readonly string _variableValue;
        private readonly string _variableName;
        private readonly string _needType;

        public ConvertException(string variableValue, string variableName, string needType)
        {
            _variableValue = variableValue;
            _variableName = variableName;
            _needType = needType;
        }
    }
}
