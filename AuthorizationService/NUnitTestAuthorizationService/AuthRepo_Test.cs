using AuthorizationService.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace NUnitTestAuthorizationService
{
    [TestClass]
    public class AuthRepo_Test
    {
        public string token_null;
        public void Setup()
        {
            token_null = null;
        }
        [TestMethod]
        public void GenerateJWT_correctInput_tokenNotnull()
        {
            try
            {
                var mock = new Mock<IConfiguration>();
                mock.SetupGet(x => x[It.IsAny<string>()]);
                var res = new AuthRepo(mock.Object);
                var data = res.GenerateJWT();
                Assert.IsNotNull(data);
            }
            catch (Exception e)
            {
                Assert.AreEqual("String reference not set to an instance of a String. (Parameter 's')", e.Message);
            }
        }

        [TestMethod]
        public void generateJWT_invalidInput_tokenNotnull()
        {
            try
            {
                var mock = new Mock<IConfiguration>();
                mock.SetupGet(x => x[It.IsAny<string>()]).Returns(token_null);
                var res = new AuthRepo(mock.Object);
                var data = res.GenerateJWT();
                Assert.IsNull(data);
            }
            catch (Exception e)
            {
                Assert.AreEqual("String reference not set to an instance of a String. (Parameter 's')", e.Message);
            }
        }
    }
}
