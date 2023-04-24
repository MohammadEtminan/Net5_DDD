namespace OnLineStore.Domain.Frameworks.Abstracts
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}