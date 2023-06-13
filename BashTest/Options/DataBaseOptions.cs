﻿namespace Expenses.Api.Options
{
    public class DataBaseOptions
    {
        public string ConnectionString { get; set; } = string.Empty;
        public int CommandTimeout { get; set; }
        public bool EnableDetailedErrors { get; set; }
        public bool EnableSensitiveDataLogging { get; set; }
    }
}
