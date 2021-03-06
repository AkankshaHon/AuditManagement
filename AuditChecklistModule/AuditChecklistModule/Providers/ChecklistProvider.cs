using AuditChecklistModule.Model;
using AuditChecklistModule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditChecklistModule.Providers
{
    public class ChecklistProvider : IChecklistProvider
    {
        private readonly IChecklistRepo checklistRepoObj;
        public ChecklistProvider(IChecklistRepo _checklistRepoObj)
        {
            checklistRepoObj = _checklistRepoObj;
        }
        List<Questions> listOfQuestions = new List<Questions>();

        public List<Questions> QuestionsProvider(string auditType)
        {
            listOfQuestions = checklistRepoObj.GetQuestions(auditType);
            return listOfQuestions;
        }
    }
}