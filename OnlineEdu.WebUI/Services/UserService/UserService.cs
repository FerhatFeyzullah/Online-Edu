using Microsoft.AspNetCore.Identity;
using OnlineEdu.WebUI.DTOs.UserDTOs;
using OnlineEdu.WebUI.Models;

namespace OnlineEdu.WebUI.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;

        public UserService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public Task<bool> AssignRoleAsync(UserRoleDto userRoleDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateRoleAsync(UserRoleDto userRoleDto)
        {
            throw new NotImplementedException();
        }
        public async Task<IdentityResult> CreateUserAsync(UserRegisterDto userRegisterDto)
        {
            throw new NotImplementedException();
        }

      

        public async Task<List<ResultUserDto>> GetAllTeachers()
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserViewModel>> GetAllUserAsync()
        {
            return await _client.GetFromJsonAsync<List<UserViewModel>>("roleAssigns");
        }

       

        public async Task<List<AssignRoleDto>> GetUserForRoleAssign(int id)
        {
            return await _client.GetFromJsonAsync<List<AssignRoleDto>>($"roleAssigns/{id}");
        }

        public async Task<string> LoginAsync(UserLoginDto userLoginDto)
        {
            throw new NotImplementedException();
        }

        public async Task LogoutAsync()
        {
            throw new NotImplementedException();
        }


    }
}
