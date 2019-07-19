using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NativePocProject.iOS.Models
{
    public class DropBoxData
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("rows")]
        public List<DropBoxRow> DropBoxRows { get; set; }

        public class DropBoxRow
        {
            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("imageHref")]
            public string ImageHref { get; set; }
        }
    }
}
