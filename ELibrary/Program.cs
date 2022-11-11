using ELibrary;
using System.Reflection.PortableExecutable;

class Program
{
    static void Main()
    {
        using (var db = new ELibrary.AppContext())
        {
            UserRepository userRepository = new UserRepository(db);
            BookRepository bookRepository = new BookRepository(db);

            var user1 = new User { Name = "Sofia", Email = "Sofia@yandex.ru" };
            var user2 = new User { Name = "Nikita", Email = "nikitos@yandex.ru" };
            
            var author1 = new Author { Name = "A.S. Pushkin" };
            var author2 = new Author { Name = "I.D. Alimskiy" };

            var book1 = new Book { Name = "Some realshit book", Author = author1, Genre = "meme", Year = 2022 };
            var book2 = new Book { Name = "Unbelievable shit", Author = author2, Genre = "PunkrockMeme", Year = 2024 };
            var book3 = new Book { Name = "What da heeell??", Author = author2, Genre = "meme", Year = 3000 };

            user1.Books.Add(book1);
            user2.Books.AddRange(new[] { book2, book3 });

            userRepository.Add(user1);
            userRepository.Add(user2);

            db.SaveChanges();
            Console.WriteLine(bookRepository.HasBook("Some realshit book", "A.S. Pushkin"));

            foreach (var item in bookRepository.BooksByGenre("meme"))
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine(bookRepository.HasUserBook(1, 1));
            Console.WriteLine(userRepository.CountOfBooks(1));

            Console.WriteLine("Книги, отсортированные в алфавитном порядке: ");
            foreach (var item in bookRepository.AllBooksSortedByTitle())
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("Книги, отсортированные по году: ");
            foreach (var item in bookRepository.AllBooksSortedByYear())
            {
                Console.WriteLine(item.Name + " " + item.Year);
            }
        }
    }
}