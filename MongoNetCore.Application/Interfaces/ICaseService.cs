using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoNetCore.Domain;

namespace MongoNetCore.Application.Interfaces
{
    public interface ICaseService
    {
        Task<Case> CreateAsync(Case @case);
        Task<IList<Case>> ReadAsync();
        Task<IList<Case>> ReadByClinicIdAsync(string caseId);
        Task<Case> FindAsync(string id);
        Task UpdateAsync(Case @case);
        Task DeleteAsync(string id);
    }
}
