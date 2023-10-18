using AutoMapper;
using IQ_Class.Data;
using IQ_Class.Data.Commun;
using IQ_Class.Data.Dtos;
using IQ_Class.Models;
using Microsoft.AspNetCore.Mvc;

namespace IQ_Class.Services
{
    public class UserService
    {
        private IMapper _mapper;
        private TokenService _tokenService;
        private ApplicationDbContext _context;

        public UserService(IMapper mapper, TokenService tokenService, ApplicationDbContext context)
        {
            _mapper = mapper;
            _tokenService = tokenService;
            _context = context;
        }

        public User? GetUserByID(int id) 
        {
            var user = (
                from
                    objUser in _context.users
                where
                    objUser.id == id
                select
                    objUser
            ).FirstOrDefault();

            return user;
        }

        public async Task<Result<User>> Register(CreateUserDto dto)
        {
            if (_context.users.Any(user => user.email == dto.email))
            {
                return new Result<User>($"Email {dto.email} já está em uso!");
            }
            
            User user = _mapper.Map<User>(dto);

            user.password_hash = BCrypt.Net.BCrypt.HashPassword(dto.password);

            _context.users.Add(user);
            await _context.SaveChangesAsync();

            return new Result<User>(user);
        }

        public string? Authenticate(LoginUserDto user)
        {
            var currentUser = (
                from 
                    objUser in _context.users
                join
                    objRoles in _context.roles on objUser.roleid equals objRoles.id
                where
                    objUser.email == user.email
                select new AuthenticatedUserDto
                {
                    id = objUser.id,
                    name = objUser.name,
                    email = objUser.email,
                    password_hash = objUser.password_hash,
                    role = objRoles.role
                }
            ).SingleOrDefault();


            if (currentUser == null || !BCrypt.Net.BCrypt.Verify(user.password, currentUser.password_hash))
            {
                return null;
            }

            var token = _tokenService.GenerateAuthenticationToken(currentUser);

            return token;
        }

        public User? RequestNewAcess(string email)
        {
            var currentUser = (
                from 
                    objUser in _context.users
                where
                    objUser.email == email
                select
                objUser
            ).FirstOrDefault();

            if (String.IsNullOrWhiteSpace(email) || currentUser == null || currentUser.verification_code_active)
            {
                return null;
            }

            Random Random = new Random();
            int RandomNumber = Random.Next(1000000);
            string sixDigitNumber = RandomNumber.ToString("D6");

            currentUser.verification_code = sixDigitNumber;
            currentUser.verification_code_active = true;

            _context.users.Update(currentUser);
            _context.SaveChanges();

            return currentUser;
        }

        public User? ChangePassword(ChangePasswordDto dto)
        {
            var currentUser = (
                    from objUser in _context.users
                    where
                        objUser.email == dto.email &&
                        objUser.verification_code == dto.verification_code &&
                        objUser.verification_code_active
                    select objUser
                ).FirstOrDefault();

            if (currentUser == null)
            {
                return null;
            };

            currentUser.password_hash = BCrypt.Net.BCrypt.HashPassword(dto.password);
            currentUser.verification_code = "000000";
            currentUser.verification_code_active = false;

            _context.users.Update(currentUser);
            _context.SaveChanges();

            return currentUser;
        }

        public Result<User> DeleteUser(int id)
        {
            var user = GetUserByID(id);

            if (user == null)
            {
                return new Result<User>("Usuário não encontrado!");
            }

            var deletedUser = user;

            _context.Remove(user);
            _context.SaveChanges();
            Console.WriteLine(user);
            return new Result<User>(deletedUser, "Usuário deletado");
        }
    }
}
