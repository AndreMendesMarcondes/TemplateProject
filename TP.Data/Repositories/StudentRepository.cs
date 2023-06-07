using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TP.Domain.Domain;
using TP.Domain.Interfaces.Data;
using TP.Domain.Settings;

namespace TP.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IMongoCollection<Student> _collection;
        private static string COLLECTION_NAME = "student";

        public StudentRepository(IOptions<MongoSettings> mongoSettings)
        {
            var mongoClient = new MongoClient(mongoSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoSettings.Value.DatabaseName);
            _collection = mongoDatabase.GetCollection<Student>(COLLECTION_NAME);
        }

        public async Task<Student> GetById(string studentId)
        {
            var students = await _collection.FindAsync(c => c.Id == studentId);
            return students.FirstOrDefault();
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            var students =  await _collection.FindAsync(c => true);
            return students.ToEnumerable();
        }

        public async Task Add(Student student)
        {
            await _collection.InsertOneAsync(student);
        }

        public async Task RemoveById(string studentId)
        {
            await _collection.DeleteOneAsync(c=> c.Id == studentId);
        }

        public async Task Update(string studentId, Student newStudent)
        {
            await _collection.ReplaceOneAsync(c=> c.Id == studentId, newStudent);
        }
    }
}
