using AutoMapper;
using BLL.Enums;
using BLL.Mapper;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class ProjectDTO : IMapFrom<Project>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descrition { get; set; }
        public int Status { get; set; }
        public string Manager { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Project, ProjectDTO>()
                .ForMember(d => d.Manager, opt => opt.MapFrom(src => src.Manager.Name))
                .ForMember(d => d.Status, opt => opt.MapFrom(src => (int)src.Status))
                .ReverseMap();
        }
    }
}
