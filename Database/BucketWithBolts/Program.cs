using BucketWithBolts.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BucketWithBolts
{
    internal class Program
    {
        private static IConfiguration _config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true)
            .Build();

        public static DatabaseContext Context;


        static void Main(string[] args)
        {
            try
            {
                Context = new DatabaseContext();

                bool useSqlServer = bool.Parse(_config["DbSettings:UseSqlServer"] ?? "false");
                if (useSqlServer)
                {
                    Console.WriteLine("Проверка обновлений базы данных...");
                    Context.Database.Migrate();
                    Console.WriteLine("База данных готова к работе.");
                }
                else
                    Context.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Критическая ошибка при старте БД: {ex.Message}");
                Console.ResetColor();
                return;
            }
        }
    }
}