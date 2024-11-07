using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using StudyApi.Data;
using StudyApi.Dto;
using StudyApi.Models;

namespace StudyApi.Services.User
{
    public class UserService : IUserInterface
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<ResponseModel<List<UserModel>>> CreateUser(UserDto UserDto)
        {
            ResponseModel<List<UserModel>> response = new ResponseModel<List<UserModel>>();

            try
            {
                var user = new UserModel()
                {
                    FullName = UserDto.FullName,
                    Email = UserDto.Email,
                    Password = UserDto.Password,
                    Username = UserDto.Username
                };

                _context.Add(user);
                await _context.SaveChangesAsync();

                response.Data = await _context.Users.ToListAsync();
                response.Message = "User successfully created";

                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }


        public async Task<ResponseModel<List<UserModel>>> ListUsers()
        {
            ResponseModel<List<UserModel>> response = new ResponseModel<List<UserModel>>();
            try
            { 
                var users = await _context.Users.ToListAsync();

                response.Data = users;
                response.Message = "All users have been loaded";

                return response;


            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<UserModel>> SearchUserById(int idUser)
        {
            ResponseModel<UserModel> response = new ResponseModel<UserModel>();
            try
            { 
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == idUser);

                if (user == null) {
                    response.Message = "User not found";
                    response.Status = false;

                    return response;
                }

                response.Data = user;
                response.Message = "User found";
                return response;

            }
            catch (Exception ex) 
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<UserModel>> SearchUserByUsername(string uUsername)
        {
            ResponseModel<UserModel> response = new ResponseModel<UserModel>();
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(x => x.Username == uUsername);

                if (user == null)
                {
                    response.Message = "User not found";
                    response.Status = false;

                    return response;
                }

                response.Data = user;
                response.Message = "User found";
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<UserModel>>> DeleteUser(int idUser)
        {
            ResponseModel<List<UserModel>> response = new ResponseModel<List<UserModel>>();

            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == idUser);
               

                if(user == null)
                {
                    response.Message = "User not found";
                    response.Status= false;
                    return response;
                }

                _context.Remove(user);
                await _context.SaveChangesAsync();

                response.Data = await _context.Users.ToListAsync();
                response.Message = "User successfully deleted";

                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<UserModel>>> EditUser(UserDto UserDto)
        {
            ResponseModel<List<UserModel>> response = new ResponseModel<List<UserModel>>();

            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == UserDto.Id);

                if(user == null)
                {
                    response.Message = "User not found";
                    response.Status= false;
                    return response;
                }

                user.FullName = UserDto.FullName;
                user.Username = UserDto.Username;
                user.Email = UserDto.Email;
                user.Password = UserDto.Password;

                _context.Update(user);
                await _context.SaveChangesAsync();

                response.Data = await _context.Users.ToListAsync();
                response.Message = "User successfully edited";

                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

    }
}
