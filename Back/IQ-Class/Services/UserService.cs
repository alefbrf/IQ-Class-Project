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

        public string RequestNewAcess(string email)
        {
            var currentUser = (
                    from objUser in _context.users
                    where
                        objUser.email == email
                    select
                    objUser
                ).FirstOrDefault();

            if (String.IsNullOrWhiteSpace(email) || currentUser == null || currentUser.guid_active)
            {
                throw new ApplicationException("Usuário não encontrado!");
            }

            var guid = Guid.NewGuid();

            currentUser.guid = guid;
            currentUser.guid_active = true;

            _context.users.Update(currentUser);
            _context.SaveChanges();

            return _tokenService.GenerateResetPasswordToken(currentUser);
        }

        public User? ChangePassword(ChangePasswordDto dto)
        {
            var currentUser = (
                    from objUser in _context.users
                    where
                        objUser.id == dto.id &&
                        objUser.email == dto.email &&
                        objUser.guid == dto.guid &&
                        objUser.guid_active
                    select objUser
                ).FirstOrDefault();

            if (currentUser == null)
            {
                return null;
            };

            currentUser.password_hash = BCrypt.Net.BCrypt.HashPassword(dto.password);
            currentUser.guid = Guid.Empty;
            currentUser.guid_active = false;

            _context.users.Update(currentUser);
            _context.SaveChanges();

            return currentUser;
        }
    }
}
