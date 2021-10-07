using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoNetCore.Application.Interfaces;
using MongoNetCore.Application.Settings;
using MongoNetCore.Domain;

namespace MongoNetCore.Application.Services
{
    public class ClinicService : IClinicService
    {
        private readonly IMongoCollection<Clinic> _clinics;

        public ClinicService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _clinics = database.GetCollection<Clinic>("Clinics");
        }

        public async Task<Clinic> CreateAsync(Clinic clinic)
        {
            await _clinics.InsertOneAsync(clinic);
            return clinic;
        }

        public async Task DeleteAsync(string id) =>
            await _clinics.DeleteOneAsync(clinic => clinic.Id == id);

        public async Task<Clinic> FindAsync(string id) =>
            await _clinics.Find(clinic => clinic.Id == id).SingleOrDefaultAsync();

        public async Task<IList<Clinic>> ReadAsync() =>
            await _clinics.Find(clinic => true).ToListAsync();

        public async Task SetupAsync()
        {
            var clinics = await ReadAsync();
            if (clinics.Count == 0)
            {
                List<Clinic> newClinics = new List<Clinic>
                {
                    new Clinic
                    {
                        Name = "Clinic A",
                        AddressLine1 = "123 Something Ln",
                        City = "Houston",
                        FaxNumber = "(901) 123-1231",
                        PhoneNumber = "(901) 123-1232",
                        State = "TX",
                        ZipCode = "77007"
                    },
                    new Clinic
                    {
                        Name = "Clinic B",
                        AddressLine1 = "123 Something Ln",
                        City = "Houston",
                        FaxNumber = "(901) 123-1231",
                        PhoneNumber = "(901) 123-1232",
                        State = "TX",
                        ZipCode = "77007"
                    },
                    new Clinic
                    {
                        Name = "Clinic C",
                        AddressLine1 = "123 Something Ln",
                        City = "Houston",
                        FaxNumber = "(901) 123-1231",
                        PhoneNumber = "(901) 123-1232",
                        State = "TX",
                        ZipCode = "77007"
                    }
                };

                await _clinics.InsertManyAsync(newClinics);
            }
        }

        public async Task UpdateAsync(Clinic clinic) =>
            await _clinics.FindOneAndReplaceAsync(_clinic => _clinic.Id == clinic.Id, clinic);
    }
}
