using GreenAtom.Data.Models;
using System.Collections.Generic;


namespace GreenAtom.Data.Interfaces
{
    interface IAllProducts:IBaseInterface<Product>
    {
        IEnumerable<Product> GetAllProducts { get; }
    }
}
