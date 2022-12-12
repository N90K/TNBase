using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using TNBase.DataStorage;
using TNBase.External.DataImport;
using TNBase.Repository;

namespace TNBase
{
    static class Program
    {
        private static string applicationDataDirectory;

        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new ThreadExceptionEventHandler(ExceptionHandler.AppDomain_Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(ExceptionHandler.AppDomain_CurrentDomain_UnhandledException);

#if DEBUG
            applicationDataDirectory = AppDomain.CurrentDomain.BaseDirectory;
#else
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            applicationDataDirectory = Path.Combine(appDataPath, Application.CompanyName, Application.ProductName);
            Directory.CreateDirectory(applicationDataDirectory);
#endif

            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            var databaseManager = ServiceProvider.GetRequiredService<DatabaseManager>();
            databaseManager.BackupDatabase();

            ModuleGeneric.SaveStartTime();

            var context = (TNBaseContext)ServiceProvider.GetRequiredService<ITNBaseContext>();
            context.UpdateDatabase();

            var serviceLayer = ServiceProvider.GetRequiredService<IServiceLayer>();
            serviceLayer.ResumePausedListeners();
            serviceLayer.UpdateYearStatsInternal();
            serviceLayer.DeleteOverdueDeletedListeners(Properties.Settings.Default.MonthsUntilDelete);

            var form = ServiceProvider.GetRequiredService<FormMain>();
            Application.Run(form);
        }

        public static void NewScope()
        {
            var scope = ServiceProvider.CreateScope();
            ServiceProvider = scope.ServiceProvider;
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            var databasePath = Path.Combine(applicationDataDirectory, "Listeners.s3db");
            services.AddScoped<ITNBaseContext>(s => new TNBaseContext($"Data Source={databasePath}"));
            services.AddScoped<IServiceLayer, ServiceLayer>();
            services.AddScoped<ScanService>();
            services.AddScoped<CsvImportService>();

            var resourceDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resource");
            services.AddSingleton(s => new ResourceManager(resourceDirectory));

            services.AddSingleton(s => new DatabaseManagerOptions { DatabasePath = databasePath });
            services.AddScoped<DatabaseManager>();

            services.AddScoped<FormMain>();
        }
    }
}
