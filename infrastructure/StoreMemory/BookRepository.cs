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
                "Кнут рассматривает программирование не как ремесло, а как искусство (art) и науку. Основная цель серии — систематизировать и предоставить глубокий математический анализ основных алгоритмов, которые составляют основу всех компьютерных программ.\r\n\r\nГлавный посыл: чтобы быть настоящим мастером программирования, необходимо понимать не только как работает алгоритм, но и почему он работает, какова его эффективность (с математической точки зрения) и в каких случаях его следует применять.",
                7.19m),
            new Book(2, "ISBN 12312-31232", "M. Fowler", "Refactoring",
                "Рефакторинг — это контролируемый процесс улучшения структуры существующего кода без изменения его внешнего поведения.\r\n\r\nОсновной посыл: код — это живой организм, который нужно постоянно улучшать, чтобы он оставался чистым, понятным и легким для изменения.",
                12.45m),
            new Book(3, "ISBN 12312-31233", "B. Kernighan, D.Ritchie", "C Programming Language",
                "Деннис Ритчи — создатель языка C и один из создателей операционной системы UNIX. Фактически, книга написана создателем языка — это первоисточник в чистом виде.",
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
