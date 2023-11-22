
using System;

namespace MLApps.Capstone.Encriptado.Transversal.Common.Interfaces
{
    /// <summary>
    /// logging
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAppLogger<T>
    {
        #region Trace

        /// <summary>
        /// Log Trace
        /// </summary>
        /// <param name="message"></param>
        void LogTrace(string message);

        /// <summary>
        /// Log Trace
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void LogTrace(string message, params object[] args);

        #endregion Trace

        #region Debug

        /// <summary>
        /// Log Debug
        /// </summary>
        /// <param name="message"></param>
        void LogDebug(string message);

        /// <summary>
        /// Log Debug
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void LogDebug(string message, params object[] args);

        #endregion Debug

        #region Information

        /// <summary>
        /// Log Information
        /// </summary>
        /// <param name="message"></param>
        void LogInformation(string message);

        /// <summary>
        /// Log Information
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void LogInformation(string message, params object[] args);

        #endregion Information

        #region Warning

        /// <summary>
        /// Log Warning
        /// </summary>
        /// <param name="message"></param>
        void LogWarning(string message);

        /// <summary>
        /// Log Warning
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void LogWarning(string message, params object[] args);

        #endregion Warning

        #region Error

        /// <summary>
        /// Log Error
        /// </summary>
        /// <param name="ex"></param>
        void LogError(Exception ex);

        /// <summary>
        /// Log Error
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        void LogError(Exception ex, string message);

        /// <summary>
        /// Log Error
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void LogError(Exception ex, string message, params object[] args);

        #endregion Error
    }
}
