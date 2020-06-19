using ExpensesTrackerApp.Core;
using ExpensesTrackerApp.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpensesTrackerApp.DataAccess.SqlServer.Repositories
{
    public class DataRepository : IDataRepository
    {
        private readonly ExpensesTrackerAppContext dataContext;

        public DataRepository(ExpensesTrackerAppContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntityBase
        {
            return dataContext.Set<TEntity>();
        }

        void IDataRepository.Delete<TEntity>(TEntity entity)
        {
            var dbEntity = dataContext.Set<TEntity>()
                .SingleOrDefault(e => e.Id == entity.Id);
            if (dbEntity != null)
            {
                dataContext.Remove(dbEntity);
            }
        }

        void IDataRepository.Insert<TEntity>(TEntity entity)
        {
            dataContext.Add(entity);
        }

        void IDataRepository.Update<TEntity>(TEntity entity)
        {
            dataContext.Update(entity);
        }
    }
}
