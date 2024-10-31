using Microsoft.Extensions.Configuration;

namespace UVSSolution.Utilities
{
    public static class Handlers
    {
        public static string CommandHandler(string[] args)
        {
            return args[0].ToLower();
        }

        public static string[] OptionsHandler(string[] args)
        {
            return args.Skip(1).ToArray();
        }

        public static string GetConnectionString()
        {
            //reading configuration settings from json file
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            //extracting connection string from json file
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            //handling possible issues with connection string
            if (connectionString == null || connectionString == "")
            {
                Console.WriteLine("Invalid Databse Connection String");
                return "";
            }

            return connectionString;
        }
    }
}
