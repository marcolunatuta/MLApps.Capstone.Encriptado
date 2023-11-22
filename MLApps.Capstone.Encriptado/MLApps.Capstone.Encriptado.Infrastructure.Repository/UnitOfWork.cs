using MLApps.Capstone.Encriptado.Infrastructure.Interface;
using System;
using System.Runtime.InteropServices;

namespace MLApps.Capstone.Encriptado.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEncriptadosRepository Encriptados { get; }

        public UnitOfWork(IEncriptadosRepository encriptados)
        {
            Encriptados = encriptados;
        }

        private bool isDisposed;
        private IntPtr nativeResource = Marshal.AllocHGlobal(100);

        // Dispose() calls Dispose(true)
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed)
            {
                return;
            }

            if (disposing)
            {
                // free managed resources
            }

            // free native resources if there are any.
            if (nativeResource != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeResource);
                nativeResource = IntPtr.Zero;
            }

            isDisposed = true;
        }

        // NOTE: Leave out the finalizer altogether if this class doesn't
        // own unmanaged resources, but leave the other methods
        // exactly as they are.
        ~UnitOfWork()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }
    }
}