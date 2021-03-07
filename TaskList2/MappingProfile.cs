using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskList2.Entities;
using TaskList2.Models;

namespace TaskList2
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
            CreateMap<Entities.Task, TaskModel>();
            CreateMap<TaskModel, Entities.Task>();
            CreateMap<Entities.ListTask, ListTaskModel>();
            CreateMap<ListTaskModel, Entities.ListTask>();
            CreateMap<Entities.HistoryTask, HistoryTaskModel>();
            CreateMap<HistoryTaskModel, Entities.HistoryTask>();
        }
    }
}
