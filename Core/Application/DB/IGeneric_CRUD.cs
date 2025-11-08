namespace Core.Application.DB
{
    public interface IGeneric_CRUD
    {
        public Task<IEnumerable<T>> GetAllAsync<T>() where T : class;
        public Task<T> GetByIdAsync<T>(int id) where T : class;
        public Task UpdateAsync<T>(T entity) where T : class;
        public Task CreateAsync<T>(T entity) where T : class;
        public Task DeleteAsync<T>(int id) where T : class;

        public Task<IEnumerable<T>> Search<T>(dynamic param) where T : class;
    }
}
