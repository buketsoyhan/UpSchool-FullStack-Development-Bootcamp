using FakeItEasy;
using UpSchool.Domain.Data;
using UpSchool.Domain.Entities;
using UpSchool.Domain.Services;

namespace UpSchool.Domain.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task GetUser_ShouldGetUserWithCorrectId()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();

            Guid userId = new Guid("8f319b0a-2428-4e9f-b7c6-ecf78acf00f9");

            var cancellationSource = new CancellationTokenSource();

            var expectedUser = new User()
            {
                Id = userId
            };

            A.CallTo(() => userRepositoryMock.GetByIdAsync(userId, cancellationSource.Token))
                .Returns(Task.FromResult(expectedUser));

            IUserService userService = new UserManager(userRepositoryMock);

            var user = await userService.GetByIdAsync(userId, cancellationSource.Token);

            Assert.Equal(expectedUser, user);
        }

        [Fact]
        public async Task AddAsync_ShouldThrowException_WhenEmailIsEmptyOrNull()
        {
            //Arrange
            var userRepositoryMock = A.Fake<IUserRepository>();
            var userService = new UserManager(userRepositoryMock);
            var cancellationSource = new CancellationTokenSource();

            // Act and Assert
            //Email Null Check
            await Assert.ThrowsAsync<ArgumentException>(() => userService.AddAsync("Buk","Soyh",24,null, cancellationSource.Token));
            //Email Empty Check
            await Assert.ThrowsAsync<ArgumentException>(() => userService.AddAsync("B", "S", 25, string.Empty, cancellationSource.Token));
        }

        [Fact]
        public async Task AddAsync_ShouldReturn_CorrectUserId()
        {
            //Arrange
            var userRepositoryMock = A.Fake<IUserRepository>();
            var userService = new UserManager(userRepositoryMock);
            Guid userId = new Guid("8f319b0a-2428-4e9f-b7c6-ecf78acf00f9");
            var cancellationSource = new CancellationTokenSource();

            var expectedUser = new User()
            {
                Id = userId
            };

            A.CallTo(() => userRepositoryMock.GetByIdAsync(userId, cancellationSource.Token))
            .Returns(Task.FromResult(expectedUser));

            // Act
            var user = await userService.GetByIdAsync(userId, cancellationSource.Token);

            // Assert
            Assert.Equal(expectedUser, user);
        }
    }
}
