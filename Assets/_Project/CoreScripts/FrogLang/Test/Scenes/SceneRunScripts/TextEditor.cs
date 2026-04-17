using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace ElementaryCase.Test
{
    public class TextEditor : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;

        private IInterpreter _codeInterpreter;
        private IRuntimeVariableCollection _runtimeVariables;
        private IFunctionModulesImporter _modulesImporter;
        private IEnumerable<ILibrary> _libraries;

        [Inject]
        public void Construct(IInterpreter codeInterpreter, 
            IRuntimeVariableCollection runtimeVariables, 
            IFunctionModulesImporter modulesImporter, 
            IEnumerable<ILibrary> libraries)
        {
            _runtimeVariables = runtimeVariables;
            _codeInterpreter = codeInterpreter;
            _modulesImporter = modulesImporter;
            _libraries = libraries;
        }

        public void Initialize()
        {
            foreach (ILibrary library in _libraries)
                _modulesImporter.Import(library);
        }

        public void RunCode()
        {
            _runtimeVariables.Clear();
            _codeInterpreter.Run(_inputField.text);
        }
    }
}