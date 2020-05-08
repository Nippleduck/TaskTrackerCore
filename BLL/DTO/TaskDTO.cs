using AutoMapper;
using BLL.Mapper;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class TaskDTO : IMapFrom<Task>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal ExecutedPercent { get; set; }
        public int State { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime Deadline { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Task, TaskDTO>()
                .ForMember(d => d.ExecutedPercent, opt => opt.MapFrom(src => src.TaskStatus.ExecutedPercent))
                .ForMember(d => d.State, opt => opt.MapFrom(src => src.TaskStatus.State))
                .ForMember(d => d.BeginDate, opt => opt.MapFrom(src => src.DateInfo.BeginDate))
                .ForMember(d => d.Deadline, opt => opt.MapFrom(src => src.DateInfo.Deadline))
                .ReverseMap();
        }
    }
}
