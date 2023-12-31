﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repository.IRepository
{
    internal interface IRepository<T> where T : class
    {
        // repository hold related models that communicate with the DB and may have similar functionality
        // T - Category
        IEnumerable<T> GetAll();
        // takes object if type T as parameter of the function and should return boolean
        // the expression has to be boolean
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
    }
}
