using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoNetCore.Application.Interfaces;
using MongoNetCore.Application.Settings;
using MongoNetCore.Domain;

namespace MongoNetCore.Application.Services
{
    public class CaseService : ICaseService
    {
        private readonly IMongoCollection<Case> _cases;

        public CaseService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _cases = database.GetCollection<Case>("Cases");
        }

        public async Task<Case> CreateAsync(Case @case)
        {
            await _cases.InsertOneAsync(@case);
            return @case;
        }

        public async Task DeleteAsync(string id) =>
            await _cases.DeleteOneAsync(@case => @case.Id == id);

        public async Task<Case> FindAsync(string id) =>
            await _cases.Find(@case => @case.Id == id).FirstOrDefaultAsync();

        public async Task<IList<Case>> ReadAsync() =>
            await _cases.Find(@case => true).ToListAsync();

        public async Task<IList<Case>> ReadByClinicIdAsync(string caseId) =>
            await _cases.Find(@cases => @cases.Clinic.Id == caseId).ToListAsync();

        public async Task UpdateAsync(Case @case) =>
            await _cases.ReplaceOneAsync(_case => _case.Id == @case.Id, @case);
    }
}
