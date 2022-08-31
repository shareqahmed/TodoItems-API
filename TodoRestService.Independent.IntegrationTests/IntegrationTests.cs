using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TodoRestService.Independent.IntegrationTests
{
    [Collection("Sequential")]
    public class IntegrationTests
    {


        [Theory]
        [InlineData("api/TodoItems")]

        public async Task Get_all_endpoint_should_return_list_of_Items_and_return_OK(string url)
        {

            var _IndependentTodoItemsController = new IndependentTodoItemsController();
            var ResponseStatus = await _IndependentTodoItemsController.GetAll(url);


            Assert.Equal(HttpStatusCode.OK, ResponseStatus);
        }



        [Theory]
        [InlineData("api/TodoItems")]

        public async Task Get_by_Id_should_get_same_item_and_return_OK(string url)
        {

            var _IndependentTodoItemsController = new IndependentTodoItemsController();
            var ResponseStatus = await _IndependentTodoItemsController.GetbyId(url);


            Assert.Equal(HttpStatusCode.OK, ResponseStatus);
        }





        [Theory]
        [InlineData("api/TodoItems")]

        public async Task Delete_endpoint_should_delete_item_and_return_OK(string url)
        {

            var _IndependentTodoItemsController = new IndependentTodoItemsController();
            var ResponseStatus = await _IndependentTodoItemsController.DeleteItembyId(url);


            Assert.Equal(HttpStatusCode.OK, ResponseStatus);
        }



        [Theory]
        [InlineData("api/TodoItems")]

        public async Task Post_endpoint_should_post_item_and_return_OK(string url)
        {

            var _IndependentTodoItemsController = new IndependentTodoItemsController();
            var ResponseStatus = await _IndependentTodoItemsController.PostItem(url);


            Assert.Equal(HttpStatusCode.OK, ResponseStatus);
        }





        [Theory]
        [InlineData("api/TodoItems")]

        public async Task Update_endpoint_should_update_item_and_return_OK(string url)
        {

            var _IndependentTodoItemsController = new IndependentTodoItemsController();
            var ResponseStatus = await _IndependentTodoItemsController.UpdateItembyId(url);


            Assert.Equal(HttpStatusCode.OK, ResponseStatus);
        }
    }
}
