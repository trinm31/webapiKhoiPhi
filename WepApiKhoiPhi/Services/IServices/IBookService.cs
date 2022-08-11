using System.Collections.Generic;
using WepApiKhoiPhi.Dtos;
using WepApiKhoiPhi.Models;

namespace WepApiKhoiPhi.Services.IServices
{
    public interface IBookService
    {
        IList<Book> GetAll();
        Book GetById(int id);
        Book Create(Book bookInput);
        Book Update(Book bookInput);
        bool Delete(int id);
    }
}