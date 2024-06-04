using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repository
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected ShoppingContext _shoppingContext;
        protected DbSet<T> _table = null;

        public GenericRepository(ShoppingContext shoppingContext)
        {
            _shoppingContext = shoppingContext;
            _table = shoppingContext.Set<T>();
        }
        public virtual T Add(T entity)
        {
            return _table.Add(entity).Entity;
        }

        public virtual IEnumerable<T> All()
        {
            return _table.ToList();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> filter)
        {
            return _table.Where(filter).ToList();
        }

        public T Get(int id)
        {
            return _shoppingContext.Find<T>(id); 
        }

        public void SaveChanges()
        {
            _shoppingContext.SaveChanges();
        }

        public virtual T Update(T entity)
        {
            return _shoppingContext.Update(entity).Entity;
        }
    }
}
