using AutoMapper;
using IQ_Class.Data;
using IQ_Class.Data.Dtos;
using IQ_Class.Models;

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

        public void Register(CreateUserDto dto)
        {
            if (_context.users.Any(user => user.email == dto.email))
            {
                throw new ApplicationException("Email '" + dto.email + "' já está em uso!");
            }
            
            User user = _mapper.Map<User>(dto);

            user.password_hash = BCrypt.Net.BCrypt.HashPassword(dto.password);

            _context.users.Add(user);
            _context.SaveChanges();
        }

        public string Authenticate(LoginUserDto user)
        {
            var currentUser = (
                from objUser in _context.users
                where
                    objUser.email == user.email
                select new AuthenticatedUserDto
                {
                    id = objUser.id,
                    name = objUser.name,
                    email = objUser.email,
                    password_hash = objUser.password_hash,
                }
                ).SingleOrDefault();


            if (currentUser == null || !BCrypt.Net.BCrypt.Verify(user.password, currentUser.password_hash))
            {
                throw new ApplicationException("Usuário ou senha incorreto!");
            }

            var roles = (
                from objUserRoles in _context.user_roles.Where(x => x.userid == currentUser.id)
                join objRoles in _context.roles on objUserRoles.roleid equals objRoles.id
                select objRoles.role
            ).ToList();

            if (roles.Count > 0)
            {
                currentUser.roles = new List<string> { roles[0] };
            }

            var token = _tokenService.GenerateAuthenticationToken(currentUser);

            return token;
        }

        public User? RequestNewAcess(string email)
        {
            var currentUser = (
                    from objUser in _context.users
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
    }
}
