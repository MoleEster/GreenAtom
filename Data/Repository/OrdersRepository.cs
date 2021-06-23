using GreenAtom.Data.Database;
using GreenAtom.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenAtom.Data.Repository
{
    public class OrdersRepository:BaseRepository<Order>
    {
        public OrdersRepository(AppDbContext context) : base(context)
        {
        }
    }
}
