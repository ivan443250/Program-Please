using System;
using System.Collections.Generic;

namespace ElementaryCase
{
    public class FrogLangCoreLibrary : ILibrary
    {
        public IReadOnlyDictionary<string, Delegate> LibraryFunctions => _coreFunctions;

        private readonly IReadOnlyDictionary<string, Delegate> _coreFunctions;

        private readonly IRuntimeVariableCollection _variableCollection;
        private readonly IInterpreter _interpreter;

        public FrogLangCoreLibrary(IRuntimeVariableCollection variableCollection, IInterpreter interpreter)
        {
            _variableCollection = variableCollection;
            _interpreter = interpreter;

            _coreFunctions = new Dictionary<string, Delegate>()
            { 
                { nameof(SetVariable), (SetVariableDelegate)SetVariable },
                { nameof(GetVariable), (GetVariableDelegate)GetVariable },

                { nameof(Or), (OrDelegate)Or },
                { nameof(And), (AndDelegate)And },
                { nameof(Not), (NotDelegate)Not },
                { nameof(Equals), (EqualsDelegate)Equals },

                { nameof(Plus), (PlusDelegate)Plus },
                { nameof(Minus), (MinusDelegate)Minus },
                { nameof(Multiply), (MultiplyDelegate)Multiply },
                { nameof(Divide), (DivideDelegate)Divide },
                { nameof(Increment), (IncrementDelegate)Increment },
                { nameof(Decrement), (DecrementDelegate)Decrement },

                { nameof(If), (IfDelegate)If },
                { nameof(While), (WhileDelegate)While },
            };
        }

        #region Variable

        private delegate void SetVariableDelegate(string variableName, string value);
        private void SetVariable(string variableName, string value)
        {
            _variableCollection.SetVariable(variableName, value);
        }

        private delegate string GetVariableDelegate(string variableName);
        private string GetVariable(string variableName)
        {
            return _variableCollection.GetVariable(variableName);
        }

        #endregion

        #region BoolOperations

        private delegate string OrDelegate(string boolName1, string boolName2);
        private string Or(string boolName1, string boolName2)
        {
            return (ConvertToBoolInternal(boolName1) || ConvertToBoolInternal(boolName2)).ToString().ToLower();
        }

        private delegate string AndDelegate(string boolName1, string boolName2);
        private string And(string boolName1, string boolName2)
        {
            return (ConvertToBoolInternal(boolName1) && ConvertToBoolInternal(boolName2)).ToString().ToLower();
        }

        private delegate string NotDelegate(string boolName);
        private string Not(string boolName)
        {
            return (!ConvertToBoolInternal(boolName)).ToString().ToLower();
        }

        private delegate string EqualsDelegate(string variableName1, string variableName2);
        private string Equals(string variableName1, string variableName2)
        {
            return (_variableCollection.GetVariable(variableName1) == _variableCollection.GetVariable(variableName2)).ToString().ToLower();
        }

        private bool ConvertToBoolInternal(string boolName)
        {
            string value = _variableCollection.GetVariable(boolName);
            if (value == "true") return true;
            else if (value == "false") return false;
            else throw new ConvertException(value, boolName, "bool");
        }

        #endregion

        #region IntOperations

        private delegate string PlusDelegate(string numberName1, string numberName2);
        private string Plus(string numberName1, string numberName2)
        {
            return (ConvertToIntInternal(numberName1) + ConvertToIntInternal(numberName2)).ToString();
        }

        private delegate string MinusDelegate(string numberName1, string numberName2);
        private string Minus(string numberName1, string numberName2)
        {
            return (ConvertToIntInternal(numberName1) - ConvertToIntInternal(numberName2)).ToString();
        }

        private delegate string MultiplyDelegate(string numberName1, string numberName2);
        private string Multiply(string numberName1, string numberName2)
        {
            return (ConvertToIntInternal(numberName1) * ConvertToIntInternal(numberName2)).ToString();
        }

        private delegate string DivideDelegate(string numberName1, string numberName2);
        private string Divide(string numberName1, string numberName2)
        {
            return (ConvertToIntInternal(numberName1) / ConvertToIntInternal(numberName2)).ToString();
        }

        private delegate string IncrementDelegate(string numberName);
        private string Increment(string numberName)
        {
            return (ConvertToIntInternal(numberName) + 1).ToString();
        }

        private delegate string DecrementDelegate(string numberName);
        private string Decrement(string numberName)
        {
            return (ConvertToIntInternal(numberName) - 1).ToString();
        }

        private int ConvertToIntInternal(string numberName)
        {
            string value = _variableCollection.GetVariable(numberName);

            if (int.TryParse(value, out int number) == false)
                throw new ConvertException(value, numberName, "int");

            return number;
        }

        #endregion

        #region BaseConstructions

        private delegate void IfDelegate(string conditionBoolName, string instructions);
        private void If(string conditionBoolName, string instructions)
        {
            if (ConvertToBoolInternal(conditionBoolName) == false)
                return;

            _interpreter.Run(instructions);
        }

        private delegate void WhileDelegate(string conditionBoolName, string instructions);
        private void While(string conditionBoolName, string instructions)
        {
            int maxCycles = 9999;

            while (ConvertToBoolInternal(conditionBoolName))
            {
                if (maxCycles-- <= 0)
                    throw new InfinitCycleLoopException();

                _interpreter.Run(instructions);
            }
        }

        #endregion
    }
}
