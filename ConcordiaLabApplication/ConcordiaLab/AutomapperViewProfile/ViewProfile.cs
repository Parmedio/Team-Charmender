﻿using AutoMapper;
using BusinessLogic.DTOs.BusinessDTO;
using ConcordiaLab.ViewModels;

namespace ConcordiaLab.AutomapperViewProfile
{
    public class ViewProfile : Profile
    {
        public ViewProfile()
        {
            CreateMap<BusinessScientistDto, ViewMScientist>()
                .ForMember("UserName", opt => opt.MapFrom(src => src.Name));

            CreateMap<BusinessExperimentDto, ViewMExperiment>()
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.LastComment, opt => opt.MapFrom(src => src.lastComment.CommentText))
                .ForMember(dest => dest.AuthorComment, opt => opt.MapFrom(src => src.lastComment.CreatorName))
                .ForMember(dest => dest.BelongToList, opt => opt.MapFrom(src => src.ListName));

            CreateMap<BusinessListDto, ViewMList>();
        }
    }
}