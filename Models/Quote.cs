using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotivateMe.Models
{
    public class Quote
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }
    }
}
