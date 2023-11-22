using MLApps.Capstone.Encriptado.Transversal.Common.Interfaces;
using NLog;
using System;

namespace MLApps.Capstone.Encriptado.Transversal.Logging
{
    public class AppLogger<T> : IAppLogger<T>
    {
        private static readonly ILogger nlog = LogManager.GetLogger(typeof(T).FullName);

        public void LogDebug(string message, params object[] args)
        {
            nlog.Debug(message, args);
        }

        public void LogDebug(string message)
        {
            nlog.Debug(message);
        }

        public void LogError(Exception ex)
        {
            nlog.Error(ex, string.Empty);
        }

        public void LogError(Exception ex, string message)
        {
            nlog.Error(ex, message);
        }

        public void LogError(Exception ex, string message, params object[] args)
        {
            nlog.Error(ex, message, args);
        }

        public void LogInformation(string message)
        {
            nlog.Info(message);
        }

        public void LogInformation(string message, params object[] args)
        {
            nlog.Info(message, args);
        }

        public void LogTrace(string message)
        {
            nlog.Trace(message);
        }

        public void LogTrace(string message, params object[] args)
        {
            nlog.Trace(message, args);
        }

        public void LogWarning(string message)
        {
            nlog.Warn(message);
        }

        public void LogWarning(string message, params object[] args)
        {
            nlog.Warn(message, args);
        }
    }
}
