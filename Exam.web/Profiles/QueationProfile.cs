using AutoMapper;
using Exam.web.Entities;
using Exam.web.ViewModels.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.web.Profiles
{
    public class QueationProfile : Profile
    {
        public QueationProfile()
        {
            CreateMap<CreateQueationViewModel, Questions>()
                .ForMember(
                dest => dest.Question,
                opt => opt.MapFrom(src => src.Question)
                );
            CreateMap<Questions, EditquestionViewModel>();
            CreateMap<EditquestionViewModel, Questions>();
            CreateMap<Questions, QuestionsViewModel>();
            //CreateMap<List<Questions>, List<QuestionsViewModel>>();
            CreateMap<List<QuestionsViewModel>, List<Questions>>();
            CreateMap<QuestionsViewModel, Questions>();
        }
    }
}
