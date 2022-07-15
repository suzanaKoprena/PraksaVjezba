using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PraksaVjezba.Models.Response;
using PraksaVjezba.Models.Request;
using AutoMapper;
using PraksaVjezba.Entities;

namespace PraksaVjezba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        public static List<TodoItem> db;
        public readonly IMapper mapper;
        private readonly PraksaDbContext context;

        public TodoItemsController(IMapper mapper,PraksaDbContext context)
        {
            this.mapper=mapper;
            this.context = context;
            /*if (db == null)
            {
                db = new List<TodoItem>();
                db.Add(new TodoItem { Id = 1, Title = "Item1", Description = "Desc1", Status = 0, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
                db.Add(new TodoItem { Id = 2, Title = "Item2", Description = "Desc2", Status = 0, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
                db.Add(new TodoItem { Id = 3, Title = "Item3", Description = "Desc3", Status = 0, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
            }*/
        }


        [HttpGet]
        public List<TodoItemResponse> GetToDoItems()
        {
            return context.TodoItems.Select(a=>new TodoItemResponse { Title=a.Title, Description=a.Description}).ToList();
        }

        /*[HttpGet("{id}")]
        public ActionResult<TodoItemResponse> GetToDoItem(int id)
        {
            TodoItem item=null;
            return (item=db.FirstOrDefault(x => x.Id == id))!=null ? Ok(new TodoItemResponse { Title=item.Title, Description=item.Description}) : BadRequest();
            
        }*/

        [HttpGet("{id}")]
        public ActionResult<TodoItemResponse> GetToDoItem(int id)
        {
            var item = context.TodoItems.FirstOrDefault(x => x.Id == id);
            if (item != null)
                //return Ok(new TodoItemResponse { Title = item.Title, Description = item.Description });
                return Ok(mapper.Map<TodoItemResponse>(item));
            return BadRequest();

        }

        [HttpPost]
        public TodoItemResponse InsertTodoItem(TodoItemRequest input)
        {
            var item = mapper.Map<TodoItem>(input);
            context.TodoItems.Add(item);
            context.SaveChanges();
            return new TodoItemResponse { Title = item.Title, Description = item.Description };
        }

        [HttpPut("{id}")]
        public TodoItemResponse UpdateTodoItem(int id,TodoItemRequest input)
        {
            var tmp=context.TodoItems.FirstOrDefault(x => x.Id == id);
            if (tmp != null)
            {
                tmp.Title = input.Title;
                tmp.Description = input.Description;
                tmp.Status = input.Status;
                context.SaveChanges();
                return mapper.Map<TodoItemResponse>(tmp);
            }
            return null;
        }

        [HttpDelete("{id}")]
        public void DeleteTodoItem(int id)
        {
            context.TodoItems.Remove(db.FirstOrDefault(x => x.Id == id));
            context.SaveChanges();
        }

    }
}
