using System;
using System.Collections.Generic;

namespace ElementaryCase
{
    public class FunctionModulesController : IFunctionModulesCollection, IFunctionModulesImporter
    {
        private readonly Dictionary<string, Delegate> _functions = new();
        private readonly IRuntimeVariableCollection _variableCollection;

        public FunctionModulesController(IRuntimeVariableCollection variableCollection)
        {
            _variableCollection = variableCollection;
        }

        public void Import(ILibrary library)
        {
            var functions = library.LibraryFunctions;

            foreach (string key in functions.Keys)
            {
                if (_functions.ContainsKey(key) == false)
                    _functions.Add(key, functions[key]);
                else
                    _functions[key] = functions[key];
            }
        }

        public void Remove(ILibrary library)
        {
            foreach (string key in library.LibraryFunctions.Keys)
                if (_functions.ContainsKey(key))
                    _functions.Remove(key);
        }

        public void RunFunction(params string[] parameters)
        {
            if (parameters.Length == 0)
                throw new NullParametersException();

            if (parameters.Length == 1)
                throw new TooLittleParamatersException();

            if (_functions.TryGetValue(parameters[0], out Delegate function) == false)
                throw new FunctionNotExistException(parameters[0]);

            string variableName = parameters[1];

            object result = function.DynamicInvoke(parameters[2..]);

            if (result != null)
                _variableCollection.SetVariable(variableName, result.ToString());
        }
    }
}
