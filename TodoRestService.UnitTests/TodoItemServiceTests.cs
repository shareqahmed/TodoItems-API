using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoRestService.Models;
using TodoRestService.Services;
using TodoRestService.ViewModels;
using Xunit;

namespace TodoRestService.UnitTests
{
    public class TodoItemServiceTests : TestBase
    {


        [Fact]
        public void Post_Item_should_post_new_item()
        {

            // Arrange
            using var DBContext = GetDbContext();
            int Count = DBContext.Items.Count();
            var ToDoItem = new ToDoItemBaseViewModel()

            {
                TaskName = "Testing",
                TaskDescription = "Testing",
                Status = ToDoItemViewModel.StatusType.Created,
                DueDate = DateTime.Now.AddHours(168),
                ImageFile = null

            };

            // Act
            var TodoItemService = new TodoItemService(DBContext);
            var PostItembyService = TodoItemService.PostItem(ToDoItem);
            int NewCount = DBContext.Items.Count();

            // Assert
            Assert.Equal(Count + 1, NewCount);
        }



        [Fact]
        public void Delete_item_by_Id_should_delete_item_with_same_Id()
        {
            // Arrange
            using var DBContext = GetDbContext();
            int Count = DBContext.Items.Count();
            var DBItemId = DBContext.Items.FirstOrDefault().Id;

            // Act
            var Service = new TodoItemService(DBContext);

            var DbItembyService = Service.DeleteItem(DBItemId);

            int NewCount = DBContext.Items.Count();

            // Assert
            Assert.Equal(Count - 1, NewCount);
        }



        [Fact]
        public void Get_Item_List_should_return_list_of_Items()
        {

            // Arrange
            using var dbContext = GetDbContext();
            int Count = dbContext.Items.Count();
            dbContext.Items.Add(new Item { TaskName = "Docker", TaskDescription = "Deploy", DueDate = DateTime.Now });
            dbContext.Items.Add(new Item { TaskName = "UnitTest", TaskDescription = "Pyramid", DueDate = DateTime.Now });
            dbContext.SaveChanges();


            // Act
            var service = new TodoItemService(dbContext);
            var DbItem = service.GetItems();
            int newCount = DbItem.Count();

            // Assert
            Assert.Equal(Count + 2, newCount);
        }

        [Fact]
        public void Get_item_by_Id_should_return_item_with_same_Id()
        {

            // Arrange
            using var DBContext = GetDbContext();

            var GetDBItem = DBContext.Items.FirstOrDefault();
            var GetDBItemId = GetDBItem.Id;

            // Act
            var Service = new TodoItemService(DBContext);
            var GetItembyService = Service.GetItemById(GetDBItemId);


            // Assert
            Assert.Equal(GetItembyService.TaskName, GetDBItem.TaskName);

        }


        [Fact]
        public void Update_item_by_Id_should_update_item_with_same_Id()
        {

            // Arrange
            using var DBContext = GetDbContext();
            var GetDBItem = DBContext.Items.FirstOrDefault();
            var GetDBItemId = GetDBItem.Id;

            var ToDoItemView = new ToDoItemBaseViewModel()

            {
                TaskName = "Unit Tests",
                TaskDescription = "Test Update by Id Item",
                Status = ToDoItemViewModel.StatusType.Created,
                DueDate = DateTime.Now.AddHours(168),
                ImageFile = null

            };

            // Act
            var Service = new TodoItemService(DBContext);
            var UpdateItembyService = Service.UpdateItem(GetDBItemId, ToDoItemView);

            var UpdatedItem = DBContext.Items.First(c => c.Id == GetDBItemId);


            // Assert

            Assert.Same(UpdatedItem.TaskName, ToDoItemView.TaskName);

        }





    }
}
