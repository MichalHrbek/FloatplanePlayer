﻿using System;
using System.Collections.Generic;

namespace FpV
{
    class Program
    {
        static void Main(string[] args)
        {
            string creatorId = "59f94c0bdd241b70349eb72b";
            int maxVid = 20;
            string searchPhrase = "";
            string pathToPlayer = @"C:\Program Files (x86)\VideoLAN\VLC\vlc.exe";
            int resolution = 1080; // 480, 720, 1080, 2160(4K), 4320(8K)

            List<Post> Posts = Get.getVideoList(creatorId, maxVid, searchPhrase, 1);

            for (int i = 0; i < Posts.Count; i++)
            {
                if (Posts[i].attachmentOrder != null)
                {
                    Console.WriteLine((i+1) + ": " + Posts[i].title);
                }
            }
            
            Console.Write("\nSelct video: ");
            int num = int.Parse(Console.ReadLine());
            if (num > 0 && num <= Posts.Count)
            {
                System.Diagnostics.Process.Start(pathToPlayer, "https://edge01-na.floatplane.com/Videos/" + Posts[num-1].attachmentOrder[0] + "/" + resolution + ".mp4");
                Console.WriteLine("https://edge01-na.floatplane.com/Videos/" + Posts[num-1].attachmentOrder[0] + "/" + resolution + ".mp4");
            }
            else
            {
                Console.WriteLine(num + " not in range");
            }
        }
    }
}
