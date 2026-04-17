using System;

namespace ElementaryCase
{
    public class IncorrectBracketsPlacementException : Exception
    {
        public override string Message => $"Incorrect brackets placement in index {_incorrectPlacementIndex}";

        private readonly int _incorrectPlacementIndex;

        public IncorrectBracketsPlacementException(int incorrectPlacementIndex)
        {
            _incorrectPlacementIndex = incorrectPlacementIndex;
        }
    }
}
