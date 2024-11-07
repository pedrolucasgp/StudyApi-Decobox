using StudyApi.Dto;
using StudyApi.Models;

namespace StudyApi.Services.User
{
    public interface IUserInterface
    {
        Task<ResponseModel<List<UserModel>>> ListUsers();
        Task<ResponseModel<UserModel>> SearchUserById(int idUser);
        Task<ResponseModel<UserModel>> SearchUserByUsername(string uUsername);
        Task<ResponseModel<List<UserModel>>> CreateUser(UserDto UserDto);

        Task<ResponseModel<List<UserModel>>> EditUser(UserDto UserDto);
        Task<ResponseModel<List<UserModel>>> DeleteUser(int idUser);
    }
}
