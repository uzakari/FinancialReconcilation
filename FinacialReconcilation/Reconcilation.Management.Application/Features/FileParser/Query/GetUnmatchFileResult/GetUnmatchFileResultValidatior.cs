using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconcilation.Management.Application.Features.FileParser.Query.GetUnmatchFileResult
{
    public class GetUnmatchFileResultValidatior: AbstractValidator<UnmatchResultQuery>
    {

        public GetUnmatchFileResultValidatior()
        {
            RuleFor(p => p.FirstFile)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.SecondFile)
                .NotNull().WithMessage("{PropertyName} is required.");
        }
    }
}
