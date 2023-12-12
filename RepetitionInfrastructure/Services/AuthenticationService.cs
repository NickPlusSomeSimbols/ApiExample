using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepetitionCore.Authentication;
using RepetitionCore.IdentityAuth;
using RepetitionInfrastructure.ServiceInterfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WA.Pizza.Core.IdentityAuth;

namespace RepetitionInfrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        public AuthenticationService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }
        public async Task<string> RegisterAsync(RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return "UserExists";

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return "CreationFailed";

            return "Ok";
        }
        public async Task<string> RegisterAdminAsync(RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return "UserExists";

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return "CreationFailed";

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin.ToString()))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin.ToString()));
            if (!await roleManager.RoleExistsAsync(UserRoles.User.ToString()))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User.ToString()));

            if (await roleManager.RoleExistsAsync(UserRoles.Admin.ToString()))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin.ToString());
            }

            return "Ok";
        }
        public async Task<object> LoginAsync(LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                string secretKey = _configuration.GetSection("JWT").GetSection("SecretKey").Value.ToString();
                string validIssuer = _configuration.GetSection("JWT").GetSection("ValidIssuer").Value.ToString();
                string validAudience = _configuration.GetSection("JWT").GetSection("ValidAudience").Value.ToString();

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

                var token = new JwtSecurityToken(
                issuer: validIssuer,
                audience: validAudience,
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

                return (new { token = new JwtSecurityTokenHandler().WriteToken(token), expiration = token.ValidTo });
            }
            return "Unauthorized";
        }
    }
}
