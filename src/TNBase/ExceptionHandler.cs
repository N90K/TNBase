using NLog;
using System;
using System.Threading;

namespace TNBase
{
    /// <summary>
    /// Handle unhandled exceptions (at least log them!)
    /// </summary>
    public static class ExceptionHandler
    {
        // Logging instance
        private static Logger log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Unhandled exception handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void AppDomain_CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception) e.ExceptionObject;
            log.Fatal(ex, $"Fatal exception occured: {ex.Message}");
        }

        /// <summary>
        /// Unhandled exception handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void AppDomain_Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Exception ex = (Exception)e.Exception;
            log.Fatal(ex, $"Fatal (thread) exception occured: {ex.Message}");
        }
    }
}
