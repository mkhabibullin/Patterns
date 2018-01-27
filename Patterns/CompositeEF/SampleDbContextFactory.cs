using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;

namespace CompositeEF
{
    public class SampleDbContextFactory : IDisposable
    {
        private DbConnection _connection;

        private DbContextOptions<SampleDbContext> CreateOptions()
        {
            return new DbContextOptionsBuilder<SampleDbContext>()
                .UseSqlite(_connection).Options;
        }

        public SampleDbContext CreateContext()
        {
            if (_connection == null)
            {
                _connection = new SqliteConnection("DataSource=:memory:");
                _connection.Open();

                var options = CreateOptions();
                using (var context = new SampleDbContext(options))
                {
                    context.Database.EnsureCreated();
                }
            }

            return new SampleDbContext(CreateOptions());
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}
