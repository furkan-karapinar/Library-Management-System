using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class Catalog
    {
        public List<Category> Categories { get; set; }

        public Catalog()
        {
            Categories = new List<Category>();
        }


        #region Category
        public void Add_Category(Category category)
        {
            Categories.Add(category);
        }
        public void Delete_Category(string category_name)
        {
            var category = Categories.Find(k => k.Name == category_name);
            if (category != null)
            {
                Categories.Remove(category);
            }
            else
            {
                Console.WriteLine("Hata: Kategori bulunamadı.");
            }
        }
        public List<Category> Find_Category(string keyword)
        {
            return Categories.FindAll(category => category.Name.Contains(keyword));
        }
        public void View_Category()
        {
            foreach (var category in Categories)
            {
                Console.WriteLine($"Kategori: {category.Name}");
                foreach (var book in category.Books)
                {
                    Console.WriteLine($"  - {book.Title} - {book.Author}");
                }
            }
        }

        #endregion

        #region Book
        public void Add_Book(string category_name, Book book)
        {
            var category = Categories.Find(k => k.Name == category_name);
            if (category != null)
            {
                category.Books.Add(book);
            }
            else
            {
                Console.WriteLine("Hata: Kategori bulunamadı.");
            }
        }
        public void Delete_Book(string category_name, string book_title)
        {
            var category = Categories.Find(k => k.Name == category_name);
            if (category != null)
            {
                var book = category.Books.Find(k => k.Title == book_title);
                if (book != null)
                {
                    category.Books.Remove(book);
                }
                else
                {
                    Console.WriteLine("Hata: Kitap bulunamadı.");
                }
            }
            else
            {
                Console.WriteLine("Hata: Kategori bulunamadı.");
            }
        }
        public List<Book> Find_Book(string keyword)
        {
            List<Book> Found_Books = new List<Book>();

            foreach (var category in Categories)
            {
                var books = category.Books.FindAll(k => k.Title.Contains(keyword) || k.Author.Contains(keyword));
                Found_Books.AddRange(books);
            }

            return Found_Books;
        }

        #endregion
    }
}
