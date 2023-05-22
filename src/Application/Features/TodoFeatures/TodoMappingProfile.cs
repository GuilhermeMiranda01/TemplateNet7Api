using Application.Features.TodoFeatures.Commands.CreateTodo;
using Application.Features.TodoFeatures.Commands.UpdateTodo;
using Application.Features.TodoFeatures.Queries.GetTodo;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.TodoFeatures
{
    public class TodoMappingProfile : Profile
    {
        public TodoMappingProfile()
        {
            CreateMap<GetTodoDTO, Todo>().ReverseMap();
            CreateMap<CreateTodoCommand, Todo>().ReverseMap();
            CreateMap<UpdateTodoCommand, Todo>().ReverseMap();
        }
    }
}
