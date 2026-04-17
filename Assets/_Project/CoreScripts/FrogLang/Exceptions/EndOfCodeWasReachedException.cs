using System;

namespace ElementaryCase
{
    public class EndOfCodeWasReachedException : Exception
    {
        public override string Message => $"End of code with {_codeLength} was reached";

        private readonly int _codeLength;

        public EndOfCodeWasReachedException(int codeLength)
        {
            _codeLength = codeLength;
        }
    }
}
