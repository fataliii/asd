
using Book.Core.Enums;
using Book.Core.Models.Base;
using System.Xml.Linq;
using System.Reflection.Metadata;

namespace Book.Core.Models
{
    public class Bookk : Basemodel
    {
        private static int _id;
        public double Price { get; set; }
        public double DiscountPrice { get; set; }

        public bool BookInStock { get; set; }
        public BookCategory Category { get; set; }
        public BookWriter bookWriter { get; set; }



        public Bookk(string name, double price, double discountprice, bool bookInStock, BookCategory category,  BookWriter bookWriter)
        {
            _id++;
            Id = _id;
            Name = name;
            Price = price;
            DiscountPrice = discountprice;
            BookInStock = bookInStock;
            Category = category;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }
        public override string ToString()
        {

            if (DiscountPrice < Price)
            {
                return $"There is  {Price - DiscountPrice} DiscountPrice   Name: {Name}, Price: {DiscountPrice}, BookInStock:{BookInStock}, Category: {Category}, BookWriter: {bookWriter} ";
            }


            return $"Name: {Name} ,Price: {Price}, BookInStock{BookInStock}, Category: {Category}, BookWriter: {bookWriter} ";
        }
    }
}
