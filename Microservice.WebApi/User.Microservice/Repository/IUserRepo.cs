using ApiCommonLibrary;
using System.Threading.Tasks;
using User.Microservice.DTO;

namespace User.Microservice.Repository
{
    public interface IUserRepo
    {
        public Task<ServiceResponse<dynamic>> Register(AddUserDto addUserDto);
        public Task<bool> IsEmailExist(string email);
    }
}
