using DBO.Contexts;
using DBO.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBO.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class 
    {
        protected readonly OrdersDbContext ordersDbContext;

        public BaseRepository(OrdersDbContext ordersDbContext )
        {
            this.ordersDbContext = ordersDbContext;
        }

        public Task AddAsync(T item)
        {
            ordersDbContext.Set<T>().Add(item);
            return ordersDbContext.SaveChangesAsync();
        }

        public Task AddRangeAsync(ICollection<T> item)
        {
            ordersDbContext.Set<T>().AddRange(item);
            return ordersDbContext.SaveChangesAsync();
        }

        public DbSet<T> GetAll()
        {
            return ordersDbContext.Set<T>();
        }

        public T FindById(long id)
        {
            return ordersDbContext.Set<T>().Find(id);
        }

        public Task UpdateAsync(T item)
        {
            ordersDbContext.Entry(item).State = EntityState.Modified;
            return ordersDbContext.SaveChangesAsync();
        }
    }
}
