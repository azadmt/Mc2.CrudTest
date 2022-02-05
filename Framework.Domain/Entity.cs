namespace Framework.Domain
{
    public abstract class Entity<TKey>
    {
        public TKey Id { get; protected set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;

            var entity = (Entity<TKey>)obj;
            return this.Id.Equals(entity.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
