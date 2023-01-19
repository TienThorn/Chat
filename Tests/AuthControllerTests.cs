using System.Collections.Generic;
using Chat.Server;
using Chat.Server.Controllers;
using Chat.Shared;
using NUnit.Framework;
using System.Linq;
using System;

namespace Tests
{   
    [TestFixture]
    public class AuthControllerTests
    {
        private UserRepository _userRepository;

        [SetUp]
        public void Setup()
        {
            _userRepository = new UserRepository(new List<string>());

            string user1 = "Виктор";
            string user2 = "Егор";
            string user3 = "Иван";
        }

        [Test]
        public void Login_AddUserInRepository_ReturnsListWithUser()
        {
            var authController = new AuthController(_userRepository);
            string user = "Никита";
            authController.Login(user);
            CollectionAssert.Contains(_userRepository.Users, user);
        }

        [Test]
        public void Logout_RemoveUserFromRepository_ReturnsListWithoutUser()
        {
            var authController = new AuthController(_userRepository);
            string user = "Иван";     
            authController.Logout(user);
            CollectionAssert.DoesNotContain(_userRepository.Users, user);
        }

        [Test]
        public void Login_AddUserInRepository_ThrowsNullArgumentException()
        {
            var authController = new AuthController(_userRepository);
            Assert.Throws<ArgumentNullException>(()=> authController.Login(null));
        }
    }
}
