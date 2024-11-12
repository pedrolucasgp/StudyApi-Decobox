using StudyApi.Dto;
using StudyApi.Models;

namespace StudyApi.Services.User
{
    public interface IUserInterface
    {
        Task<ResponseModel<List<UserModel>>> ListUsers();
        Task<ResponseModel<UserModel>> SearchUserById(int id);
        Task<ResponseModel<UserModel>> SearchUserByUsername(string username);
        Task<ResponseModel<List<UserModel>>> CreateUser(UserDto UserDto);
        Task<ResponseModel<List<UserModel>>> EditUser(UserDto UserDto);
        Task<ResponseModel<List<UserModel>>> DeleteUser(int id);
    }
}
