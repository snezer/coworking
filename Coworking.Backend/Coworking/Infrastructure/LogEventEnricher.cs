using Serilog.Core;
using Serilog.Events;
using System.Diagnostics;
using System.Globalization;

namespace Coworking.Infrastructure
{
    public class LogEventEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("eventId", Guid.NewGuid()));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("appName", "data-presentation-440a"));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("level", GetElasticSearchLogLevelMnemonic(logEvent.Level)));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("text", logEvent.RenderMessage()));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("localTime", DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:sssZ", CultureInfo.InvariantCulture)));

            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("risCode", 81));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("projectCode", "CNTS"));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("threadName", Thread.CurrentThread.Name)); // ?
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("appType", "NET"));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("loggerName", "Serilog"));

            if (Activity.Current != null)
            {
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("traceId", Activity.Current.TraceId));
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("spanId", Activity.Current.SpanId));
            }
        }

        private string GetElasticSearchLogLevelMnemonic(LogEventLevel serilogLogLevel)
        {
            switch (serilogLogLevel)
            {
                case LogEventLevel.Verbose:
                    return "TRACE";

                case LogEventLevel.Debug:
                    return "DEBUG";

                case LogEventLevel.Information:
                    return "INFO";

                case LogEventLevel.Warning:
                    return "WARNING";

                case LogEventLevel.Error:
                    return "ERROR";

                default:
                    return "INFO";
            }
        }
    }
}
