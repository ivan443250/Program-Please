namespace ElementaryCase
{
    public class FrogLangInterpreter : IInterpreter
    {
        private readonly IFunctionModulesCollection _functionModules;

        public FrogLangInterpreter(IFunctionModulesCollection functionModules)
        {
            _functionModules = functionModules;
        }

        public void Run(string code)
        {
            code = code
                .Replace(" ", "")
                .Replace("\r", "")
                .Replace("\t", "")
                .Replace("\n", "");

            int readPointer = 0;

            try
            {
                while (true)
                {
                    RunNextInstructionInternal(code, ref readPointer);
                }
            }
            catch (EndOfCodeWasReachedException)
            {
            }
        }

        private void RunNextInstructionInternal(string code, ref int readPointer)
        {
            if (readPointer >= code.Length)
                throw new EndOfCodeWasReachedException(code.Length);

            if (code[readPointer] != '(')
                throw new UnexpectedInstructionInCodeException(code, readPointer);

            _functionModules.RunFunction(ReadInstructionBrackets(code, ref readPointer));
        }

        private string[] ReadInstructionBrackets(string code, ref int readPointer)
        {
            if (code[readPointer++] != '(')
                throw new IncorrectBracketsPlacementException(readPointer - 1);

            int lastBrackets = 0;
            string bracketsContent = null;

            for (int i = readPointer; i < code.Length; i++)
            {
                if (code[i] == ',' && lastBrackets != 0)
                {
                    code = code[0..i] + ';' + code[(i + 1)..];
                }

                if (code[i] == ')' && lastBrackets == 0)
                {
                    bracketsContent = code[readPointer..i];
                    readPointer = i + 1;
                    break;
                }

                if (code[i] == '(')
                {
                    lastBrackets++;
                    continue;
                }

                if (code[i] == ')')
                    lastBrackets--;
            }

            if (bracketsContent == null)
                throw new IncorrectBracketsPlacementException(readPointer - 1);

            code = code.Replace(';', ',');
            string[] bracketsParameters = bracketsContent.Split(',');

            for (int i = 0; i < bracketsParameters.Length; i++)
                bracketsParameters[i] = bracketsParameters[i].Replace(';', ',');

            return bracketsParameters;
        }
    }
}