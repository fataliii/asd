

using Book.Core.Enums;
using Book.Core.Models;

namespace Book.Services.Services.Interfaces
{
    public interface IBookServise
    {
        public Task<string> CreateAsync(int id, string name, double price, double discountprice, bool bookInStock, BookCategory category);
        public Task<string> DeleteAsync(int bookwriterId, int bookId);
        public Task<string> UpdateAsync(int bookwriterId, int bookId, string name,  double price, double discountprice, bool bookInStock);
        public Task<Bookk> GetAsync(int bookwriterId, int bookId);
        public Task GetAll();
        public Task<string> BuyBookAsync(int bookwriterId, int bookId, bool BookInStock);
    }
}
