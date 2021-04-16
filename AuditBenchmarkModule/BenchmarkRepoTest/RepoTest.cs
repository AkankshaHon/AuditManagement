using AuditBenchmarkModule.Model;
using AuditBenchmarkModule.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace BenchmarkRepoTest
{
    [TestClass]
    public class RepoTest
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
            BenchmarkRepo cp = new BenchmarkRepo();
            List<AuditBenchmark> result = cp.GetNolist();
            Assert.AreEqual(l1.Count, result.Count);
        }

        [TestMethod]
        public void GetBenchmark_InvalidInput_ReturnBadRequest()
        {
            Mock<IBenchmarkRepo> mock = new Mock<IBenchmarkRepo>();
            mock.Setup(p => p.GetNolist()).Returns(l2);
            BenchmarkRepo cp = new BenchmarkRepo();
            List<AuditBenchmark> result = cp.GetNolist();
            Assert.AreNotEqual(l1.Count, result.Count);
        }
    }
}
