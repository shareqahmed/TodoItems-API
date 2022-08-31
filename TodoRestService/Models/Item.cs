using System.Text.Json.Serialization;
using System;

namespace TodoRestService.Models
{
    public class Item
    {

        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("TaskName")]
        public string TaskName { get; set; }

        [JsonPropertyName("TaskDescription")]

        public string TaskDescription { get; set; }

        [JsonPropertyName("StatusType")]
        public int StatusType { get; set; }

        [JsonPropertyName("FileName")]
        public string FileName { get; set; }

        [JsonPropertyName("CreationDateTime")]
        public DateTime CreationDateTime { get; set; }

        [JsonPropertyName("DueDate")]
        public DateTime DueDate { get; set; }

        [JsonPropertyName("LastUpdateDateTime")]
        public DateTime? LastUpdateDateTime { get; set; }
    }
}
