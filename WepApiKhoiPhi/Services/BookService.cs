using System;
using System.Collections.Generic;
using System.Linq;
using WepApiKhoiPhi.DbContext;
using WepApiKhoiPhi.Dtos;
using WepApiKhoiPhi.Models;
using WepApiKhoiPhi.Services.IServices;

namespace WepApiKhoiPhi.Services
{
    public class BookService: IBookService
    {
        private readonly ApplicationDbContext _db;

        public BookService(ApplicationDbContext db)
        {
            _db = db;
        }
        public IList<Book> GetAll()
        {
            return _db.Books.ToList();
        }

        public Book GetById(int id)
        {
            try
            {
                var book = _db.Books.FirstOrDefault(x => x.Id == id);
                if (book == null)
                    throw new NullReferenceException();
                return book;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Book Create(Book bookInput)
        {
            try
            {
                // validation
                _db.Books.Add(bookInput);
                _db.SaveChanges();
                return bookInput;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Book Update(Book bookInput)
        {
            try
            {
                _db.Books.Update(bookInput);
                _db.SaveChanges();
                return bookInput;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var book = _db.Books.FirstOrDefault(x => x.Id == id);
                if (book == null)
                    return false;
            
                _db.Books.Remove(book);
                _db.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}