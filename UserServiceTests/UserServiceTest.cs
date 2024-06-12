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
        public void Test_GetAll()
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
        [TestMethod]
        public void Test_GetUserById()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(a => a.GetUser(1)).Returns(new User {  id = 1, name = "1", password = "p", coins = 123 });

            UserService service = new UserService(mock.Object);
            User userexpected = new User { id = 1, name = "1", password = "p", coins = 123 };

            var res = service.GetById(1);
            Assert.AreEqual(res, userexpected);
        }
    }
}