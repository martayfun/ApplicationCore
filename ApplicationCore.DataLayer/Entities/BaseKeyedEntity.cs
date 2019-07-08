namespace ApplicationCore.DataLayer.Entities
{
    public class BaseKeyedEntity<T> : BaseEntity
    {
        public T Id { get; set; }

        public BaseKeyedEntity()
        {
            if (typeof(T).Equals(typeof(System.Guid)))
                this.Id = (T)(object)System.Guid.NewGuid();
        }
    }
}
