using System.Collections.Generic;
using System.Threading.Tasks;
using WepApiKhoiPhi.Dtos.UserDtos;
using WepApiKhoiPhi.Models;

namespace WepApiKhoiPhi.Services.IServices
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task Register(RegisterRequest model);
        Task Update(int id, UpdateRequest model);
        Task Delete(int id);
    }
}