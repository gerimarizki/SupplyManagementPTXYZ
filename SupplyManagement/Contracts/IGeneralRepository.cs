namespace SupplyManagement.Contracts
{
    public interface IGeneralRepository<TEntity>
    {
        ICollection<TEntity> GetAll();
        TEntity? GetById(int id);
        TEntity? Create(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
        bool IsExist(int id);
    }
}
