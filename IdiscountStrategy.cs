using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTest
{
    public interface IdiscountStrategy
    {
        string Name { get; }
        decimal Calculate(decimal price);
    }
}
