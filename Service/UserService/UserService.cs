using Microsoft.EntityFrameworkCore;
using WebAPI_Projeto01.DataContext;
using WebAPI_Projeto01.Models;

namespace WebAPI_Projeto01.Service.UserService
{
    public class UserService : IUserInterface
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context) 
        {
            _context = context;
        }
        
        public async Task<ServiceResponse<List<UserModel>>> ChangeStatusUser(int id)
        {
            ServiceResponse<List<UserModel>> serviceResponse = new ServiceResponse<List<UserModel>>();

            try
            {
                UserModel user = _context.Users.FirstOrDefault(x => x.Id == id);

                if (user == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "User not found";
                    serviceResponse.Status = "Error";
                    return serviceResponse;

                }

                user.Status = !user.Status;
                user.Updated_at = DateTime.Now.ToLocalTime();
                
                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Users.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Status = "Error";
                return serviceResponse;
            }
            serviceResponse.Message = "200";
            serviceResponse.Status = "Success";
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<UserModel>>> CreateUser(UserModel newUser)
        {
            ServiceResponse<List<UserModel>> serviceResponse = new ServiceResponse<List<UserModel>>();

            try
            {
                if (newUser == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar dados";
                    serviceResponse.Status = "Error";
                    return serviceResponse;

                }

                _context.Add(newUser);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Users.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Status = "Error";
                return serviceResponse;
            }
            serviceResponse.Message = "200";
            serviceResponse.Status = "Success";
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<UserModel>>> DeleteUser(int id)
        {
            ServiceResponse<List<UserModel>> serviceResponse = new ServiceResponse<List<UserModel>>();

            try
            {
                UserModel user = _context.Users.FirstOrDefault(x => x.Id == id);

                if (user == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "User not found";
                    serviceResponse.Status = "Error";
                    return serviceResponse;

                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Users.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Status = "Error";
                return serviceResponse;
            }
            serviceResponse.Message = "200";
            serviceResponse.Status = "Success";
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserModel>> GetUserById(int id)
        {
            ServiceResponse<UserModel> serviceResponse = new ServiceResponse<UserModel>();

            try
            {
                UserModel user = _context.Users.FirstOrDefault(x => x.Id == id);

                if (user == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "User not found";
                    serviceResponse.Status = "Error";
                    return serviceResponse;

                }

                serviceResponse.Data = user;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Status = "Error";
                return serviceResponse;
            }
            serviceResponse.Message = "200";
            serviceResponse.Status = "Success";
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<UserModel>>> GetUsers()
        {
            ServiceResponse<List<UserModel>> serviceResponse = new ServiceResponse<List<UserModel>>();
            try
            {
               serviceResponse.Data = _context.Users.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Status = "Error";
            }
            serviceResponse.Message = "200";
            serviceResponse.Status = "Success";
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<UserModel>>> UpdateUser(UserModel editUser)
        {
            ServiceResponse<List<UserModel>> serviceResponse = new ServiceResponse<List<UserModel>>();

            try
            {
                UserModel user = _context.Users.AsNoTracking().FirstOrDefault(x => x.Id == editUser.Id);

                if (user == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "User not found";
                    serviceResponse.Status = "Error";
                    return serviceResponse;

                }

                user.Updated_at = DateTime.Now.ToLocalTime();

                _context.Users.Update(editUser);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Users.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Status = "Error";
                return serviceResponse;
            }
            serviceResponse.Message = "200";
            serviceResponse.Status = "Success";
            return serviceResponse;
        }
    }
}
