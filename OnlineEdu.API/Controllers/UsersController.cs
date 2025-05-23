using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.Business.Interface;
using OnlineEdu.DTO.DTOs.AppUserDTOs;
using OnlineEdu.DTO.DTOs.UserDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager,
        IJwtService _jwtService, IMapper _mapper, IUserService _userService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest("Kullanıcı Bulunamadı");
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (!result.Succeeded)
            {
                return BadRequest("Email Veya Şifre Hatalı");
            }
            
            var token = await _jwtService.CreateTokenAsync(user);
            return Ok(token);

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
        var user = _mapper.Map<AppUser>(model);
            if (ModelState.IsValid) 
            {
            var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                return BadRequest(result.Errors);
                }
                await _userManager.AddToRoleAsync(user, "Student");
                return Ok("Kullanıcı Kaydı Basarili");

            }

            return BadRequest(ModelState);
        }
        [HttpGet("TeacherList")]
        public async Task<IActionResult> TeacherList() 
        {
            var values = await _userManager.GetUsersInRoleAsync("Teacher");
            return Ok(values);
        }
        [HttpGet("StudentList")]
        public async Task<IActionResult> StudentList()
        {
            var values = await _userManager.GetUsersInRoleAsync("Student");
            return Ok(values);
        }

        [HttpGet("Get3Teachers")]
        public async Task<IActionResult> Get3Teachers() 
        {
            var values = await _userService.Get3Teachers();
            return Ok(values);
        }
        [HttpGet("GetAllTeacher")]
        public async Task<IActionResult> GetAllTeachers()
        {
            var values = await _userService.GetAllTeachers();
            return Ok(values);
        }
        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(int id) 
        {
        var value = await _userService.GetUserById(id);
            if (value == null)
            {
                return NotFound("Kullanıcı Bulunamadı");
            }
            return Ok(value);

        }

    }
}
