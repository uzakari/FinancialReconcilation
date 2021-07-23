using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Reconcilation.Management.Application.Features.FileParser.Query.GetUnmatchFileResult;
using Reconcilation.Management.Application.Models.File;

namespace Reconcilation.Management.Application.Profiles
{
    public class MappingProfiles: Profile
    {

        public MappingProfiles()
        {
            CreateMap<FileFormat, UnmatchFileResultContent>();
        }
    }
}
