using System;
using System.Collections.Generic;
using MongoNetCore.Domain;

namespace MongoNetCore.Application.Interfaces
{
    public interface ISubmissionService
    {
        Submission Create(Submission submission);
        IList<Submission> Read();
        Submission Find(string id);
        void Update(Submission submission);
        void Delete(string id);
    }
}
