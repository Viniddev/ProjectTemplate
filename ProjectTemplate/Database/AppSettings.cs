using Microsoft.Extensions.Configuration;

namespace ProjectTemplate.Database
{
    internal class AppSettings
    {
        public string ReadConnectionString(string conectionString)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath($@"{AppDomain.CurrentDomain.BaseDirectory}")
                .AddJsonFile("appsettings.json")
                .Build();

            var conn = configuration.GetConnectionString(conectionString);
            return conn;
        }

    }
}
