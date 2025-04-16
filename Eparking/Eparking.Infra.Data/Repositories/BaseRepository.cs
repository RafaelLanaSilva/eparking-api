using Eparking.Domain.Contracts.Repositories;
using Eparking.Infra.Data.Context;

namespace Eparking.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        public void Add(TEntity entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(entity);
                dataContext.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(entity);
                dataContext.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(entity);
                dataContext.SaveChanges();
            }
        }

        public List<TEntity> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<TEntity>().ToList();
            }
        }
    }
}
