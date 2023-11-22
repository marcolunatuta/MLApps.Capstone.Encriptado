using NLog;
using NLog.Config;
using NLog.Targets;

namespace MLApps.Capstone.Encriptado.Transversal.Logging
{
    public static class FileTarget
    {
        private const string Dateformat = "yyyyMMdd";
        private const int MaxArchivedays = 14;

        public static void TextFile(LogLevel logLevel, string targetName = "default")
        {
            var target = new NLog.Targets.FileTarget(targetName)
            {
                CreateDirs = true,
                ArchiveEvery = FileArchivePeriod.Day,
                ArchiveFileName = "file-{########}.zip",
                ArchiveNumbering = ArchiveNumberingMode.Date,
                ArchiveDateFormat = Dateformat,
                ArchiveOldFileOnStartup = true,
                EnableArchiveFileCompression = true,
                MaxArchiveDays = MaxArchivedays,
                FileName = @"C:\temp\MLApps.Capstone.Encriptado\file.log",
                Layout = "${longdate}|${aspnet-traceidentifier:whenEmpty=${event-properties:item=EventId:whenEmpty=0}}|${level:uppercase=true}|${logger}|${message} ${exception:format=tostring}"
            };

            NLog.Targets.Wrappers.AsyncTargetWrapper asyncFileTarget = new NLog.Targets.Wrappers.AsyncTargetWrapper(target)
            {
                Name = target.Name,
                BatchSize = 20,
            };

            // Keep original configuration
            LoggingConfiguration config = LogManager.Configuration ?? new LoggingConfiguration();
            config.AddTarget(target.Name, asyncFileTarget);

            LoggingRule rule = new LoggingRule("*", logLevel, target);
            config.LoggingRules.Add(rule);

            LogManager.Configuration = config;
        }
    }
}