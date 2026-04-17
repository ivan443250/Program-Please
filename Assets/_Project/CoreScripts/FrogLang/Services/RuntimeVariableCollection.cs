using System.Collections.Generic;

namespace ElementaryCase
{
    public class RuntimeVariableCollection : IRuntimeVariableCollection
    {
        private readonly Dictionary<string, string> _variables = new();

        public void Clear()
        {
            _variables.Clear();
        }

        public void SetVariable(string name, string value)
        {
            if (_variables.ContainsKey(name) == false)
                _variables.Add(name, value);
            else
                _variables[name] = value;
        }

        public string GetVariable(string name)
        {
            if (_variables.TryGetValue(name, out string value))
                return value;

            throw new VariableNotExistException(name);
        }
    }
}
