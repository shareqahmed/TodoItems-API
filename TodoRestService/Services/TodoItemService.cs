using System.Collections.Generic;
using System;
using TodoRestService.Models;
using TodoRestService.ViewModels;
using System.Linq;
using static TodoRestService.ViewModels.ToDoItemBaseViewModel;

namespace TodoRestService.Services
{
    public class TodoItemService : ITodoItemService
    {


        private readonly TodoContext _Context;
        public TodoItemService(TodoContext Context)
        {

            _Context = Context;
        }

        public bool PostItem(ToDoItemBaseViewModel ToDoItem)

        {

            try
            {
                var DbItem = new Item()

                {
                    TaskName = ToDoItem.TaskName,
                    FileName = ToDoItem.ImageFile != null ? ToDoItem.ImageFile.FileName : null,
                    TaskDescription = ToDoItem.TaskDescription,
                    StatusType = (int)ToDoItem.Status,
                    DueDate = ToDoItem.DueDate,
                    LastUpdateDateTime = DateTime.Now,
                    CreationDateTime = DateTime.Now
                };




                _Context.Items.Add(DbItem);

                _Context.SaveChanges();

                return true;
            }

            catch (Exception ex)
            { }
            return false;

        }



        public bool DeleteItem(int id)

        {

            if (!TodoItemExists(id))
            { return false; }

            else

            {
                var FindItem = _Context.Items.Find(id);
                _Context.Items.Remove(FindItem);
                _Context.SaveChanges();
                return true;
            }
        }


        public IEnumerable<ToDoItemViewModel> GetItems()
        {

            var MyList = _Context.Items.Select(p => new ToDoItemViewModel()
            {
                Id = p.Id,
                TaskDescription = p.TaskDescription,
                TaskName = p.TaskName,
                DueDate = p.DueDate,
                ImageName = p.FileName

            });
            return MyList;
        }


        public ToDoItemViewModel GetItemById(int id)
        {
            var DbItem = _Context.Items.Find(id);

            ToDoItemViewModel FindItem = new ToDoItemViewModel()

            {
                Id = DbItem.Id,
                TaskName = DbItem.TaskName,
                ImageName = DbItem.FileName,
                TaskDescription = DbItem.TaskDescription,
                Status = (StatusType)DbItem.StatusType,
                DueDate = DbItem.DueDate,

            };
            //Return ViewModel
            return FindItem;
        }

        public bool UpdateItem(int id, ToDoItemBaseViewModel ToDoItem)
        {

            try
            {
                var DbItem = _Context.Items.Find(id);

                DbItem.Id = id;
                DbItem.TaskName = ToDoItem.TaskName;

                DbItem.TaskDescription = ToDoItem.TaskDescription;
                DbItem.StatusType = (int)ToDoItem.Status;
                DbItem.DueDate = ToDoItem.DueDate;
                DbItem.LastUpdateDateTime = DateTime.Now;
                DbItem.CreationDateTime = DateTime.Now;


                if (ToDoItem.ImageFile != null)
                { DbItem.FileName = ToDoItem.ImageFile.FileName; }


                _Context.SaveChanges();

                return true;
            }

            catch (Exception ex)
            { return false; }


        }


        private bool TodoItemExists(int id)
        {
            return _Context.Items.Any(e => e.Id == id);
        }





    }
}
