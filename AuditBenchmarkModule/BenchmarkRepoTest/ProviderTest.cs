using AuditBenchmarkModule.Model;
using AuditBenchmarkModule.Providers;
using AuditBenchmarkModule.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;


namespace BenchmarkRepoTest
{
    [TestClass]
    public class ProviderTest
    {
        List<AuditBenchmark> l2 = new List<AuditBenchmark>();
        List<AuditBenchmark> l1 = new List<AuditBenchmark>();
        public void Setup()
        {
            l1 = new List<AuditBenchmark>()
            {
               new AuditBenchmark
               {
                    auditType="Internal",
                    benchmarkNoAnswers=3
               },
               new AuditBenchmark
               {
                   auditType="SOX",
                   benchmarkNoAnswers=1
               }
            };
            l2 = new List<AuditBenchmark>()
            {
                new AuditBenchmark
                {
                    auditType="ABC",
                    benchmarkNoAnswers=4
                }
            };
        }

        [TestMethod]
        public void GetBenchmark_ValidInput_OkRequest()
        {
            Mock<IBenchmarkRepo> mock = new Mock<IBenchmarkRepo>();
            mock.Setup(p => p.GetNolist()).Returns(l1);
            BenchmarkProvider cp = new BenchmarkProvider(mock.Object);
            List<AuditBenchmark> result = cp.GetBenchmark();
            Assert.AreEqual(l1.Count, result.Count);
        }

        [TestMethod]
        public void GetBenchmark_InvalidInput_ReturnBadRequest()
        {
            Mock<IBenchmarkRepo> mock = new Mock<IBenchmarkRepo>();
            mock.Setup(p => p.GetNolist()).Returns(l2);
            BenchmarkProvider cp = new BenchmarkProvider(mock.Object);
            List<AuditBenchmark> result = cp.GetBenchmark();
            Assert.AreNotEqual(l1.Count, result.Count);
        }
    }
}
