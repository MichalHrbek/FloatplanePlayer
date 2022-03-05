using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace FpV
{
    class Program
    {
        static void Main(string[] args)
        {
            string creatorName = "linustechtips"; // From the url
            int maxVid = 20; // Anything over 20 doesn't work. 
            int count = 1; // If you want to fecth more posts
            string searchPhrase = ""; // Ignores if empty
            string pathToPlayer = @"https://michalhrbek.github.io/Projects/FloatplanePlayer";
            Resoultion resolution = Resoultion._720p;
            
            FloatplaneCreator creator = GetCreator.Get(creatorName); // Gets the creator id
            List<Post> Posts = Get.getVideoList(creator.id, maxVid, searchPhrase, count); // Gets creators post

            // Prints out info about the creator
            Console.WriteLine(creator.title);
            Console.WriteLine(creator.description + "\n");

            // Prints out all the posts
            for (int i = 0; i < Posts.Count; i++)
            {
                if (Posts[i].attachmentOrder != null)
                {
                    Console.WriteLine($"{(i+1)} : {Posts[i].title}");
                }
            }

            // Main loop
            while (true)
            {
                selectPost();
            }
            
            void selectPost()
            {
                Console.Write("\nSelct post: ");
                int num = int.Parse(Console.ReadLine()); // Selected video
                if (num > 0 && num <= Posts.Count)
                {

                    //The mp4 url (The webapp just plays it in the browser you can play it in any other program like vlc or download it) Console.WriteLine($"https://edge01-na.floatplane.com/Videos/{Posts[num - 1].attachmentOrder[0]}/{resolution}.mp4");
                    if (Posts[num - 1].metadata.hasVideo)
                    {
                        for (int i = 0; i < Posts[num - 1].metadata.videoCount; i++)
                        {
                            openURL($"{pathToPlayer}?id={Posts[num - 1].attachmentOrder[0]}&res={(int)resolution}&likes={Posts[num - 1].likes}&dislikes={Posts[num - 1].dislikes}");
                        }
                    }
                    else Console.WriteLine("No video");
                }
                else
                {
                    Console.WriteLine($"{num} not in range");
                }
            }

            void openURL(string url)
            {
                // Opens urls in the browser
                var uri = url;
                var psi = new System.Diagnostics.ProcessStartInfo();
                psi.UseShellExecute = true;
                psi.FileName = uri;
                System.Diagnostics.Process.Start(psi);
            }
        }
    }
}
