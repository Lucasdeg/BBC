using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBC
{
    interface IFactory<T, S>
    {
        T Generate(S data);
    }
}
