using DroughtProject.Models;
using Xunit;

namespace DroughtProject.Tests.Models
{
    public class UsersTests
    {
        [Fact]
        public void UsersModel_CanBeInitialized()
        {
            // Arrange
            var user = new Users
            {
                Id = 1,
                Name = "John Doe",
                Email = "john.doe@example.com",
                Password = "password123"
            };

            // Act & Assert
            Assert.Equal(1, user.Id);
            Assert.Equal("John Doe", user.Name);
            Assert.Equal("john.doe@example.com", user.Email);
            Assert.Equal("password123", user.Password);
        }
    }
}