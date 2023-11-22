using System;

namespace MLApps.Capstone.Encriptado.Infrastructure.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        //Ejemplo Customers
        IEncriptadosRepository Encriptados { get; }
    }
}