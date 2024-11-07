using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudyApi.Dto;
using StudyApi.Models;
using StudyApi.Services.User;

namespace StudyApi.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserInterface _userInterface;

        public UserController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        [HttpGet("users")]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> ListUsers()
        {
            var users = await _userInterface.ListUsers();
            return Ok(users);
        }

        [HttpGet("users/{idUser}")]
        public async Task<ActionResult<ResponseModel<UserModel>>> SearchUserById(int idUser)
        {
            var user = await _userInterface.SearchUserById(idUser);
            return Ok(user);

        }
        [HttpGet("users/{uUsername}")]
        public async Task<ActionResult<ResponseModel<UserModel>>> SearchUserByUsername(string uUsername)
        {
            var user = await _userInterface.SearchUserByUsername(uUsername);
            return Ok(user);

        }

        [HttpPost("users")]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> CreateUser(UserDto UserDto)
        {
            var users = await _userInterface.CreateUser(UserDto);
            return Ok(users);
        }

        [HttpPut("users")]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> EditUser(UserDto UserDto)
        {
            var users = await _userInterface.EditUser(UserDto);
            return Ok(users);
        }

        [HttpDelete("users")]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> DeleteUser(int idUser)
        {
            var users = await _userInterface.DeleteUser(idUser);
            return Ok(users);

        }
    }
}