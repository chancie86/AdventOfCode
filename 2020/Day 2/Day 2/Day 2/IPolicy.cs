using System;
using System.Collections.Generic;
using System.Text;

namespace Day_2
{
    public interface IPolicy
    {
        bool IsValid(string password);
    }
}
