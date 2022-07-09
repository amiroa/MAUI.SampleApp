using SQLite;

namespace OA.Public.Maui.SampleApp.Services.Database
{
    public static class DatabaseService
    {
        static SQLiteAsyncConnection _connection;

        static async Task Init()
        {
            if (_connection != null)
                return;

            // Get an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "OAMAUIApp.db");

            _connection = new SQLiteAsyncConnection(databasePath);

            await _connection.CreateTableAsync<PrinterInfo>();
        }


        public static async Task Add(object record)
        {
            await Init();

            await _connection.InsertAsync(record);
        }

        public static async Task Remove(object record)
        {
            await Init();

            await _connection.DeleteAsync(record);
        }

        public static async Task<T> Get<T>(object pk) where T : new()
        {
            await Init();

            return await _connection.GetAsync<T>(pk);
        }

        public static async Task<List<T>> GetAll<T>() where T : new()
        {
            await Init();

            return await _connection.Table<T>().ToListAsync();
        }
    }
}
