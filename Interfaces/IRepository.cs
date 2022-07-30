namespace RepartitionTournoi.DAL.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T?> GetById(long id);
        Task DeleteById(long id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
    }
}
