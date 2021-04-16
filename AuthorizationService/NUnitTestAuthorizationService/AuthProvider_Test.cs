using AuthorizationService.Providers;
using AuthorizationService.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace NUnitTestAuthorizationService
{
    [TestClass]
    public class AuthProvider_Test
    {
        public string token_not_null;
        public string token_null;
        public void Setup()
        {
            token_not_null = "xhagssbmfbdmsdjfbkalalasknasncjafh";
            token_null = null;
        }

        [TestMethod]
        public void provider_generateJWT_correctInput_tokenNotnull()
        {
            var mock = new Mock<IAuthRepo>();
            mock.Setup(p => p.GenerateJWT()).Returns(token_not_null);
            var res = new AuthProvider(mock.Object);
            var data = res.GetJsonWebToken();
            Assert.AreEqual(token_not_null, data);
        }
        [TestMethod]
        public void provider_generateJWT_correctInput_tokenNull()
        {
            var mock = new Mock<IAuthRepo>();
            mock.Setup(p => p.GenerateJWT()).Returns(token_null);
            var res = new AuthProvider(mock.Object);
            var data = res.GetJsonWebToken();
            Assert.AreEqual(null, data);
        }
    }
}
