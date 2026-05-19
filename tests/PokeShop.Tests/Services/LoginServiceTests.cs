using Moq;
using Xunit;
using PokeShop.Application.Services;
using PokeShop.Domain.Models;
using PokeShop.Domain.Interfaces;

namespace PokeShop.Tests.Services
{
    public class LoginServiceTests
    {
        private readonly Mock<ILoginRepository> _repoMock;
        private readonly LoginService _service;

        public LoginServiceTests()
        {
            _repoMock = new Mock<ILoginRepository>();
            _service = new LoginService(_repoMock.Object);
        }

        [Fact]
        public async Task LoginAsync_AssertCreatingUserWhenNull()
        {
            // Arrange
            var username = "Ash";
            var password = "0303";
        
            _repoMock.Setup(r => r.GetUserByUserNameAsync(username))
                    .ReturnsAsync((User?)null);

            // Act
            var result = await _service.LoginAsync(username, password);

            // Assert & verify
            Assert.Equal("Login succeed", result.Message);
            Assert.Equal(100, result.Coins);

            _repoMock.Verify(r => r.CreateUserAsync(It.Is<User>(u => 
                u.UserName == username &&
                u.FirstLogin == true)), Times.Once);
        }

        [Fact]
        public async Task LoginAsync_AssertThrowingArgumentExceptionWhenPasswordIsIncorrect()
        {
            //Arrange
            var username = "Ash";
            var correctPassword = "0303";
            var wrongPassword = "Charizard132";

            User user = new User()
            {
                UserName = username,
                PasswordHash = correctPassword,
            };

            _repoMock.Setup(r => r.GetUserByUserNameAsync(username))
                .ReturnsAsync(user);

            //Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _service.LoginAsync(username, wrongPassword));

            Assert.Equal("Password is incorrect", exception.Message);

            //Verify
            _repoMock.Verify(r => r.UpdateUserFirstLogin(), Times.Never);
        }

        [Fact]
        public async Task LoginAsync_AssertReceivingFirstLoginBonus()
        {
            // Arrange
            var username = "Ash";
            var password = "0303";
            var user = new User
            {
                UserName = username,
                PasswordHash = password,
                Coins = 0,
                FirstLogin = false
            }; 

            _repoMock.Setup(r => r.GetUserByUserNameAsync(username)).ReturnsAsync(user);

            // Act
            var result = await _service.LoginAsync(username, password);

            // Assert & verify
            Assert.Equal(100, result.Coins);

            _repoMock.Verify(r => r.UpdateUserFirstLogin(), Times.Once);
        }
    }
}