using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reconcilation.Management.Application.Contracts.Infrastructure;
using Reconcilation.Management.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconcilation.Management.Infrastructure.Configurations
{
    public static class InfrastructureServiceRegisterations
    {

        public static IServiceCollection AddInfrastructureServcies(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<ICsvProcessor, CsvProcessorRepo>();


            return services;
        }
    }
}
