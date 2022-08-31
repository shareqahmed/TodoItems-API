using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;
using System;

namespace TodoRestService.ViewModels
{
    public class ToDoItemBaseViewModel
    {


        [JsonPropertyName("TaskName")]
        public string TaskName { get; set; }

        [JsonPropertyName("TaskDescription")]
        public string TaskDescription { get; set; }


        public enum StatusType { Created, Active, Finish }

        [JsonPropertyName("Status")]
        public StatusType Status { get; set; }

        [JsonPropertyName("ImageFile")]
        public IFormFile ImageFile { get; set; }

        [JsonPropertyName("DueDate")]
        public DateTime DueDate { get; set; }


    }

    public class ToDoItemViewModel : ToDoItemBaseViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("ImageName")]
        public string ImageName { get; set; }


    }
}
