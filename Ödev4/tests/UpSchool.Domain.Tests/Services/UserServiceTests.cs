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

        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue_WhenUserExists()
        {
            // Arrange
            var userRepositoryMock = A.Fake<IUserRepository>();
            var userService = new UserManager(userRepositoryMock);
            var user = new User { Id = Guid.Empty, Email = "test@asdas.com" };
            var cancellationSource = new CancellationTokenSource();

            // Act and Assert
            Assert.ThrowsAsync<ArgumentException>(() => userService.UpdateAsync(user,cancellationSource.Token));
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrowException_WhenUserDoesntExists()
        {
            // Arrange
            var userRepositoryMock = A.Fake<IUserRepository>();
            var userService = new UserManager(userRepositoryMock);
            var cancellationSource = new CancellationTokenSource();

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => userService.DeleteAsync(Guid.Empty, cancellationSource.Token));
        }

        [Fact]
        public void UpdateAsync_ShouldThrowException_WhenUserIdIsEmpty()
        {
            // Arrange
            var userRepositoryMock = A.Fake<IUserRepository>();
            var userService = new UserManager(userRepositoryMock);
            var user = new User { Id = Guid.Empty, Email = "test@asdas.com" };
            var cancellationSource = new CancellationTokenSource();


            // Act and Assert
            Assert.ThrowsAsync<ArgumentException>(() => userService.UpdateAsync(user,cancellationSource.Token));
        }

        [Fact]
        public void UpdateAsync_ShouldThrowException_WhenUserEmailEmptyOrNull()
        {
            // Arrange
            var userRepositoryMock = A.Fake<IUserRepository>();
            var userService = new UserManager(userRepositoryMock);
            var user = new User { Id = Guid.NewGuid(), Email = null };
            var cancellationSource = new CancellationTokenSource();


            // Act and Assert
            Assert.ThrowsAsync<ArgumentException>(() => userService.UpdateAsync(user, cancellationSource.Token));
            Assert.ThrowsAsync<ArgumentException>(() => userService.UpdateAsync(new User { Id = Guid.NewGuid(), Email = string.Empty }, cancellationSource.Token));
        }


        [Fact]
        public async Task GetAllAsync_ShouldReturn_UserListWithAtLeastTwoRecords()
        {
            // Arrange
            var userRepositoryMock = A.Fake<IUserRepository>();
            var userService = new UserManager(userRepositoryMock);
            var cancellationSource = new CancellationTokenSource();

            var userList = new List<User>
            {
                new User { Id = Guid.NewGuid(), Email = "user1@asdas.com" },
                new User { Id = Guid.NewGuid(), Email = "user2@asdas.com" }
            };

            A.CallTo(() => userRepositoryMock.GetAllAsync(cancellationSource.Token))
                .Returns(userList);

            // Act
            var result = await userService.GetAllAsync(cancellationSource.Token);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Count >= 2);
        }
    }
}
