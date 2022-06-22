﻿using Business.Concrete;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PickBazar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly TokenManager tokenManager;
        private readonly UserManager<PickBazarUser> _userManager;

        public AccountController(UserManager<PickBazarUser> userManager, TokenManager tokenManager)
        {
            _userManager = userManager;
            this.tokenManager = tokenManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            var user = new PickBazarUser
            {
                Email=registerDTO.Email,
                Firstname=registerDTO.Firstname,
                Lastname=registerDTO.Lastname,
                UserName=registerDTO.Email
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return ValidationProblem();

            }
            await _userManager.AddToRoleAsync(user, "Visitor");
            return Ok(new { status = 201, message = "Register successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var user = await _userManager.FindByNameAsync(loginDTO.Email);
            var checkPass = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
            if(user==null || !checkPass)
            {
                return Unauthorized();
            }

            var token = await tokenManager.GenerateToken(user);
            var roles=await _userManager.GetRolesAsync(user);
            if (!roles.Any())
            {
                return BadRequest();
            }
            if (roles.Any(c => c== "Admin"))
            {
                return Ok(new { IsAdmin = true, email = user.Email, token });
            }
            return Ok(new { email = user.Email, token });
        }

    }
}
