using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PraksaVjezba.Models.Response;
using PraksaVjezba.Models.Request;
using PraksaVjezba.Models;
using AutoMapper;

namespace PraksaVjezba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        public static List<TodoItem> db;
        public readonly IMapper mapper;
        public TodoItemsController(IMapper mapper)
        {
            this.mapper=mapper;
            if (db == null)
            {
                db = new List<TodoItem>();
                db.Add(new TodoItem { Id = 1, Title = "Item1", Description = "Desc1", Status = 0, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
                db.Add(new TodoItem { Id = 2, Title = "Item2", Description = "Desc2", Status = 0, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
                db.Add(new TodoItem { Id = 3, Title = "Item3", Description = "Desc3", Status = 0, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
            }
        }


        [HttpGet]
        public List<TodoItemResponse> GetToDoItems()
        {
            return db.Select(a=>new TodoItemResponse { Title=a.Title, Description=a.Description}).ToList();
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
            var item = db.FirstOrDefault(x => x.Id == id);
            if (item != null)
                //return Ok(new TodoItemResponse { Title = item.Title, Description = item.Description });
                return Ok(mapper.Map<TodoItemResponse>(item));
            return BadRequest();

        }

        [HttpPost]
        public TodoItemResponse InsertTodoItem(TodoItemRequest input)
        {
            var item = mapper.Map<TodoItem>(input);
            db.Add(item);
            return new TodoItemResponse { Title = item.Title, Description = item.Description };
        }

        [HttpPut("{id}")]
        public TodoItemResponse UpdateTodoItem(int id,TodoItemRequest input)
        {
            var tmp=db.FirstOrDefault(x => x.Id == id);
            int index=db.IndexOf(tmp);
            if (index != -1)
            {
                db[index].Title = input.Title;
                db[index].Description = input.Description;
                db[index].Status = input.Status;
                return mapper.Map<TodoItemResponse>(db[index]);
            }

            return null;
           
        }

        [HttpDelete("{id}")]
        public bool DeleteTodoItem(int id)
        {
            return db.Remove(db.FirstOrDefault(x => x.Id == id));
        }

    }
}
