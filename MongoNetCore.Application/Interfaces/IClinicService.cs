using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoNetCore.Domain;

namespace MongoNetCore.Application.Interfaces
{
    public interface IClinicService
    {
        Task<Clinic> CreateAsync(Clinic clinic);
        Task<IList<Clinic>> ReadAsync();
        Task<Clinic> FindAsync(string id);
        Task UpdateAsync(Clinic clinic);
        Task DeleteAsync(string id);
        Task SetupAsync();
    }
}
