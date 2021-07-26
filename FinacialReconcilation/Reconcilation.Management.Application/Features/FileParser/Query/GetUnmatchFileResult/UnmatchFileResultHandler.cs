using MediatR;
using Reconcilation.Management.Application.Contracts.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Reconcilation.Management.Application.Exceptions;

namespace Reconcilation.Management.Application.Features.FileParser.Query.GetUnmatchFileResult
{
    public class UnmatchFileResultHandler : IRequestHandler<UnmatchResultQuery, List<UnmatchFileResultVm>>
    {
        private readonly ICsvProcessor _csvProcessor;

        public UnmatchFileResultHandler(ICsvProcessor csvProcessor)
        {
            _csvProcessor = csvProcessor;
        }

        public async Task<List<UnmatchFileResultVm>> Handle(UnmatchResultQuery request, CancellationToken cancellationToken)
        {
            var fileCompareResultResponse = new List<UnmatchFileResultVm>();

            var validator = new GetUnmatchFileResultValidatior();

            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                fileCompareResultResponse.ForEach(a => {
                    a.Success = false;
                    a.ValidationErrors = new List<string>();
                    foreach (var error in validationResult.Errors)
                    {
                        a.ValidationErrors.Add(error.ErrorMessage);
                    }
                });
            }
            else
            {
                fileCompareResultResponse = await _csvProcessor.GetUnmatchFileResultUploaded(request);
            }


            return fileCompareResultResponse;

        }
    }
}
