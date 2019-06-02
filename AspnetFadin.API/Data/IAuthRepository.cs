using System.Threading.Tasks;
namespace AspnetFadin.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);
         Task<User> Login(string username, string password);
         // Cуществует ли пользователь в базе данных
         Task<bool> UserExists(string username);

    }
}