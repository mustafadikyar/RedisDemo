using RedisDemo.Models;
using System.Text.Json;
using System.Threading.Tasks;

namespace RedisDemo.Services
{
    public class UserManager : IUserService
    {
        private readonly RedisService _redisService;
        public UserManager(RedisService redisService) => _redisService = redisService;

        public async Task<bool> Delete(string userId) => await _redisService.GetDb().KeyDeleteAsync(userId);

        public async Task<UserDTO> Get(string userId)
        {
            var isExist = await _redisService.GetDb().StringGetAsync(userId);

            if (!string.IsNullOrEmpty(isExist))
                return JsonSerializer.Deserialize<UserDTO>(isExist);

            return null;
        }

        public async Task<bool> SaveOrUpdate(UserDTO model) => await _redisService.GetDb().StringSetAsync(model.Id, JsonSerializer.Serialize(model));
    }
}
