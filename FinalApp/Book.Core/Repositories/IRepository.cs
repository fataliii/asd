
using Book.Core.Models.Base;

namespace Book.Core.Repositories
{
    public interface IRepository<T> where T : Basemodel
    {
        public Task AddAsync(T model);
        public Task<T> GetAsync(Func<T, bool> statement);
        public Task<List<T>> GetAllAsync();
        public Task RemoveAsync(T model);
    }
}
