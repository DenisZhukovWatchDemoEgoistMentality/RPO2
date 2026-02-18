using TopitoAPI.Models;

namespace TopitoAPI.Data
{
    public static class SeedData
    {
        public static async Task Initialize(ApplicationDbContext context)
        {
            // Проверяем, есть ли уже данные в справочниках
            if (context.ResourceStatuses.Any() || context.Conditions.Any() || context.OrderStatuses.Any())
                return;

            // ResourceStatus
            var resourceStatuses = new List<ResourceStatus>
            {
                new ResourceStatus { Name = "Выставлен" },
                new ResourceStatus { Name = "Продан" }
            };
            await context.ResourceStatuses.AddRangeAsync(resourceStatuses);

            // Conditions
            var conditions = new List<Condition>
            {
                new Condition { Name = "Новый" },
                new Condition { Name = "Б/У" }
            };
            await context.Conditions.AddRangeAsync(conditions);

            // OrderStatus
            var orderStatuses = new List<OrderStatus>
            {
                new OrderStatus { Name = "Ожидание" },
                new OrderStatus { Name = "Продан" },
                new OrderStatus { Name = "Отменён" }
            };
            await context.OrderStatuses.AddRangeAsync(orderStatuses);

            // Тестовый пользователь
            var testUser = new User
            {
                Login = "testuser",
                Mail = "test@example.com",
                Password = "password123",
                Balance = 1000
            };
            await context.Users.AddAsync(testUser);

            // Тестовый админ
            var testAdmin = new Admin
            {
                Login = "admin",
                Password = "admin123"
            };
            await context.Admins.AddAsync(testAdmin);

            await context.SaveChangesAsync();
        }
    }
}