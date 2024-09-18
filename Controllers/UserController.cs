using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Projeto01.Models;
using WebAPI_Projeto01.Service.UserService;

namespace WebAPI_Projeto01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface _userInterface;
        
        public UserController(IUserInterface userInterface) 
        {
            _userInterface = userInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<UserModel>>>> GetUsers()
        {
            return Ok(await _userInterface.GetUsers());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<UserModel>>>> CreateUser(UserModel newUser)
        {
            return Ok(await _userInterface.CreateUser(newUser));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<UserModel>>> GetUserById(int id)
        {
            ServiceResponse<UserModel> serviceResponse = await _userInterface.GetUserById(id);
            return Ok(serviceResponse);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<UserModel>>>> UpdateUser(UserModel editUser)
        {
            ServiceResponse<List<UserModel>> serviceResponse = await _userInterface.UpdateUser(editUser);

            return Ok(serviceResponse);
        }

        [HttpPut("changeStatus")]
        public async Task<ActionResult<ServiceResponse<List<UserModel>>>> ChangeStatusUser(int id)
        {
            ServiceResponse<List<UserModel>> serviceResponse = await _userInterface.ChangeStatusUser(id);

            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<UserModel>>>> DeleteUser(int id)
        {
            ServiceResponse<List<UserModel>> serviceResponse = await _userInterface.DeleteUser(id);

            return Ok(serviceResponse);
        }
    }
}
