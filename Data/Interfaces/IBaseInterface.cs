using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenAtom.Data.Interfaces
{
    public interface IBaseInterface<T>
    {
        T Get(Guid Id);
        void Add(T model);
        T Edit(T model);
        void Delete(Guid Id);
    }
}
