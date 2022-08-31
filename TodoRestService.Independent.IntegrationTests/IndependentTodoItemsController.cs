using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace TodoRestService.Independent.IntegrationTests
{
    public class IndependentTodoItemsController
    {
        private HttpClient HttpClient = new HttpClient();
        private string BaseUrl = "https://localhost:44348";

        public async Task<HttpStatusCode> GetAll(string Url)

        {
            HttpClient.BaseAddress = new Uri(BaseUrl);
            var Response = await HttpClient.GetAsync(Url);

            var ResponseStatus = Response.StatusCode;
            return ResponseStatus;

        }


        public async Task<HttpStatusCode> GetbyId(string Url)

        {
            HttpClient.BaseAddress = new Uri(BaseUrl);

            var ItemsList = await GetItemsList(Url);
            var TaskId = ItemsList.FirstOrDefault().Id;
            var Id = TaskId;

            var GetbyIdUrl = Url + "/" + Id.ToString();

            var Response = await HttpClient.GetAsync(GetbyIdUrl);



            var ResponseStatus = Response.StatusCode;
            return ResponseStatus;

        }






        public async Task<HttpStatusCode> PostItem(string Url)
        {
            // Arrange
            HttpClient.BaseAddress = new Uri(BaseUrl);


            // Act
            var FormValues = new Dictionary<string, string>();
            FormValues.Add("TaskName", "ToDoItems");
            FormValues.Add("TaskDescription", "1-  Post and Run Independent Integration Tests");
            FormValues.Add("Status", FakeToDoItemViewModel.StatusType.Active.ToString());
            FormValues.Add("DueDate", DateTime.Now.AddHours(168).ToString());

            using var Content = new FormUrlEncodedContent(FormValues);

            var Response = await HttpClient.PostAsync(Url, Content);


            var ResponseStatusCode = Response.StatusCode;
            return ResponseStatusCode;


        }




        public async Task<HttpStatusCode> DeleteItembyId(string Url)
        {
            // Arrange
            HttpClient.BaseAddress = new Uri(BaseUrl);



            var ItemsList = await GetItemsList(Url);
            var TaskId = ItemsList.FirstOrDefault().Id;
            var Id = TaskId;
            var Deleteurl = Url + "/" + Id.ToString();

            // Act
            var Response = await HttpClient.DeleteAsync(Deleteurl);

            var ResponseStatusCode = Response.StatusCode;
            return ResponseStatusCode;


        }





        public async Task<HttpStatusCode> UpdateItembyId(string Url)
        {
            // Arrange
            HttpClient.BaseAddress = new Uri(BaseUrl);



            var ItemsList = await GetItemsList(Url);
            var TaskId = ItemsList.FirstOrDefault().Id;
            var Id = TaskId;
            var Updateurl = Url + "/" + Id.ToString();

            // Act
            var FormValues = new Dictionary<string, string>();
            FormValues.Add("TaskName", "Updated ToDoItems");
            FormValues.Add("TaskDescription", "1- Update and Run Dependent Integration Tests");
            FormValues.Add("Status", FakeToDoItemViewModel.StatusType.Active.ToString());
            FormValues.Add("DueDate", DateTime.Now.AddHours(168).ToString());

            using var Content = new FormUrlEncodedContent(FormValues);

            var Response = await HttpClient.PutAsync(Updateurl, Content);


            var ResponseStatusCode = Response.StatusCode;
            return ResponseStatusCode;


        }








        public async Task<List<FakeToDoItemViewModel>> GetItemsList(string Url)

        {

            var FakeItemsList = new List<FakeToDoItemViewModel>();
            HttpClient.BaseAddress = new Uri(BaseUrl);
            var Response = await HttpClient.GetAsync(Url);

            var ResultString = await Response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var JsonResult = JsonSerializer.Deserialize<List<FakeToDoItemViewModel>>(ResultString);

            FakeItemsList = JsonResult;

            return FakeItemsList;

        }







    }
}
