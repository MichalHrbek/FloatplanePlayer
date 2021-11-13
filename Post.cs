using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
namespace FpV
{
    public class Metadata
    {
        public bool hasVideo;
        public int videoCount;
        public int videoDuration;
        public bool hasAudio;
        public int audioCount;
        public int audioDuration;
        public bool hasPicture;
        public int pictureCount;
        public bool hasGallery;
        public int galleryCount;
        public bool isFeatured;
    }

    public class Owner
    {
        public string id;
        public string username;
    }

    public class Category
    {
        public string title;
    }

    public class ChildImage
    {
        public int width;
        public int height;
        public string path;
    }

    public class Cover
    {
        public int width;
        public int height;
        public string path;
        public List<ChildImage> childImages;
    }

    public class Icon
    {
        public int width;
        public int height;
        public string path;
        public List<ChildImage> childImages;
    }

    public class Thumbnail
    {
        public int width;
        public int height;
        public string path;
        public List<ChildImage> childImages;
    }

    public class Offline
    {
        public string title;
        public string description;
        public Thumbnail thumbnail;
    }

    public class LiveStream
    {
        public string id;
        public string title;
        public string description;
        public Thumbnail thumbnail;
        public string owner;
        public string streamPath;
        public Offline offline;
    }

    public class SubscriptionPlan
    {
        public string id;
        public string title;
        public string description;
        public string price;
        public string priceYearly;
        public string currency;
        public object logo;
        public string interval;
        public bool featured;
        public bool allowGrandfatheredAccess;
        public List<object> discordServers;
        public List<object> discordRoles;
    }

    public class Card
    {
        public int width;
        public int height;
        public string path;
        public List<ChildImage> childImages;
    }

    public class Creator
    {
        public string id;
        public Owner owner;
        public string title;
        public string urlname;
        public string description;
        public string about;
        public Category category;
        public Cover cover;
        public Icon icon;
        public LiveStream liveStream;
        public List<SubscriptionPlan> subscriptionPlans;
        public bool discoverable;
        public string subscriberCountDisplay;
        public bool incomeDisplay;
        public Card card;
    }

    public class Post
    {
        public string id;
        public string guid;
        public string title;
        public string text;
        public string type;
        public List<string> attachmentOrder;
        public Metadata metadata;
        public DateTime releaseDate;
        public int likes;
        public int dislikes;
        public int score;
        public int comments;
        public Creator creator;
        public bool wasReleasedSilently;
        public Thumbnail thumbnail;
        public bool isAccessible;
    }

    public static class Get
    {
        public static List<Post> getVideoList(string creatorId, int maxVid, string searchPhrase, int count)
        {
            List<Post> Posts = new List<Post>();

            for (int i = 0; i < count; i++)
            {
                using (WebClient wc = new WebClient())
                {
                    string url = "https://www.floatplane.com/api/v3/content/creator?id=" + creatorId + "&limit=" + maxVid + "&search=" + searchPhrase + "&fetchAfter=" + (i * maxVid);
                    Posts.AddRange(JsonConvert.DeserializeObject<List<Post>>(wc.DownloadString(url)));
                }
            }

            return Posts;
        }
    }
}
