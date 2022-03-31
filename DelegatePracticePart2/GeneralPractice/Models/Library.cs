using GeneralPractice.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Exceptions;

namespace GeneralPractice.Models
{
    internal class Library : IEntity
    {
        private static int _id;
        public int Id { get; }
        public int BookLimit { get; set; }
        private List<Book> _books;

        public Library(int bookLimit)
        {
            _books = new List<Book>();
            _id++;
            Id = _id; 
            BookLimit = bookLimit;
        }

        public void AddBook(Book book)
        {
            if (book == null)
                throw new NullReferenceException("Book null ola bilmez");

            if (_books.Exists(m => m.Name == book.Name && !m.IsDeleted))
                throw new AlreadyExistsException("Artiq var!");

            if (_books.Count < BookLimit)
            {
                _books.Add(book);
                return;
            }

            throw new CapacityLimitException("Limit doldu daha!");
        }//DONE

        public Book GetBookById(int? id)
        {
            if (id == null)
                throw new NullReferenceException("id null ola bilmez");
            Book book = _books.Find(m => !m.IsDeleted && m.Id == id);
            if (book!=null)
            {
                return book;
            }
            return null;
            //return _medicines.Find(m => !m.IsDeleted && m.Id == id);
        }//DONE

        public List<Book> GetAllBooks()
        {
            List<Book> booksCopy= new List<Book>();
            booksCopy.AddRange(_books.FindAll(m => !m.IsDeleted));
            return booksCopy;
        }// isdeleted qaldi

        public void DeleteBookById(int? id)
        {
            if (id == null)
                throw new NullReferenceException("id null ola bilmez");

            Book book = _books.Find(m => !m.IsDeleted && m.Id == id);
            if (book == null)
                throw new NotFoundException("bele bir book yoxdur");

            book.IsDeleted = true;
        }//DONE

        public void EditMedicineName(int? id, string name)
        {
            if (id == null || string.IsNullOrWhiteSpace(name))
                throw new NullReferenceException("Id ve Name deyeri null ola bilmez!");
            Book book = _books.Find(m => !m.IsDeleted && m.Id == id);
            if (book == null)
                throw new NotFoundException("Axtardiginiz book burda yoxdur!");
            book.Name = name;
        }// done    

        public List<Book> FilterBooksByCount(double minCount, double maxCount)
        {
            return _books.FindAll(m => !m.IsDeleted && m.PageCount >= minCount && m.PageCount <= maxCount);
        }
    }
}
