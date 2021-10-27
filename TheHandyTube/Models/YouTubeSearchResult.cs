using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TheHandyTube.Models
{
    public class YouTubeSearchResult
    {
        [JsonProperty]
        public double Kind { get; set; }

        [JsonProperty]
        public string Etag { get; set; }

        [JsonProperty]
        public string NextPageToken { get; set; }

        [JsonProperty]
        public string RegionCode { get; set; }

        [JsonProperty]
        public List<PageInfo> PageInfos { get; set; }

        [JsonProperty]
        public List<VideoItems> Items { get; set; }

        [JsonObject(MemberSerialization.OptIn)]
        public class PageInfo
        {
            [JsonProperty]
            public string name { get; set; }
        }
    }
}
