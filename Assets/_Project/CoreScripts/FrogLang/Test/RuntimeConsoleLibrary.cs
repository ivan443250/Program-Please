using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace ElementaryCase.Test
{
    public class RuntimeConsoleLibrary : MonoBehaviour, ILibrary
    {
        public IReadOnlyDictionary<string, Delegate> LibraryFunctions { get; private set; }

        [SerializeField] private TMP_InputField _inputFiled;

        private IRuntimeVariableCollection _variableCollection;

        [Inject]
        public void Construct(IRuntimeVariableCollection variableCollection)
        {
            _variableCollection = variableCollection;
        }

        public void Initialize()
        {
            LibraryFunctions = new Dictionary<string, Delegate>()
            {
                { nameof(ConsoleWrite), (ConsoleWriteDelegate)ConsoleWrite },
                { nameof(ConsoleRead), (ConsoleReadDelegate)ConsoleRead },
            };
        }

        private delegate void ConsoleWriteDelegate(string variableName);
        private void ConsoleWrite(string variableName)
        {
            UnityEngine.Debug.Log(_variableCollection.GetVariable(variableName));
        }

        private delegate string ConsoleReadDelegate();
        private string ConsoleRead()
        {
            return _inputFiled.text;
        }
    }
}
