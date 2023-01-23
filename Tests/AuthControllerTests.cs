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
        [Test]
        public void Login_AddUserInRepository_ReturnsListWithUser()
        {
            var userRepository = new UserRepository(new List<string>());

            var authController = new AuthController(userRepository);
            string user = "Никита";
            authController.Login(user);
            CollectionAssert.Contains(userRepository.Users, user);
        }

        [Test]
        public void Logout_RemoveUserFromRepository_ReturnsListWithoutUser()
        {
            var userRepository = new UserRepository(new List<string>()
            {
                "Иван",
            });

            var authController = new AuthController(userRepository);
            string user = "Иван";
            authController.Logout(user);
            CollectionAssert.DoesNotContain(userRepository.Users, user);
        }

        [Test]
        public void Login_AddNullUserInRepository_ThrowsNullArgumentException()
        {
            var userRepository = new UserRepository(new List<string>());
            var authController = new AuthController(userRepository);
            Assert.Throws<ArgumentNullException>(() => authController.Login(null));
        }
    }
}
