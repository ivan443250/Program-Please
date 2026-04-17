using System;

namespace ElementaryCase
{
    public class UnexpectedInstructionInCodeException : Exception
    {
        public override string Message => $"Unexpected instruction with name [{_instructionName}]";

        private readonly string _instructionName;

        public UnexpectedInstructionInCodeException(string code, int startInstructionPointer)
        {
            CodeStringTools.TryReadCodeBeforeChar(code, ref startInstructionPointer, '(', out string result);
            _instructionName = result;
        }
    }
}
