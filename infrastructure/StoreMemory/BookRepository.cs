using System;
using System.Data;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {

        private readonly Book[] books = new[]
        {
            new Book(1, "ISBN 12312-31231", "D. Knuth", "Art Of Programming",
                "The bible of all fundamental algorithms and the work that taught many of today’s software developers most of what they know about computer programming.",
                7.19m),
            new Book(2, "ISBN 12312-31232", "M. Fowler", "Refactoring",
                "The book \"Refactoring: Improving the Design of Existing Code\" by Martin Fowler is a fundamental work that has changed the way programmers approach code. It's not just a book, but a guide to action.",
                12.45m),
            new Book(3, "ISBN 12312-31233", "B. Kernighan, D.Ritchie", "C Programming Language",
                "Dennis Ritchie is the creator of the C language, and both authors developed the UNIX operating system. In fact, the C language was created to rewrite UNIX. This makes the book a primary source written by the creators of the language themselves.",
                14.98m),
        };

        public Book[] GetAllByIds(IEnumerable<int> bookIds)
        {
            var foundBooks = from book in books
                             join bookId in bookIds on book.Id equals bookId
                             select book;

            return foundBooks.ToArray();
        }

        public Book[] GetAllByIsbn(string isbn) 
        {
            return books.Where(book => book.Isbn == isbn)
                        .ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return books.Where(book => book.Author.Contains(query) 
                                    || book.Title.Contains(query))
                        .ToArray();
        }

        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }
    }
}
