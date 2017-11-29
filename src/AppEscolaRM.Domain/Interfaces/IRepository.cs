
namespace AppEscolaRM.Domain.Interfaces
{
    using AppEscolaRM.Domain.Core.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        TEntity Adicionar(TEntity obj);
        TEntity ObterPorId(Guid id);
        List<TEntity> ObterTodos(int take = 100, int skip = 0, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        TEntity Atualizar(TEntity obj);
        bool Remover(Guid id);
        List<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        int SaveChances();
    }
}
