using System;
using System.Collections.Generic;

namespace ElementaryCase
{
    public interface ILibrary
    {
        IReadOnlyDictionary<string, Delegate> LibraryFunctions { get; }
    }
}
