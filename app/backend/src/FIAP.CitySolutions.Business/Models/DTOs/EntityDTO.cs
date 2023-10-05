namespace FIAP.CitySolutions.Business.Models.DTOs
{
    public abstract class EntityDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool Active { get; set; } = true;
    }
}
