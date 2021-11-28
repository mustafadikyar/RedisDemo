using RedisDemo.Models;
using System.Threading.Tasks;

namespace RedisDemo.Services
{
    public interface IUserService
    {
        Task<UserDTO> Get(string userId);
        Task<bool> SaveOrUpdate(UserDTO model);
        Task<bool> Delete(string userId);
    }
}
