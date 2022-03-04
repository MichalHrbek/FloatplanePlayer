using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace FpV
{
    public class Metadata
    {
        public bool hasVideo { get; set; }
        public int videoCount { get; set; }
        public int videoDuration { get; set; }
        public bool hasAudio { get; set; }
        public int audioCount { get; set; }
        public int audioDuration { get; set; }
        public bool hasPicture { get; set; }
        public int pictureCount { get; set; }
        public bool hasGallery { get; set; }
        public int galleryCount { get; set; }
        public bool isFeatured { get; set; }
    }

    public class Owner
    {
        public string id { get; set; }
        public string username { get; set; }
    }

    public class Category
    {
        public string title { get; set; }
    }

    public class ChildImage
    {
        public int width { get; set; }
        public int height { get; set; }
        public string path { get; set; }
    }

    public class Cover
    {
        public int width { get; set; }
        public int height { get; set; }
        public string path { get; set; }
        public List<ChildImage> childImages { get; set; }
    }

    public class Icon
    {
        public int width { get; set; }
        public int height { get; set; }
        public string path { get; set; }
        public List<ChildImage> childImages { get; set; }
    }

    public class Thumbnail
    {
        public int width { get; set; }
        public int height { get; set; }
        public string path { get; set; }
        public List<object> childImages { get; set; }
    }

    public class Offline
    {
        public string title { get; set; }
        public string description { get; set; }
        public Thumbnail thumbnail { get; set; }
    }

    public class LiveStream
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Thumbnail thumbnail { get; set; }
        public string owner { get; set; }
        public string streamPath { get; set; }
        public Offline offline { get; set; }
    }

    public class SubscriptionPlan
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string price { get; set; }
        public string priceYearly { get; set; }
        public string currency { get; set; }
        public object logo { get; set; }
        public string interval { get; set; }
        public bool featured { get; set; }
        public bool allowGrandfatheredAccess { get; set; }
        public List<object> discordServers { get; set; }
        public List<object> discordRoles { get; set; }
    }

    public class Card
    {
        public int width { get; set; }
        public int height { get; set; }
        public string path { get; set; }
        public List<ChildImage> childImages { get; set; }
    }

    public class Creator
    {
        public string id { get; set; }
        public Owner owner { get; set; }
        public string title { get; set; }
        public string urlname { get; set; }
        public string description { get; set; }
        public string about { get; set; }
        public Category category { get; set; }
        public Cover cover { get; set; }
        public Icon icon { get; set; }
        public LiveStream liveStream { get; set; }
        public List<SubscriptionPlan> subscriptionPlans { get; set; }
        public bool discoverable { get; set; }
        public string subscriberCountDisplay { get; set; }
        public bool incomeDisplay { get; set; }
        public Card card { get; set; }
    }

    public class Post
    {
        public string id { get; set; }
        public string guid { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public string type { get; set; }
        public List<string> tags { get; set; }
        public List<string> attachmentOrder { get; set; }
        public Metadata metadata { get; set; }
        public DateTime releaseDate { get; set; }
        public int likes { get; set; }
        public int dislikes { get; set; }
        public int score { get; set; }
        public int comments { get; set; }
        public Creator creator { get; set; }
        public bool wasReleasedSilently { get; set; }
        public Thumbnail thumbnail { get; set; }
        public bool isAccessible { get; set; }
    }

    public static class Get
    {
        public static List<Post> getVideoList(string creatorId, int maxVid, string searchPhrase, int count)
        {
            List<Post> Posts = new List<Post>();

            for (int i = 0; i < count; i++) // Gets (maxVid * count) posts
            {
                using (WebClient wc = new WebClient())
                {
                    string url = $"https://www.floatplane.com/api/v3/content/creator?id={creatorId}&limit={maxVid}&search={searchPhrase}&fetchAfter={i * maxVid}";
                    Posts.AddRange(JsonConvert.DeserializeObject<List<Post>>(wc.DownloadString(url)));
                }
            }

            return Posts;
        }
    }
}
