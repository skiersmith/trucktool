using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
    [Route("[controller]")]
    public class AccountsController : Controller
    {
        private readonly UserRepository _db;

        public AccountsController(UserRepository repo)
        {
            _db = repo;
        }

        [HttpPost("register")]
        public async Task<UserReturnModel> Register([FromBody]RegisterUserModel creds)
        {
            if (ModelState.IsValid)
            {
                UserReturnModel user = _db.Register(creds);
                if (user != null)
                {
                    ClaimsPrincipal principal = user.SetClaims();
                    await HttpContext.SignInAsync(principal);
                    return user;
                }
                else
                {
                    return null;

                }
            }
            else
            {
                return null;
            }
        }

        [HttpPost("login")]
        public async Task<UserReturnModel> Login([FromBody]LoginUserModel creds)
        {
            if (ModelState.IsValid)
            {
                UserReturnModel user = _db.Login(creds);
                if (user != null)
                {
                    ClaimsPrincipal principal = user.SetClaims();
                    await HttpContext.SignInAsync(principal);
                    return user;
                }
            }
            return null;
        }
        [HttpGet("authenticate")]
        public UserReturnModel Authenticate()
        {
            var user = HttpContext.User;
            var id = user.Identity.Name;
            // var email = user.Claims.Where(c => c.Type == ClaimTypes.Email)
            //        .Select(c => c.Value).SingleOrDefault();
            var getUser = _db.GetUserById(id);
           
            if (getUser != null)
            {
                return getUser;
            }
            else{
                return null;
            }

        }

        [Authorize]
        [HttpPut]
        public UserReturnModel UpdateAccount([FromBody]UserReturnModel user)
        {
            var email = HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Email)
                   .Select(c => c.Value).SingleOrDefault();
            var sessionUser = _db.GetUserByEmail(email);

            if (sessionUser.Id == user.Id)
            {
                return _db.UpdateUser(user);
            }
            return null;
        }

        [Authorize]
        [HttpPut("change-password")]
        public string ChangePassword([FromBody]ChangeUserPasswordModel user)
        {
            if (ModelState.IsValid)
            {
                var email = HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Email)
                       .Select(c => c.Value).SingleOrDefault();
                var sessionUser = _db.GetUserByEmail(email);

                if (sessionUser.Id == user.Id)
                {
                    return _db.ChangeUserPassword(user);
                }
            }
            return "How did you even get here?";
        }
        // [HttpPost("logout")]
        // public void Logout([FromBody]LoginUserModel creds)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         UserReturnModel user = _db.Login(creds);
        //         if (user != null)
        //         {
        //             HttpContext.Session.Clear();
        //         }
        //     }

        // }
        [HttpDelete("logout")]
        public async void Logout()
        {
            await HttpContext.SignOutAsync();
        }



    }
}