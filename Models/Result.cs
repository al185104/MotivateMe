using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotivateMe.Models
{
    public class Result
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("tags")]
        public List<Tag> Tags { get; set; } = new List<Tag>();

        [JsonProperty("authors")]
        public List<Author> Authors { get; set; } = new List<Author>();

        [JsonProperty("quotes")]
        public List<Quote> Quotes { get; set; } = new List<Quote>();
    }
}
