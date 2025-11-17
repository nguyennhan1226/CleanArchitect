using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Models.Identity;
using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;
        public AuthService(UserManager<ApplicationUser> userManager,IOptions<JwtSettings> jwtSettngs,SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettngs.Value;
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
          var user = await _userManager.FindByEmailAsync(request.Email);
            if(user == null)
            {
                throw new NotFoundException($"User with {request.Email} not found",request.Email);
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded)
            {
               throw new BadRequestException($"Invalid Credentials for {request.Email}");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            var response = new AuthResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
            };

            return response;

        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();
            var claim = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("uid",user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signinCredential = new SigningCredentials(symetricSecurityKey,SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claim,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signinCredential
                );

            return jwtSecurityToken;


        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
           var user = await _userManager.FindByEmailAsync(request.Email);
            if(user != null)
            {
                throw new BadRequestException($"User with {request.Email} already exists");
            }
            var newUser = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,

            };
            var createdUser = await _userManager.CreateAsync(newUser, request.Password);
            if(!createdUser.Succeeded)
            {
                var errors = createdUser.Errors.Select(e => e.Description);
                throw new BadRequestException($"User creation failed: {string.Join(",",errors)}");
            }
            await _userManager.AddToRoleAsync(newUser, "Employee");
            var token = await GenerateToken(newUser);
            return new RegistrationResponse
            {
                UserId = newUser.Id,
              
            };
        }
    }
}
