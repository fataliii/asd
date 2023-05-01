

using Book.Core.Models;
using Book.Data.Repositories.Bookwriters;
using Book.Services.Services.Interfaces;
using System.Text.RegularExpressions;

namespace Book.Services.Services.Implementations
{
    public class BookWriterService : IBookWriterService
    {
        private readonly BookWriterRepository _repository = new BookWriterRepository();
        public async Task<string> CreateAsync(string name, string surname, int age, int books)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (string.IsNullOrWhiteSpace(name))
                return "There is no such Name";

            if (string.IsNullOrWhiteSpace(surname))
                return "There is no such Surname";
            if (age <= 15)
                return "Enter a valid age";
            if (books < 0)
                return "there is no book";

            Console.ForegroundColor = ConsoleColor.Green;
            BookWriter bookWriter = new BookWriter(name, surname,age, books);
            await _repository.AddAsync(bookWriter);
            return "Successfully craeted";
        }
        public async Task<string> DeleteAsync(int id)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            BookWriter bookWriter = await _repository.GetAsync(book => book.Id == id);
            if (bookWriter == null)
                return "There is no such book writer";

            await _repository.RemoveAsync(bookWriter);

            Console.ForegroundColor = ConsoleColor.Green;

            return "Deleted";
        }
        public async Task<string> UpdateAsync(int id, string name, string surname,int age, int books)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (string.IsNullOrWhiteSpace(name))
                return "There is no such Name";

            if (string.IsNullOrWhiteSpace(surname))
                return "There is no such Surname";


            BookWriter bookwriter = await _repository.GetAsync(s => s.Id == id);
            if (bookwriter == null)
                return "there is no book";

            bookwriter.Name = name;
            bookwriter.Surname = surname;
            bookwriter.Age = age;
            bookwriter.Books = books;
            

            Console.ForegroundColor = ConsoleColor.Green;
            return "Updated";
        }
        public async Task GetAllAsync()
        {
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var item in await _repository.GetAllAsync())
            {
                Console.WriteLine(item);
            }
        }
        public async Task<BookWriter> GetAsync(int id)
        {
            BookWriter bookWriter = await _repository.GetAsync(book => book.Id == id);

            if (bookWriter == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No such book writer was found");
                return null;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            return bookWriter;
        }
        public async Task<List<Bookk>> GetAllBooksAsync(int id)
        {
            BookWriter bookWriter = await _repository.GetAsync(book => book.Id == id);
            if (bookWriter == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" No such book writer was found");
                return null;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            return bookWriter.Bookss;

        }


    }
}

