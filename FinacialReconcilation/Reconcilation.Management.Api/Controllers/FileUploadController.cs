using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reconcilation.Management.Application.Features.FileParser.Query.CompareFile;
using Reconcilation.Management.Application.Features.FileParser.Query.ExportUnmatchFileResult;
using Reconcilation.Management.Application.Features.FileParser.Query.GetUnmatchFileResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reconcilation.Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : Controller
    {

        private readonly IMediator _mediator;

        private readonly ILogger<FileUploadController> _logger;


        public FileUploadController(IMediator mediator, ILogger<FileUploadController> logger)
        {
            _mediator = mediator;

            _logger = logger;
        }

        [HttpPost]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<FileCompareResultVm>> GetFileCompareResult([FromForm] GetFilesCompareQuery getFilesCompareQuery)
        {
            _logger.LogInformation($"About to call {nameof(GetFilesCompareQuery)} handler");

            var compareFileResultVm = await _mediator.Send(getFilesCompareQuery);

            return Ok(compareFileResultVm);
        }


        [HttpPost("unmatchfileresult")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<List<UnmatchFileResultVm>>> GetFileUnmatchResult([FromForm] UnmatchResultQuery unmatchResultQuery)
        {
            _logger.LogInformation($"About to call {nameof(UnmatchResultQuery)} handler");

            var unmatchFileResultVms = await _mediator.Send(unmatchResultQuery);

            return Ok(unmatchFileResultVms);
        }


        [HttpGet("exportUnmatchResults")]
        public async Task<FileResult> ExportEvent()
        {

            var exportEventQuery = new GetExportFileQuery();

            _logger.LogInformation($"About to call {nameof(GetExportFileQuery)} handler");


            var exportEventResult = await _mediator.Send(exportEventQuery);

            return File(exportEventResult.Data, exportEventResult.ContentType, exportEventResult.EventExportFileName);
        }
    }
}
