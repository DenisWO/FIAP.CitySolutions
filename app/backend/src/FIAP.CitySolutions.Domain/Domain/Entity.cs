namespace FIAP.CitySolutions.Domain.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; set; }  = Guid.NewGuid();
        public bool Active { get; set; } = true;
    }
}
