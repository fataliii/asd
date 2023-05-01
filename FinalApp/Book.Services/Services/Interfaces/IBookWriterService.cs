
using Book.Core.Models;

namespace Book.Services.Services.Interfaces
{
    internal interface IBookWriterService
    {
        public interface IBookWriterService
        {
            public Task<string> CreateAsync(string name, string surname, int age, int books);
            public Task<string> DeleteAsync(int id);
            public Task<string> UpdateAsync(int id, string name, string surname, int age, int books);
            public Task<BookWriter> GetAsync(int id);
            public Task GetAllAsync();
            public Task<List<Bookk>> GetAllBooksAsync(int id);
        }
    }
}
