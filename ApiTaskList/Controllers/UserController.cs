using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskList2.Models;
using TaskList2.Context;
using TaskList2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using TaskList2.Repositories.Abstract;
using AutoMapper;
using TaskList2.Controllers.Abstract;

namespace TaskList2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiCrudControllerBase<User, UserModel>
    {
        public UserController(IUserRepository rep, IMapper mapper) : base(mapper)
        {
            this.rep = rep;
        }
        [HttpPost("SendKeyEmail")]
        public IActionResult SendKeyEmail(Guid Id, UserModel user)
        {
            var keyGenerator = new KeyGenerator();
            var emailService = new EmailService();
            int key = keyGenerator.GenerateKey();
            Program.waitKeyConfirmations.Add(new WaitKeyConfirmation(Id, key));
            emailService.SendEmailWithCode(user, key);
            return Ok();
        }
        [HttpPost("KeyActivate")]
        public async Task<ActionResult<WaitKeyConfirmation>> PostKeyActivate(WaitKeyConfirmation waitKeyConfirmation)
        {
            foreach (WaitKeyConfirmation users in Program.waitKeyConfirmations)
            {
                if (users.UserId == waitKeyConfirmation.UserId)

                {
                    if (users.Key == waitKeyConfirmation.Key)
                    {
                        var user = rep.GetSingle(waitKeyConfirmation.UserId);
                        user.StatusActivated = true;
                        rep.UpdateById(user.Id, user);
                        Program.waitKeyConfirmations.Remove(waitKeyConfirmation);
                        return Ok();
                    }
                    else
                    {
                        Program.waitKeyConfirmations.Remove(waitKeyConfirmation);
                        return BadRequest();
                    }
                }
            }
            return BadRequest();
        }

        [HttpPost("GetToken")]
        public IActionResult GetToken(Guid ID)
        {
            var user = rep.GetSingle(ID);
            if (user.StatusActivated)
            {
                var token = GenerateJWT(user);
                return Ok(new { acces_token = token });
            }
            return Unauthorized();
        }
        private string GenerateJWT(User user)
        {
            var securtiyKey = AuthOptions.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securtiyKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email,user.Email)
            };
            var token = new JwtSecurityToken(AuthOptions.ISSUER,
                AuthOptions.AUDIENCE, claims,
                expires: DateTime.Now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
