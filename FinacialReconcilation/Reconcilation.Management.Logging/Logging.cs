using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Formatting.Json;
using Serilog.Sinks.Elasticsearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


namespace Reconcilation.Management.Logging
{
    public static class Logging
    {
        public static Action<HostBuilderContext, LoggerConfiguration> ConfigureLogger =>

            (hostBuilderContext, loggerConfiguration) =>
            {

                var env = hostBuilderContext.HostingEnvironment;

                var serviceName = hostBuilderContext.Configuration.GetValue<string>("Logging:LogIndexName");

                loggerConfiguration.MinimumLevel.Information()
                .Enrich.FromLogContext()
                .Enrich.WithProperty("ApplicationName", env.ApplicationName)
                .Enrich.WithProperty("EnvironmentName", env.EnvironmentName)
                .Enrich.WithExceptionDetails()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System.Net.Http", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.Hosting.LifeTime", LogEventLevel.Information)
                .WriteTo.File(new JsonFormatter(), @$"c:\{serviceName}\logs\{serviceName}-{DateTime.Today.ToString("yyyy-MM-dd")}.json")
                .WriteTo.Console();

                if (hostBuilderContext.HostingEnvironment.IsDevelopment())
                {
                    loggerConfiguration.MinimumLevel.Override("Reconcilation.Management.Infrastructure", LogEventLevel.Debug);
                }

                var elasticUri = hostBuilderContext.Configuration.GetValue<string>("Logging:ElasticUri");

                if (!string.IsNullOrEmpty(elasticUri))
                {
                    loggerConfiguration.WriteTo.Elasticsearch(

                    new ElasticsearchSinkOptions(new Uri(elasticUri))
                    {
                        AutoRegisterTemplate = true,
                        AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
                        IndexFormat = "Reconcilation-logs-{0:yyyy.MM.dd}",
                        MinimumLogEventLevel = LogEventLevel.Debug
                    }
                    );
                }
            };

    }
}
