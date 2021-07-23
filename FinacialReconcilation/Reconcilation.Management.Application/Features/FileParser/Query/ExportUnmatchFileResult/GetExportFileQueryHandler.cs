using MediatR;
using Microsoft.Extensions.Logging;
using Reconcilation.Management.Application.Contracts.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reconcilation.Management.Application.Features.FileParser.Query.ExportUnmatchFileResult
{
    public class GetExportFileQueryHandler : IRequestHandler<GetExportFileQuery, ExportFileVm>
    {
        private readonly ILogger<GetExportFileQueryHandler> _logger;

        private readonly ICsvProcessor _csvProcessor;
        public GetExportFileQueryHandler(ILogger<GetExportFileQueryHandler> logger, ICsvProcessor csvProcessor)
        {
            _logger = logger;

            _csvProcessor = csvProcessor;
        }
        public async Task<ExportFileVm> Handle(GetExportFileQuery request, CancellationToken cancellationToken)
        {

            var fileDataContent =  _csvProcessor.ExportUnmatchRecords();

            var eventFileContentToReturn = new ExportFileVm
            {
                Data = fileDataContent,

                ContentType = "text/csv",

                EventExportFileName = $"{Guid.NewGuid()}.csv"
            };

            return eventFileContentToReturn;
        }
    }
}
