using FluentValidation;
using MediatR;
using Reconcilation.Management.Application.Contracts.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reconcilation.Management.Application.Features.FileParser.Query.CompareFile
{
    public class GetFileCompareHandler : IRequestHandler<GetFilesCompareQuery, FileCompareResultVm>
    {
        private readonly ICsvProcessor _csvProcessor;

        public GetFileCompareHandler(ICsvProcessor csvProcessor)
        {
            _csvProcessor = csvProcessor;
        }

        public async Task<FileCompareResultVm> Handle(GetFilesCompareQuery request, CancellationToken cancellationToken)
        {
            var fileCompareResultResponse = new FileCompareResultVm();

            var validator = new GetFileCompareValidator();

            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                fileCompareResultResponse.Success = false;
                fileCompareResultResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    fileCompareResultResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            else
            {
                var fileContents = await _csvProcessor.ProcessUploadedCsvFile(request);

                foreach (var item in fileContents)
                {
                    fileCompareResultResponse.fileCompareDtos.Add(item);
                }

            }

            return fileCompareResultResponse;
        }
    }
}
