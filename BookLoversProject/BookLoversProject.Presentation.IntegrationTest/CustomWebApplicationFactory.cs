using BookLoversProject.Infrastructure;
using BookLoversProject.Presentation;
using BookLoversProject.Presentation.IntegrationTest.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineBookStore.IntegrationTests
{
    namespace SocialMedia.Host.IntegrationTests
    {
        public class CustomWebApplicationFactory<TStartup>
            : WebApplicationFactory<TStartup> where TStartup : class
        {
            private SqliteConnection _connection;

            public CustomWebApplicationFactory()
            {
                _connection = new SqliteConnection("DataSource=:memory:");
                _connection.Open();
            }

            protected override void ConfigureWebHost(IWebHostBuilder builder)
            {
                builder.ConfigureServices(services =>
                {
                    var serviceDescriptor = services.SingleOrDefault(d => d.ServiceType ==
                                                                        typeof(DbContextOptions));
                    services.Remove(serviceDescriptor);

                    // Create a new service provider.
                    var serviceProvider = new ServiceCollection()
                        .AddEntityFrameworkSqlite()
                        .BuildServiceProvider();

                    services.AddDbContext<ApplicationContext>(options =>
                    {
                        options.UseSqlite(_connection);
                        options.UseInternalServiceProvider(serviceProvider);
                    }, ServiceLifetime.Scoped);

                    // Build the service provider.
                    var sp = services.BuildServiceProvider();

                    using (var scope = sp.CreateScope())
                    {
                        var scopedServices = scope.ServiceProvider;

                        var db = scopedServices.GetRequiredService<ApplicationContext>();

                        db.Database.EnsureDeleted();

                        // Ensure the database is created.
                        db.Database.EnsureCreated();

                        // Seed the database with test data.
                        Utilities.InitializeDbForTests(db);
                    }
                });
            }

            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);
                _connection.Close();
                _connection.Dispose();
            }
        }
    }

}
