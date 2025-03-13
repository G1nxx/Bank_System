namespace Domain.Primitives
{
    public class Entity
    {
        public Entity(uint id) => Id = id;
        protected Entity() {}
        public uint Id { get; protected set; }
    }
}
