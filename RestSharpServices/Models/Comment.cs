using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestSharpServices.Models
{
    public class Comment
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("body")]
        public string ? Body { get; set; }
    }
}
