using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoNetCore.Application.Interfaces;
using MongoNetCore.Application.Settings;
using MongoNetCore.Domain;

namespace MongoNetCore.Application.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly IMongoCollection<ToDoList> _toDoLists;

        public ToDoListService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _toDoLists = database.GetCollection<ToDoList>("ToDos");
        }

        public async Task<ToDoList> CreateAsync(ToDoList toDoList)
        {
            await _toDoLists.InsertOneAsync(toDoList);
            return toDoList;
        }

        public async Task DeleteAsync(string id) =>
            await _toDoLists.DeleteOneAsync(list => list.Id == id);

        public async Task<ToDoList> FindAsync(string id) =>
            await _toDoLists.Find(list => list.Id == id).SingleOrDefaultAsync();

        public async Task<IList<ToDoList>> ReadAsync(Guid userId) =>
            await _toDoLists.Find(list => list.UserId == userId).ToListAsync();

        public async Task UpdateAsync(ToDoList list) =>
            await _toDoLists.ReplaceOneAsync(list => list.Id == list.Id, list);
    }
}
