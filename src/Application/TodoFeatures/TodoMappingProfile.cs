using Application.TodoFeatures.Queries.GetTodos;
using AutoMapper;
using Domain.Entities;

namespace Application.TodoFeatures
{
    public class TodoMappingProfile : Profile
    {
        public TodoMappingProfile()
        {
            CreateMap<GetTodosDTO, Todo>().ReverseMap();
        }
    }
}
