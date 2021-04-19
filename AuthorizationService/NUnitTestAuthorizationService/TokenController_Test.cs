using AuthorizationService.Controllers;
using AuthorizationService.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace NUnitTestAuthorizationService
{
    public class TokenController_Test
    {
        public string token_not_null;
        public string token_null;
        [SetUp]
        public void Setup()
        {
            token_not_null = "xhagssbmfbdmsdjfbkalalasknasncjafh";                             
            token_null = null;
        }
        [Test]
        public void Controller_getJsonWebToken_correctInput_tokenNotnull()
        {
            var mock = new Mock<IAuthRepo>();
            mock.Setup(p => p.GenerateJWT()).Returns(token_not_null);
            var res = new TokenController(mock.Object);
            var data = res.GenerateJSONWebToken() as OkObjectResult;
            Assert.AreEqual(200, data.StatusCode);
        }
        [Test]
        public void Controller_getJsonWebToken_IncorrectToken_tokenNull()
        {
            var mock = new Mock<IAuthRepo>();
            mock.Setup(p => p.GenerateJWT()).Returns(token_null);
            var res = new TokenController(mock.Object);
            var data = res.GenerateJSONWebToken() as BadRequestObjectResult;
            Assert.AreEqual(400, data.StatusCode);
        }
    }
}
