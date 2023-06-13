using Microsoft.Extensions.Options;

namespace Expenses.Api.Options
{
    public class DataBaseOptionsSetup : IConfigureOptions<DataBaseOptions>
    {
        private const string ConfigurationSectionName = "DataBaseOptions";
        private readonly IConfiguration _configuration;

        public DataBaseOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(DataBaseOptions options)
        {
            var connectionString = _configuration.GetConnectionString("ConnectionString");
            options.ConnectionString = connectionString;
            _configuration.GetSection(ConfigurationSectionName).Bind(options);
        }
    }
}
