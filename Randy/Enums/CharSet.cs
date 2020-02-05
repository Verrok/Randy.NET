using System;
using System.Collections.Generic;
using System.Text;

namespace Randy.Enums
{
    public enum CharSet
    {
        Lower = 1,
        Upper = 2,
        Digits = 4,
        Symbols = 8,
        Alphabet = 16,
        AlphaNumeric = 32,
        All = 64
    }
}
