using GreenAtom.Data.Database;
using GreenAtom.Data.Interfaces;
using GreenAtom.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenAtom.Data.Repository
{
    public class BaseRepository<T> : IBaseInterface<T> where T : BaseModel
    {
        private AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(T model)
        {
            if (!_context.Set<T>().Contains(model))
            {
                _context.Set<T>().Add(model);
            }
            _context.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            var model = _context.Set<T>().Find(Id);
            if (model != null)
            {
                _context.Set<T>().Remove(model);
            }
            _context.SaveChanges();
        }

        public T Edit(T model)
        {
            var user = _context.Set<T>().Find(model.Id);
            if (user != null)
            {
                _context.Set<T>().Update(user);
            }
            _context.SaveChanges();
            return user;
        }

        public T Get(Guid Id) => _context.Set<T>().Find(Id);
    }
}
