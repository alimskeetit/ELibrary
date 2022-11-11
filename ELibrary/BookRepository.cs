using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary
{
    public class BookRepository
    {
        ELibrary.AppContext db;
        public BookRepository()
        {

        }

        public BookRepository(ELibrary.AppContext db)
        {
            this.db = db;
        }

        public Book Select(int id)
        {
            return db.Books.FirstOrDefault(book => book.Id == id);
        }

        public List<Book> SelectAll()
        {
            return db.Books.ToList();
        }

        public void Add(Book book)
        {
            db.Add(book);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(db.Books.FirstOrDefault(book => book.Id == id));
            db.SaveChanges();
        }

        public void UpdateYear(int id, int year)
        {
            db.Books.FirstOrDefault(book => book.Id == id).Year = year;
            db.SaveChanges();
        }

        public List<Book> BooksByGenre(string genre)
        {
             return db.Books.Select(book => book).Where(book => book.Genre == genre).ToList();
        }

        public List<Book> BooksByYear(int from, int to = 9999)
        {
            return db.Books.Select(book => book).Where(book => from <= book.Year || book.Year <= to).ToList();
        }

        public List<Book> BooksByAuthor(string author)
        {
            return db.Books.Select(book => book).Where(book => book.Author.Name == author).ToList();
        }

        public int CountOfBooksByGenre(string genre)
        {
            return BooksByGenre(genre).Count;
        }

        public int CountOfBooksByAuthor(string author)
        {
            return BooksByAuthor(author).Count;
        }

        public bool HasBook(string title, string author)
        {
            return !db.Books.Select(book => book).Where(book => book.Name == title && book.Author.Name == author).IsNullOrEmpty();
        }

        public bool HasUserBook(int userId, int bookId)
        {
            var book = db.Books.FirstOrDefault(book => book.Id == bookId);
            return book.UserId == userId;
        }

        public List<Book> AllBooksSortedByTitle()
        {
            return db.Books.Select(book => book).OrderBy(book => book.Name).ToList();
        }

        public List<Book> AllBooksSortedByYear()
        {
            return db.Books.Select(book => book).OrderByDescending(book => book.Year).ToList();
        }

    }
}
