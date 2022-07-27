using Core6MongoDb.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Core6MongoDb.Services
{
    public class BooksService
    {
        private readonly IMongoCollection<Books> bookcollection;

        public BooksService(IOptions<BookDatabaseSettings> bookdatabasesettings)
        {
            var mongoclient = new MongoClient(bookdatabasesettings.Value.ConnectionString);

            var mongodatabase = mongoclient.GetDatabase(bookdatabasesettings.Value.DatabaseName);

            bookcollection = mongodatabase.GetCollection<Books>(bookdatabasesettings.Value.BooksCollectionName);
        }

        public async Task<List<Books>> GetAsync() => 
            await bookcollection.Find(_ => true).ToListAsync();

        public async Task CreateAsync(Books newBook) =>
            await bookcollection.InsertOneAsync(newBook);

    }
}
