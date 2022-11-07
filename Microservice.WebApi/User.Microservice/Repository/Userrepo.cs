using ApiCommonLibrary;
using System;
using System.Threading.Tasks;
using User.Microservice.Data;
using User.Microservice.DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ApiCommonLibrary.Models;
using ApiCommonLibrary.DTO;
using Microsoft.Extensions.Configuration;

namespace User.Microservice.Repository
{
    public class Userrepo : IUserRepo
    {
        DataContext dataContext;
        IConfiguration configuration;
        public Userrepo(DataContext _dataContext, IConfiguration _configuration)
        {
            dataContext = _dataContext;
            configuration = _configuration;
        }

        public async Task<bool> IsEmailExist(string email)
        {
            var data = await dataContext.Students.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
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
                    EStudent user =new EStudent()
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
                    dataContext.Students.Add(user);
                    await dataContext.SaveChangesAsync();
                   
                    return new ServiceResponse<dynamic>() {
                       
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

        public async Task<ServiceResponse<dynamic>> Login(SignInDto signInDto)
        {
            var user = await dataContext.Students.FirstOrDefaultAsync(
             x => x.Email == signInDto.Username && x.Password == signInDto.Password);
            if (user == null)
            {
                return new ServiceResponse<dynamic>
                {
                    Success = false,
                    Message = "Username or Password is wrong"
                };
            }
            UserResponseDto userRes = new UserResponseDto
            {
                Name = user.Name,
                Token = new TokenInfo().CreateToken(new UserResponse
                    { UserId = user.StudentId, Email = user.Email, Role = user.Role },
                        configuration.GetSection("AppSettings:Token").Value),
                Username = user.Email,
                Role = user.Role
            };
            return new ServiceResponse<dynamic>()
            {
                Data = userRes
            };
        }
    }
}
