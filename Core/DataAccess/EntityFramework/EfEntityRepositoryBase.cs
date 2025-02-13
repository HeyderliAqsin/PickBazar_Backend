﻿using Core.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
       where TEntity : class, IEntity, new()
       where TContext : IdentityDbContext, new()

    {
        public void Add(TEntity entity)
        {
            using TContext context = new();
            var addedEntity=context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
           
        }

        public void Delete(TEntity entity)
        {
            using TContext context = new();
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>>? filters = null)
        {
            using TContext context=new();
            return context.Set<TEntity>().SingleOrDefault(filters);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filters = null)
        {
            using TContext context = new();

            return filters == null ?
                context.Set<TEntity>().ToList() :
                context.Set<TEntity>().Where(filters).ToList();
        }

        public void Update(TEntity entity)
        {
            using TContext context = new();
            var updateEntity = context.Entry(entity);
            updateEntity.State = EntityState.Modified;
            context.SaveChanges();

        }
    }
}
