using GreenAtom.Data.Database;
using GreenAtom.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenAtom.Data.Repository
{
    public class ProductsRepository : BaseRepository<Product>
    {
        public ProductsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
