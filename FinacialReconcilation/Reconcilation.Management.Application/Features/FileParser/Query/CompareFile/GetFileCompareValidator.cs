using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconcilation.Management.Application.Features.FileParser.Query.CompareFile
{
    public class GetFileCompareValidator: AbstractValidator<GetFilesCompareQuery>
    {
        public GetFileCompareValidator()
        {
            RuleFor(p => p.FirstFile)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.SecondFile)
                .NotNull().WithMessage("{PropertyName} is required.");
        }
    }
}
