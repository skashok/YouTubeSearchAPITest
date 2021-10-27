using System;
using Newtonsoft.Json;

namespace TheHandyTube.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class VideoItems
    {
       [JsonProperty]
       public string Kind { get; set; }

       [JsonProperty]
       public string Etag { get; set; }

       [JsonProperty]
       public VideoID ID { get; set; }

       [JsonProperty]
       public Snippet Snippet { get; set; }

    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Snippet
    {
        [JsonProperty]
        public string ChannelId { get; set; }
        [JsonProperty]
        public string ChannelTitle { get; set; }
        [JsonProperty]
        public string Description { get; set; }
        [JsonProperty]
        public string LiveBroadcastContent { get; set; }
        [JsonProperty]
        public string PublishedAt { get; set; }
        [JsonProperty]
        public string PublishTime { get; set; }
        [JsonProperty]
        public string Title { get; set; }
        [JsonProperty]
        public Thumbnails Thumbnails { get; set; }

    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Thumbnails
    {
        [JsonProperty]
        public Default Default { get; set; }
        [JsonProperty]
        public Medium Medium { get; set; }
        [JsonProperty]
        public High High { get; set; }

    }


    [JsonObject(MemberSerialization.OptIn)]
    public class VideoID
    {
        [JsonProperty]
        public string Kind { get; set; }
        [JsonProperty]
        public string VideoId { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Default
    {
        [JsonProperty]
        public string Url { get; set; }
        [JsonProperty]
        public string Width { get; set; }
        [JsonProperty]
        public string Height { get; set; }

    }
    [JsonObject(MemberSerialization.OptIn)]
    public class Medium
    {
        [JsonProperty]
        public string Url { get; set; }
        [JsonProperty]
        public string Width { get; set; }
        [JsonProperty]
        public string Height { get; set; }

    }
    [JsonObject(MemberSerialization.OptIn)]
    public class High
    {
        [JsonProperty]
        public string Url { get; set; }
        [JsonProperty]
        public string Width { get; set; }
        [JsonProperty]
        public string Height { get; set; }

    }
}
