using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudyApi.Dto;
using StudyApi.Models;
using StudyApi.Services.User;

namespace StudyApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserInterface _userInterface;

        public UserController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        [Authorize]
        [HttpGet("users")]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> ListUsers()
        {
            var users = await _userInterface.ListUsers();
            return Ok(users);
        }

        [Authorize]
        [HttpGet("users/id/{id}")]
        public async Task<ActionResult<ResponseModel<UserModel>>> SearchUserById(int id)
        {
            var user = await _userInterface.SearchUserById(id);
            return Ok(user);

        }

        [Authorize]
        [HttpGet("users/{username}")]
        public async Task<ActionResult<ResponseModel<UserModel>>> SearchUserByUsername(string username)
        {
            var user = await _userInterface.SearchUserByUsername(username);
            return Ok(user);

        }

        [HttpPost("users")]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> CreateUser(UserDto UserDto)
        {
            var users = await _userInterface.CreateUser(UserDto);
            return Ok(users);
        }

        [Authorize]
        [HttpPut("users")]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> EditUser(UserDto UserDto)
        {
            var users = await _userInterface.EditUser(UserDto);
            return Ok(users);
        }

        [Authorize]
        [HttpDelete("users")]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> DeleteUser(int id)
        {
            var users = await _userInterface.DeleteUser(id);
            return Ok(users);

        }
    }
}