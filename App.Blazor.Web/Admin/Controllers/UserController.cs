using App.Business.Model;
using App.Business.Services;
using App.DbAccess.Entities.Identity;
using App.EFCore.DynamicLinq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.Blazor.Web.Admin.Controllers
{

    [ApiController]
    [ApiExplorerSettings(GroupName = "admin")]
    [Area("admin")]
    [Authorize]
    [Route("api/[area]/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserService _userService;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }

        [HttpPost]
        public async Task<bool> AddUser(UserModel model)
        {
            var user = new User { UserName = model.UserName };
            var result = await _userManager.CreateAsync(user);
            return result.Succeeded;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DelUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new BadHttpRequestException("�û������ڡ�");
            }
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateUser(UserModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                throw new BadHttpRequestException("�û������ڡ�");
            }
            user.UserName = model.UserName;
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        [HttpGet("{id}")]
        public async Task<UserModel> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new BadHttpRequestException("�û������ڡ�");
            }
            var result = new UserModel { Id = user.Id, UserName = user.UserName };
            return result;
        }

        [HttpGet]
        public Task<PageResult<List<UserModel>>> GetUsers([FromQuery] UserQueryModel model)
        {
            return _userService.GetUsersAsync(model);
        }

    }
}
