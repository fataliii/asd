

using Book.Core.Models.Base;
using System.Xml.Linq;

namespace Book.Core.Models
{
    public class BookWriter : Basemodel
    {
        private static int _id;
        public string Surname { get; set; }
        public int Age { get; set; }
       
        public int Books { get; set; }

        public List<Bookk> Bookss;


        public BookWriter(string name, string surname, int age ,int books)
        {
            _id++;
            Id = _id;
            Name = name;
            Surname = surname;
            Age = age;
            Books = books;
            Bookss = new List<Bookk>();
            CreatedDate = DateTime.UtcNow.AddHours(4);
            UpdatedDate = DateTime.UtcNow.AddHours(4);

        }
        public override string ToString()
        {
            return $"Name: {Name}, Surname: {Surname} ,Age: {Age}, Books:{Books} , CreateDate: {CreatedDate}, UpdateDate: {UpdatedDate}";

        }
    }
}
