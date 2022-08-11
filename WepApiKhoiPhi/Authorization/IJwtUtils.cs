using WepApiKhoiPhi.Models;

namespace WepApiKhoiPhi.Authorization
{
    public interface IJwtUtils
    {
        public string GenerateToken(User user);
        public int? ValidateToken(string token);
    }
}