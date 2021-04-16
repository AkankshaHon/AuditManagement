using AuditBenchmarkModule.Model;
using AuditBenchmarkModule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditBenchmarkModule.Providers
{
    public class BenchmarkProvider:IBenchmarkProvider
    {
        private readonly IBenchmarkRepo objBenchmarkRepo;
        public BenchmarkProvider(IBenchmarkRepo _objBenchmarkRepo)
        {
            objBenchmarkRepo = _objBenchmarkRepo;
        }

        public List<AuditBenchmark> GetBenchmark()
        {
            List<AuditBenchmark> listOfRepository = new List<AuditBenchmark>();
            try
            {
                listOfRepository = objBenchmarkRepo.GetNolist();
                return listOfRepository;
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
