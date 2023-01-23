using Chat.Server;
using Chat.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class UserControllerTests
    {
        private UserRepository _userRepository;

        [SetUp]
        public void Setup()
        {
            _userRepository = new UserRepository(new List<string>());
        }

        [Test]
        public void GetOnlineUsers_GetUsersFromRepository_ReturnsOnlineUserList()
        {
            UserController userController = new UserController(_userRepository);
            AuthController authController = new AuthController(_userRepository);
            List<string> users = new List<string>()
            {
                "Иван",
                "Дмитрий",
                "Игорь"
            };
            foreach (string user in users)
            {
                authController.Login(user);
            }
            CollectionAssert.AreEqual(users, userController.GetOnlineUsers().Value);
        }

        [Test]
        public void GetOnlineUsers_GetEmptyListFromRepository_ReturnsEmptyListFromEmptyRepository()
        {
            var emptyRepository = new UserRepository();
            var controller = new UserController(emptyRepository);
            var actualList = controller.GetOnlineUsers().Value;
            Assert.IsEmpty(actualList!);
        }
    }
}
