using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using TodoRestService.ViewModels;
using System.Text.Json;

namespace TodoRestService.Dependent.IntegrationTests
{
    public class DependentTodoItemsController
    {


        [InlineData("api/TodoItems")]
        public async Task<HttpStatusCode> GetAll(string url)

        {
            // Arrange
            var App = new WebApplicationFactory<Startup>();
            using var Client = App.CreateClient();

            // Act
            var Response = await Client.GetAsync(url);

            var ResponseStatus = Response.StatusCode;
            return ResponseStatus;

        }



        [InlineData("api/TodoItems")]


        public async Task<HttpStatusCode> PostItem(string url)
        {
            // Arrange

            var App = new WebApplicationFactory<Startup>();
            using var Client = App.CreateClient();

            // Act
            var FormValues = new Dictionary<string, string>();
            FormValues.Add("TaskName", "ToDoItems");
            FormValues.Add("TaskDescription", "1-  Post and Run Dependent Integration Tests");
            FormValues.Add("Status", ToDoItemViewModel.StatusType.Created.ToString());
            FormValues.Add("DueDate", DateTime.Now.AddHours(168).ToString());

            using var Content = new FormUrlEncodedContent(FormValues);
            var Response = await Client.PostAsync(url, Content);
            var ResponseStatus = Response.StatusCode;
            return ResponseStatus;


        }



        [InlineData("api/TodoItems")]


        public async Task<HttpStatusCode> DeleteItembyId(string Url)
        {
            // Arrange
            var App = new WebApplicationFactory<Startup>();
            using var Client = App.CreateClient();
            var ItemsList = await GetItemsList(Url);
            var TaskId = ItemsList.FirstOrDefault().Id;
            int Id = TaskId;
            string DeleteUrl = Url + "/" + Id.ToString();


            // Act
            var Response = await Client.DeleteAsync(DeleteUrl);
            var ResponseStatus = Response.StatusCode;
            return ResponseStatus;




        }





        [InlineData("api/TodoItems")]

        public async Task<HttpStatusCode> UpdateItembyId(string Url)
        {
            // Arrange
            var App = new WebApplicationFactory<Startup>();
            using var Client = App.CreateClient();
            var ItemsList = await GetItemsList(Url);
            var TaskId = ItemsList.FirstOrDefault().Id;
            int Id = TaskId;
            string UpdateUrl = Url + "/" + Id.ToString();

            // Act
            var FormValues = new Dictionary<string, string>();
            FormValues.Add("TaskName", "Updated ToDoItems");
            FormValues.Add("TaskDescription", "1- Update and Run Dependent Integration Tests");
            FormValues.Add("Status", ToDoItemViewModel.StatusType.Active.ToString());
            FormValues.Add("DueDate", DateTime.Now.AddHours(168).ToString());

            using var Content = new FormUrlEncodedContent(FormValues);
            var Response = await Client.PutAsync(UpdateUrl, Content);

            var ResponseStatusCode = Response.StatusCode;
            return ResponseStatusCode;

        }


        [InlineData("api/TodoItems")]

        //[InlineData("/Customers/Edit")]
        public async Task<HttpStatusCode> GetbyId(string Url)
        {
            // Arrange
            var application = new WebApplicationFactory<Startup>();
            using var Client = application.CreateClient();
            var ItemsList = await GetItemsList(Url);
            var TaskId = ItemsList.FirstOrDefault().Id;
            var Id = TaskId;
            var GetbyIdUrl = Url + "/" + Id.ToString();

            // Act
            var Response = await Client.GetAsync(GetbyIdUrl);
            var ResponseStatus = Response.StatusCode;
            return ResponseStatus;



        }



        public async Task<List<ToDoItemViewModel>> GetItemsList(string Url)

        {
            var App = new WebApplicationFactory<Startup>();
            using var Client = App.CreateClient();

            var FakeItemsList = new List<ToDoItemViewModel>();

            var Response = await Client.GetAsync(Url);
            var ResultString = await Response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var JsonResult = JsonSerializer.Deserialize<List<ToDoItemViewModel>>(ResultString);

            FakeItemsList = JsonResult;
            return FakeItemsList;

        }











    }
}
