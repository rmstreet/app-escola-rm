
namespace AppEscolaRM.Infra.Data.UoW
{
    using AppEscolaRM.Domain.Interfaces;
    using System;
    using AppEscolaRM.Domain.Core.Commands;
    using AppEscolaRM.Infra.Data.Context;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly EscolaRMContext _context;

        public UnitOfWork(EscolaRMContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
