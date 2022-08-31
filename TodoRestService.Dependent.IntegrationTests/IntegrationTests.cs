
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TheoryAttribute = Xunit.TheoryAttribute;

namespace TodoRestService.Dependent.IntegrationTests
{
    [Collection("Sequential")]
    public class IntegrationTests
    {

        [Theory]
        [InlineData("api/TodoItems")]

        public async Task Get_all_endpoint_should_return_list_of_Items_and_return_OK(string url)
        {

            var _DependentTodoItemsController = new DependentTodoItemsController();
            var ResponseStatus = await _DependentTodoItemsController.GetAll(url);

            // Assert
            Assert.Equal(HttpStatusCode.OK, ResponseStatus);
        }



        [Theory]
        [InlineData("api/TodoItems")]

        public async Task Get_by_Id_should_get_same_item_and_return_OK(string url)
        {

            var _DependentTodoItemsController = new DependentTodoItemsController();
            var ResponseStatus = await _DependentTodoItemsController.GetbyId(url);

            // Assert
            Assert.Equal(HttpStatusCode.OK, ResponseStatus);
        }





        [Theory]
        [InlineData("api/TodoItems")]

        public async Task Delete_endpoint_should_delete_item_and_return_OK(string url)
        {

            var _DependentTodoItemsController = new DependentTodoItemsController();
            var ResponseStatus = await _DependentTodoItemsController.DeleteItembyId(url);

            // Assert

            Assert.Equal(HttpStatusCode.OK, ResponseStatus);
        }



        [Theory]
        [InlineData("api/TodoItems")]

        public async Task Post_endpoint_should_post_item_and_return_OK(string url)
        {

            var _DependentTodoItemsController = new DependentTodoItemsController();
            var ResponseStatus = await _DependentTodoItemsController.PostItem(url);


            Assert.Equal(HttpStatusCode.OK, ResponseStatus);
        }





        [Theory]
        [InlineData("api/TodoItems")]

        public async Task Update_endpoint_should_update_item_and_return_OK(string url)
        {

            var _DependentTodoItemsController = new DependentTodoItemsController();
            var ResponseStatus = await _DependentTodoItemsController.UpdateItembyId(url);


            Assert.Equal(HttpStatusCode.OK, ResponseStatus);
        }
    }
}
