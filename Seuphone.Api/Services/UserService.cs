using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Seuphone.Api.Data;
using Seuphone.Api.Helpers;
using Seuphone.Api.IServices;
using Seuphone.Api.Models;

namespace Seuphone.Api.Services
{
    public class UserService : IUserService
    {
        private SeuphoneApiContext _context;
        private List<User> _users { get; set; }
        private readonly AppSettings _appSettings;


        public UserService(IOptions<AppSettings> appSettings, SeuphoneApiContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
            this._users = FindAllUsers();
        }

        public User Authenticate(string email, string password)
        {
            var user = _users.SingleOrDefault(x => x.Email == email && x.Password == password);

            if (user == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            
            return user;
        }


        public List<User> FindAllUsers()
        {
            return _context.User.ToList();
        }
    }
}
