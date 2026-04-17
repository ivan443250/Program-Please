namespace ElementaryCase
{
    public static class CodeStringTools
    {
        public static bool TryReadCodeBeforeChar(string code, ref int readPointer, char endChar, out string result)
        {
            int startPointer = readPointer;

            while (code.Length > readPointer && code[readPointer++] != endChar)
            {
            }

            bool findEndChar = code[readPointer - 1] == endChar;

            if (findEndChar)
                result = code[startPointer..(readPointer - 1)];
            else
                result = code[startPointer..];

            return findEndChar;
        }
    }
}
