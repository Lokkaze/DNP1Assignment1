using DNP1Assignment1.Models;

namespace DNP1Assignment1.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string Password);
    }
}