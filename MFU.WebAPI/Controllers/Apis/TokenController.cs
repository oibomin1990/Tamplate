using MFU.Models;
using MFU.WebAPI.Security;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Http;

namespace MFU.WebAPI.Controllers
{
    public class TokenController : BaseApiController
    {
        private List<User> users = new List<User>() {
                                                  new User  {
                                                        UserId= 3001,
                                                        FullName= "Liz Lemon",
                                                        EmailAddress= "liz.lemon@example.com",
                                                        Password= "Password1"
                                                      },
                                                  new User {
                                                        UserId= 3002,
                                                        FullName= "Jack Donaghy",
                                                        EmailAddress= "jack.donaghy@example.com",
                                                        Password= "Password1"
                                                  },
                                                  new User {
                                                        UserId= 3003,
                                                        FullName= "Tracy Jordan",
                                                        EmailAddress= "tracy.jordan@example.com",
                                                        Password= "Password1"
                                                  }
                                                };

        public IHttpActionResult Post(Credentials credential)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            // It goes without question that in the real world our passwords would be hashed
            var user = users.FirstOrDefault(u => u.EmailAddress.Equals(credential.EmailAddress, StringComparison.OrdinalIgnoreCase) && credential.Password == u.Password);
            if (user == null)
                return Unauthorized();

            var lifetimeInMinutes = int.Parse(WebConfigurationManager.AppSettings["TokenLifetimeInMinutes"]);
            var token = CreateToken(user.UserId.ToString(), user.FullName, lifetimeInMinutes);

            return Ok(new
            {
                Token = token,
                LifetimeInMinutes = lifetimeInMinutes,
                FullName = user.FullName
                // Any anything else that you want here...
            });
        }

        [Authorize]
        public async Task<IHttpActionResult> Get()
        {
            return Ok("Hello " + User.Identity.Name + "!!!");
        }

        public static string CreateToken(string userId, string fullName, int lifetimeInMinutes)
        {
            // Create the JWT
            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim("name", fullName)
                // And any other bit of (session) data you want....
            });

            var now = DateTime.UtcNow;
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Issuer = SecurityConfiguration.TokenIssuer,
                Audience = SecurityConfiguration.TokenAudience,
                SigningCredentials = SecurityConfiguration.SigningCredentials,
                IssuedAt = now,
                Expires = now.AddMinutes(lifetimeInMinutes)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
