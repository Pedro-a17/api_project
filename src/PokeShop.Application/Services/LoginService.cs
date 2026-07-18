using BCrypt.Net;

using PokeShop.Application.DTOs.Login;

namespace PokeShop.Application.Services
{
    public class LoginService : ILoginService
    {
        readonly ILoginRepository _repository;
        readonly ITokenService _token;

        public LoginService(ILoginRepository repository, ITokenService token)
        {
            _repository = repository;
            _token = token;
        }

        public async Task<LoginResultDto> LoginAsync(string username, string password)
        {
            var user = await _repository.GetUserByUserNameAsync(username);

            if (user == null)
            {
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
                
                user = new User
                {
                    UserName = username,
                    PasswordHash = passwordHash,
                    Coins = 100,
                    FirstLogin = true
                };

                await _repository.CreateUserAsync(user);
            }

            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                throw new ArgumentException("Password is incorrect");

            if (!user.FirstLogin)
            {
                user.FirstLogin = true;
                user.Coins += 100;

                await _repository.UpdateUserFirstLogin();
            }
            
            string jwt = _token.jwtTokenGenerator(user.Id);
            return new LoginResultDto("Login succeed", user.UserName, user.Coins);
        }
    }
} 