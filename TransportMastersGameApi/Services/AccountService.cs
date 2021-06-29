using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TransportMastersGameApi.Entities;
using TransportMastersGameApi.Models;
using FirstStepsDotNet.Models;
using Microsoft.EntityFrameworkCore;
using FirstStepsDotNet.Exceptions;
using Microsoft.Extensions.Logging;

namespace TransportMastersGameApi.Services
{
    public class AccountService : IAccountService
    {
        private TransportMastersGameDbContext _dbContext;
        private IMapper _mapper;

        private readonly ILogger<AccountService> _logger;
        private readonly IPasswordHasher<User> _passwordHasher;
        private AuthenticationSettings _authenticationSettings;

        public AccountService(TransportMastersGameDbContext dbContext, IMapper mapper, ILogger<AccountService> logger, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public void RegisterUser(RegisterUserDto dto)
        {
            var user = new User()
            {
                Email = dto.Email,
                DateOfBirth = dto.DateOfBirth,
                Nationality = dto.Nationality,
                RoleId = dto.RoleId
            };

            var hashedPassword = _passwordHasher.HashPassword(user, dto.Password);
            user.PasswordHash = hashedPassword;

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
        //public string GenerateJwt(LoginDto dto)
        //{
        //    //var user = _dbContext.Users
        //    //    .Include(u => u.Role) //dołączyłem informacje za pomocą predykaty o rolach usera
        //    //    .FirstOrDefault(u => u.Email == dto.Email);
        //    //if (user is null)
        //    //{
        //    //    throw new BadRequestExceprion("Invalid username or password");
        //    //}

        //    //var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password); //ta metoda sprawdza czy user wpisał dobre hasło 
        //    //if (result == PasswordVerificationResult.Failed)
        //    //{
        //    //    throw new BadRequestExceprion("Invalid username or password");
        //    //}

        //    ////tworze listę claimów które przechowują informacje o urzytkowniku 
        //    //var claims = new List<Claim>()
        //    //{
        //    //    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        //    //    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
        //    //    new Claim(ClaimTypes.Role, $"{user.Role.Name}"),
        //    //    new Claim("Nationality", user.Nationality)
        //    //};


        //    //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));   //tworze klucz prywatny
        //    //var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); //generuje kredencjały potrzebne do wygenerowania tokenu Jwt
        //    //var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays); // podaje ile dni token bedzie poprawny 

        //    ////generuje token
        //    //var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
        //    //    _authenticationSettings.JwtIssuer,
        //    //    claims,
        //    //    expires: expires,
        //    //    signingCredentials: cred);


        //    //var tokenHandler = new JwtSecurityTokenHandler();
        //    //return tokenHandler.WriteToken(token);

        //}
    }
}
