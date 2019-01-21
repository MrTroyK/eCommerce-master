using System.Threading.Tasks;
using Model.Model;

namespace eCommerce.Repositories.Interfaces
{
    public interface IUserService
    {
        Task<bool> Authenticate(string firstname, string password);
        User Create(User user);
        bool Delete(User user);

    }

}
