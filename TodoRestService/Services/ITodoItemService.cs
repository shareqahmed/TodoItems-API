using System.Collections.Generic;
using TodoRestService.ViewModels;

namespace TodoRestService.Services
{
    public interface ITodoItemService
    {
        bool DeleteItem(int id);
        ToDoItemViewModel GetItemById(int id);
        IEnumerable<ToDoItemViewModel> GetItems();
        bool PostItem(ToDoItemBaseViewModel ToDoItem);
        bool UpdateItem(int id, ToDoItemBaseViewModel ToDoItem);
    }
}