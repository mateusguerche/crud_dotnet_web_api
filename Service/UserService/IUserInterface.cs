using WebAPI_Projeto01.Models;

namespace WebAPI_Projeto01.Service.UserService
{
    public interface IUserInterface
    {
        Task<ServiceResponse<List<UserModel>>> GetUsers();
        Task<ServiceResponse<List<UserModel>>> CreateUser(UserModel newUser);
        Task<ServiceResponse<UserModel>> GetUserById(int id);
        Task<ServiceResponse<List<UserModel>>> UpdateUser(UserModel editUser);
        Task<ServiceResponse<List<UserModel>>> DeleteUser(int id);
        Task<ServiceResponse<List<UserModel>>> ChangeStatusUser(int id);


    }
}
