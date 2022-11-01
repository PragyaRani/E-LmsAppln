using ApiCommonLibrary;
using System;
using System.Threading.Tasks;
using User.Microservice.Data;
using User.Microservice.DTO;
using User.Microservice.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace User.Microservice.Repository
{
    public class Userrepo : IUserRepo
    {
        DataContext dataContext;
        public Userrepo(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }

        public async Task<bool> IsEmailExist(string email)
        {
            var data = await dataContext.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
            if(data == null)
            {
                return false;
            }
            return true;
        }

        public async Task<ServiceResponse<dynamic>> Register(AddUserDto addUserDto)
        {
            try
            {
                if (!await IsEmailExist(addUserDto.Email))
                {
                    AddUser user =new AddUser()
                    {
                        Name = addUserDto.Name,
                        Address = addUserDto.Address,
                        City = addUserDto.City,
                        Pin = addUserDto.Pin.ToString(),
                        State = addUserDto.State,
                        Phone = addUserDto.Phone.ToString(),
                        Email = addUserDto.Email,
                        Password = addUserDto.Password,
                    };
                    dataContext.Users.Add(user);
                    await dataContext.SaveChangesAsync();
                    return new ServiceResponse<dynamic>() {
                        Data = user.UserId
                    };
                }
                return new ServiceResponse<dynamic>()
                {
                    Success = false,
                    Message = "Email Id is already exist"
                };

            }
            catch(Exception ex)
            {
                return new ServiceResponse<dynamic>()
                {
                    Success = false,
                   Message = ex.Message
                };
            }
        }
    }
}
