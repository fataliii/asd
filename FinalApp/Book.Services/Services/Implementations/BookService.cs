

using Book.Core.Enums;
using Book.Core.Models;
using Book.Data.Repositories.Bookwriters;
using Book.Services.Services.Interfaces;

namespace Book.Services.Services.Implementations
{
    public class BookService : IBookServise
    {
        private readonly BookWriterRepository _repository = new BookWriterRepository();

        public async Task<string> CreateAsync(int id, string name, double price, double discountprice, bool bookInStock, BookCategory category)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            BookWriter bookWriter = await _repository.GetAsync(book => book.Id == id);
            if (bookWriter == null)
                return "There is no book";
            if (await ValideteBook(name, price, discountprice) != null)
            {
                return await ValideteBook(name, price, discountprice);
            }
            Bookk book = new Bookk(name, price,discountprice, bookInStock, category, bookWriter);

            bookWriter.Bookss.Add(book);

            Console.ForegroundColor = ConsoleColor.Green;
            return "Created";
        }

        public async Task<string> DeleteAsync(int bookwriterId, int bookId)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            BookWriter bookWriter = await _repository.GetAsync(bookwriter => bookwriter.Id == bookwriterId);
            if (bookWriter == null)
                return "There is no such book writer";
            Bookk book = bookWriter.Bookss.FirstOrDefault(book => book.Id == bookId);
            if (book == null)
                return "There is no book";

            bookWriter.Bookss.Remove(book);
            Console.ForegroundColor = ConsoleColor.Green;
            return "Deleted";

        }
        public async Task<string> UpdateAsync(int bookwriterId, int bookId, string name,  double price, double discountprice, bool bookInStock)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            BookWriter bookWriter = await _repository.GetAsync(bookwriter => bookwriter.Id == bookwriterId);
            if (bookWriter == null)
                return "There is no such book writer";


            if (await ValideteBook(name, price, discountprice) != null)
            {
                return await ValideteBook(name, price, discountprice);
            }



            Bookk book = bookWriter.Bookss.FirstOrDefault(book => book.Id == bookId);
            book.Name = name;
            book.Price = price;
            book.DiscountPrice = discountprice;


            Console.ForegroundColor = ConsoleColor.Green;
            return "Updated";
        }
        public async Task GetAll()
        {
            foreach (var item in await _repository.GetAllAsync())
            {

                foreach (var prod in item.Bookss)
                {
                    Console.WriteLine(prod);
                }
            }
        }

        public async Task<Bookk> GetAsync(int bookwriterId, int bookId)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            BookWriter bookWriter = await _repository.GetAsync(bookwriter => bookwriter.Id == bookwriterId);
            if (bookWriter == null)
            {
                Console.WriteLine("There is no such book writer");
                return null;
            }
            Bookk book = bookWriter.Bookss.FirstOrDefault(book => book.Id == bookId);
            if (book == null)
            {
                Console.WriteLine("There is no bokk");
                return null;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            return book;
        }

        public async Task<string> BuyBookAsync(int bookwriterId, int bookId, bool BookInStock)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            BookWriter bookWriter = await _repository.GetAsync(bookwriter => bookwriter.Id == bookwriterId);
            Console.ForegroundColor = ConsoleColor.Green;

            if (bookwriterId == null)
                return "There is no such writer";

            Bookk book = bookWriter.Bookss.FirstOrDefault(x => x.Id == bookId);
            Console.ForegroundColor = ConsoleColor.Green;

            if (book == null)
                return "This book not found";

            if (!book.BookInStock)
                return "This book is currently unavailable";


            return "Successfully bought";
        }


        private async Task<string> ValideteBook(string name, double price, double discountprice)
        {

            if (string.IsNullOrWhiteSpace(name))
                return "The title of the book is incorrect";
            if (price < 0)
                return "Add valid price";
            if (discountprice > price || discountprice <= 0)
                return "Add valid discountprice";
            return null;
        }

    }
}
