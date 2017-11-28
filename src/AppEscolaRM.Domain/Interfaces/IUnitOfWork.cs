
namespace AppEscolaRM.Domain.Interfaces
{
    using Core.Commands;
    using System;

    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
