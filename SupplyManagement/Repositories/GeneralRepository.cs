using SupplyManagement.Contracts;
using SupplyManagement.Data;

namespace SupplyManagement.Repositories
{
    public class GeneralRepository<TEntity> : IGeneralRepository<TEntity> where TEntity : class
    {
        protected readonly BookingDbContext _context;

        public GeneralRepository(BookingDbContext context)
        {
            _context = context;
        }

        public ICollection<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity? GetById(int Id)
        {
            var entity = _context.Set<TEntity>().Find(Id);
            _context.ChangeTracker.Clear();
            return entity;
        }

        public TEntity? Create(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch
            {
                return null;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Update(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsExist(int id)
        {
            return GetById(id) is not null;
        }
    }
}
