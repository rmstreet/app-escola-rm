
namespace AppEscolaRM.Infra.Data.Repository
{
    using Domain.Core.Models;
    using Domain.Interfaces;
    using Data.Context;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected EscolaRMContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(EscolaRMContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public TEntity Adicionar(TEntity obj)
        {
            var objreturn = DbSet.Add(obj);
            return objreturn;
        }

        public TEntity Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;

            return obj;

        }

        public List<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate).ToList();
        }        

        public TEntity ObterPorId(Guid id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }

        public List<TEntity> ObterTodos(int take = 100, int skip = 0, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            List<TEntity> lista = null;

            var query = from item in DbSet.AsNoTracking()
                        orderby orderBy
                        select item;

            if (filter != null && (take != 0 || skip != 0))
                lista = query
                        .Where(filter)
                        .Take(take)
                        .Skip(skip)
                        .ToList();

            if (filter != null && take == 0 && skip == 0)
                lista = query
                    .Where(filter)
                    .Take(100)
                    .ToList();

            else if (filter == null && take == 0 && skip == 0)
                lista = query
                    .Take(1000)
                    .ToList();

            else
                lista = query
                     .Take(take)
                     .Skip(skip)
                     .ToList();

            return lista;
        }

        public bool Remover(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
            return true;
        }

        public int SaveChances()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
