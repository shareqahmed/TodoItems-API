using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TodoRestService.Independent.IntegrationTests
{
    public class FakeToDoItemViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
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

        [JsonPropertyName("ImageName")]
        public string ImageName { get; set; }


    }
}
