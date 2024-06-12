using Microsoft.VisualStudio.TestPlatform;
using Clicker.Application.Services;
using Clicker.Domain.Interfaces;
using Moq;
using Clicker.Domain.Core;
namespace UserServiceTests
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void Tset_GetAll()
        {
            //Arrange
            var mock = new Mock<IUserRepository>();
            mock.Setup(a => a.GetUserList()).Returns(new List<User> { new User { id = 1, name = "1", password = "p", coins = 123 } });

            UserService serv = new UserService(mock.Object);
            List<User> userexpected = new List<User> { new User { id = 1, name = "1", password = "p", coins = 123 } };

            //Act
            var res = serv.GetAll().ToList();
            CollectionAssert.AreEqual(userexpected, res);
        }
    }
}