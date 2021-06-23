using GreenAtom.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenAtom.Data.Interfaces
{
    interface IAllOrders : IBaseInterface<Order>
    {
        IEnumerable<Order> GetAllOrders { get; }
    }
}
