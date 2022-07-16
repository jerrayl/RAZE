using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RAZE.Entities;

namespace RAZE.Repositories
{
    public interface IDatabaseRepository<T> where T : BaseEntity
    {
        void Create(T entity);

        IEnumerable<T> Read();

        IEnumerable<T> Read(Func<T, bool> predicate, params Expression<Func<T, object>>[] navigationProperties);

        int Count();
    }
}