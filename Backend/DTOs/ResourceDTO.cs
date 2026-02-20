namespace TopitoAPI.DTOs
{
    public class ResourceDto
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string OwnerLogin { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Price { get; set; }
        public int ConditionId { get; set; }
        public string ConditionName { get; set; } = string.Empty;
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
    }

    public class CreateResourceDto
    {
        public int OwnerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Price { get; set; }
        public int ConditionId { get; set; }
        public int StatusId { get; set; } = 1; // По умолчанию "Выставлен"
    }

    public class UpdateResourceDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public int? ConditionId { get; set; }
        public int? StatusId { get; set; }
    }
}