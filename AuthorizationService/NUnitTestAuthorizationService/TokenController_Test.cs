using AuthorizationService.Controllers;
using AuthorizationService.Providers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace NUnitTestAuthorizationService
{
    [TestClass]
    public class TokenController_Test
    {
        public string token_not_null;
        public string token_null;
        public void Setup()
        {
            token_not_null = "xhagssbmfbdmsdjfbkalalasknasncjafh";
            token_null = null;
        }

        [TestMethod]
        public void controller_getJsonWebToken_correctInput_tokenNotnull()
        {
            var mock = new Mock<IAuthProvider>();
            mock.Setup(p => p.GetJsonWebToken()).Returns(token_not_null);
            var res = new TokenController(mock.Object);
            var data = res.GenerateJSONWebToken() as OkObjectResult;
            Assert.AreEqual(200, data.StatusCode);
        }
        [TestMethod]
        public void controller_getJsonWebToken_IncorrectToken_tokenNull()
        {
            var mock = new Mock<IAuthProvider>();
            mock.Setup(p => p.GetJsonWebToken()).Returns(token_null);
            var res = new TokenController(mock.Object);
            var data = res.GenerateJSONWebToken() as BadRequestObjectResult;
            Assert.AreEqual(400, data.StatusCode);
        }
    }
}
