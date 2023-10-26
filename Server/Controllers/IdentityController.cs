using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WishVine.Server.Data;
using WishVine.Shared;
using WishVine.Shared.Identity;

namespace WishVine.Server.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class IdentityController:ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IdentityController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [ActionName("Login")]
        public async Task<IActionResult> LoginAsync(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null) return BadRequest("User does not exist");
            var singInResult = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!singInResult.Succeeded) return BadRequest("Invalid password");

            await _signInManager.SignInAsync(user, model.RememberMe);

            return Ok();

        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterParameters parameters)
        {
            var user = new ApplicationUser
            {
                UserName = parameters.UserName ,
                Email = parameters.UserName
            };

            var result = await _userManager.CreateAsync(user, parameters.Password!);

            if (!result.Succeeded) return BadRequest(result.Errors.FirstOrDefault()?.Description);

            //sign the user in after successful registration
            return await LoginAsync(new LoginModel
            {
                UserName = parameters.UserName!,
                Password = parameters.Password!,
            });
        }

        [HttpGet]
        public UserInfo UserInfo()
        {
            //var user = await _userManager.GetUserAsync(HttpContext.User);
            var info = new UserInfo(this.User);
            return info;
        }

    }

}
