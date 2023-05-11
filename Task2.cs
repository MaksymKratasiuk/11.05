using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._05
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"{Title} ({Author}, {Year}) - {Genre}";
        }
    }
    internal class Task2
    {
        public static void task2()
        {
            LinkedList<Book> books = new LinkedList<Book>();

            // Додавання книг
            books.AddLast(new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Classics", Year = 1960 });
            books.AddLast(new Book { Title = "1984", Author = "George Orwell", Genre = "Dystopian Fiction", Year = 1949 });
            books.AddLast(new Book { Title = "Brave New World", Author = "Aldous Huxley", Genre = "Dystopian Fiction", Year = 1932 });

            // Видалення книги з початку списку
            books.RemoveFirst();

            // Видалення книги з кінця списку
            books.RemoveLast();

            // Зміна інформації про книгу
            LinkedListNode<Book> node = books.First;
            while (node != null)
            {
                if (node.Value.Title == "1984")
                {
                    node.Value.Genre = "Science Fiction";
                }
                node = node.Next;
            }

            // Пошук книг за параметрами
            LinkedList<Book> results = new LinkedList<Book>();
            node = books.First;
            while (node != null)
            {
                if (node.Value.Author == "Harper Lee" && node.Value.Year > 1950)
                {
                    results.AddLast(node.Value);
                }
                node = node.Next;
            }

            // Вставка книги у певну позицію
            node = books.First;
            while (node != null)
            {
                if (node.Value.Title == "To Kill a Mockingbird")
                {
                    books.AddBefore(node, new Book { Title = "Animal Farm", Author = "George Orwell", Genre = "Political Satire", Year = 1945 });
                }
                node = node.Next;
            }

            // Виведення книг у консоль
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
