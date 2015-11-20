using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMS.Books.Services.Messaging;

namespace DMS.Books.Services.Interfaces
{
    public interface ISubjectFacade
    {
        SubjectsResponse GetAllSubjects(SubjectRequest request);
    }
}
