using eCommerceReplacementProject.CommonClasses;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace eCommerceReplacementProject.Client.IntegrationTests
{
    [TestClass]
    public class ClientTests
    {
        private IUserClient userClient;

        [TestMethod]
        public async Task GetAsyncFindsUser()
        {
            userClient = new UserClient(new ClientConfiguration { BaseAddress = "https://localhost:5001", MediaType = "application/json" });
            var testUser = await userClient.RegisterNewUser(GetTestUser());
            var result = await userClient.FindUserById(testUser.Id);

            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(UserResource));
            result.FirstName.Should().Be(testUser.FirstName);
            result.LastName.Should().Be(testUser.LastName);
            result.Email.Should().Be(testUser.Email);
            result.IsAdmin.Should().Be(testUser.IsAdmin);
            result.Password.Should().Be(testUser.Password);
        }

        [TestMethod]
        public async Task CreateUser()
        {
            userClient = new UserClient(new ClientConfiguration { BaseAddress = "https://localhost:5001", MediaType = "application/json" });
            var testUser = GetTestUser();
            var result = await userClient.RegisterNewUser(testUser);

            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(UserResource));
            result.FirstName.Should().Be(testUser.FirstName);
            result.LastName.Should().Be(testUser.LastName);
            result.Email.Should().Be(testUser.Email);
            result.IsAdmin.Should().Be(testUser.IsAdmin);

            // password should be hashed from api
            result.Password.Should().NotBe(testUser.Password);
        }

        //TODO: Create a cleanup method to remove data from db

        private UserResource GetTestUser() => 
            new UserResource
            {
                FirstName = "Test User First",
                LastName = "Test User Last",
                Password = "SomePassword",
                Email = "test@testEmail.com",
                IsAdmin = 1
            };
    }
}
