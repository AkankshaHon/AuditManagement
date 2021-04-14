using AuditSeverityModule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditSeverityModule.Repository
{
    public interface ISeverityRepo
    {
        public List<AuditBenchmark> Response();
    }
}
