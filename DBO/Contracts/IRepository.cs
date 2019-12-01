using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBO.Contracts
{
    public interface IRepository<T> where T: class
    {
        Task AddAsync(T item);
        Task AddRangeAsync(ICollection<T> item);
        T FindById(long id);
        DbSet<T> GetAll();
        Task UpdateAsync(T item);
    }
}
