using AutoMapper;
using PraksaVjezba.Controllers;
using PraksaVjezba.Models;
using PraksaVjezba.Models.Request;
using PraksaVjezba.Models.Response;

namespace PraksaVjezba
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoItem, TodoItemResponse>();
            // .ForMember(dst => dst.Title, opc => opc.MapFrom((src, dst) => src.Title));


            CreateMap<TodoItemRequest, TodoItem>()
                .ConvertUsing((src,dst)=>MapServiceInformation(src));
        }
        
        private TodoItem MapServiceInformation(TodoItemRequest request)
        {
            return new TodoItem { 
                Id=TodoItemsController.db.Count+1,
                Title=request.Title,
                Description=request.Description,
                Status=request.Status,
                CreatedDate=DateTime.Now,
                UpdatedDate=DateTime.Now
            };
        }
    }
}
