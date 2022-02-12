using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FpV
{
    /*public class ChildImage
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
    }*/

    public class SocialLinks
    {
        public string instagram { get; set; }
        public string twitter { get; set; }
        public string website { get; set; }
        public string facebook { get; set; }
        public string youtube { get; set; }
    }

    public class DiscordServer
    {
        public string id { get; set; }
        public string guildName { get; set; }
        public string guildIcon { get; set; }
        public string inviteLink { get; set; }
        public string inviteMode { get; set; }
    }

    public class FloatplaneCreator
    {
        public string id { get; set; }
        public string owner { get; set; }
        public string title { get; set; }
        public string urlname { get; set; }
        public string description { get; set; }
        public string about { get; set; }
        public string category { get; set; }
        public Cover cover { get; set; }
        public Icon icon { get; set; }
        public object liveStream { get; set; }
        public object subscriptionPlans { get; set; }
        public bool discoverable { get; set; }
        public string subscriberCountDisplay { get; set; }
        public bool incomeDisplay { get; set; }
        public SocialLinks socialLinks { get; set; }
        public List<DiscordServer> discordServers { get; set; }
    }

    public static class GetCreator
    {
        public static FloatplaneCreator Get(string name) // Retrieves the creator
        {
            using (WebClient wc = new WebClient())
            {
                string url = "https://www.floatplane.com/api/v2/creator/named?creatorURL=" + name;
                return JsonConvert.DeserializeObject<List<FloatplaneCreator>>(wc.DownloadString(url))[0];
            }
        }
        public static List<FloatplaneCreator> GetList() // Requires authentication, should retrieve the list of all floatplane creators
        {
            using (WebClient wc = new WebClient())
            {
                string url = "https://www.floatplane.com/api/v3/creator/list";
                wc.Headers.Add("User-Agent: Other");
                Console.WriteLine(wc.DownloadString(url));
                return JsonConvert.DeserializeObject<List<FloatplaneCreator>>(wc.DownloadString(url));
            }
        }
    }
}
