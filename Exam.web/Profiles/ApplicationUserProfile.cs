using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exam.web.ViewModels.Account;
using Exam.web.Entities;

namespace Exam.web.Profiles
{
    public class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateMap<RegisterViewModel, ApplicationUser>()
                .ForSourceMember(x => x.UserName, y => y.DoNotValidate())
            ;
            CreateMap<EditViewModel, ApplicationUser>();

            CreateMap<ApplicationUser, ApplicationUserViewModel>();
            CreateMap<ApplicationUserViewModel, ApplicationUser>();
        }
    }
}
