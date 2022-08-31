using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoRestService.Services;
using TodoRestService.ViewModels;

namespace TodoRestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private ITodoItemService _ItemServiceProvider;
        private IDocumentService _DocumentServiceProvider;


        public TodoItemsController(ITodoItemService todoItemService, IDocumentService documentService)
        {
            _ItemServiceProvider = todoItemService;
            _DocumentServiceProvider = documentService;


        }


        [HttpGet]
        public async Task<IEnumerable<ToDoItemViewModel>> GetTodoItems()
        {

            var GetItemsResponse = _ItemServiceProvider.GetItems();

            return GetItemsResponse;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItemViewModel>> GetTodoItem(int id)
        {

            var GetItemByIdResponse = _ItemServiceProvider.GetItemById(id);

            if (GetItemByIdResponse == null)
            {
                return NotFound();
            }
            else
            {

                return GetItemByIdResponse;

            };
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(int id, [FromForm] ToDoItemBaseViewModel ToDoItem)
        {

            var UpdateItembyIdResponse = _ItemServiceProvider.UpdateItem(id, ToDoItem);

            if (UpdateItembyIdResponse == false)
            { return BadRequest(); }

            return Ok("Item is Updated");


        }

        [HttpPost]
        public async Task<IActionResult> PostTodoItem([FromForm] ToDoItemBaseViewModel ToDoItem)
        {



            var PostItemResponse = _ItemServiceProvider.PostItem(ToDoItem);

            if (PostItemResponse == false)
            { return BadRequest(); }



            if (ToDoItem.ImageFile != null)

            { var app = _DocumentServiceProvider.UploadImage(ToDoItem); }

            return Ok("Item is Posted");
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var DeleteItembyIdResponse = _ItemServiceProvider.DeleteItem(id);


            if (DeleteItembyIdResponse == false)
            {
                return NotFound();
            }

            else
            {

                return Ok("Item is Deleted");
            };
        }


    }
}
