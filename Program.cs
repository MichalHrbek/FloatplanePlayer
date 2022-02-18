﻿using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace FpV
{
    class Program
    {
        static void Main(string[] args)
        {
            string creatorName = "linustechtips"; // From the url
            int maxVid = 20;
            string searchPhrase = ""; // Ignores if empty
            string pathToPlayer = @"https://michalhrbek.github.io/Projects/FloatplanePlayer";
            Resoultion resolution = Resoultion._720p;
            
            FloatplaneCreator creator = GetCreator.Get(creatorName);
            List<Post> Posts = Get.getVideoList(creator.id, maxVid, searchPhrase, 1);

            Console.WriteLine(creator.title);
            Console.WriteLine(creator.description + "\n");

            for (int i = 0; i < Posts.Count; i++)
            {
                if (Posts[i].attachmentOrder != null)
                {
                    Console.WriteLine($"{(i+1)} : {Posts[i].title}");
                }
            }

            while (true)
            {
                selectVideo();
            }
            
            void selectVideo()
            {
                Console.Write("\nSelct video: ");
                int num = int.Parse(Console.ReadLine());
                if (num > 0 && num <= Posts.Count)
                {
                    //Console.WriteLine("https://edge01-na.floatplane.com/Videos/" + Posts[num-1].attachmentOrder[0] + "/" + resolution + ".mp4
                    // Opens url in the browser
                    var uri = $"{pathToPlayer}?id={Posts[num - 1].attachmentOrder[0]}&res={(int)resolution}&likes={Posts[num - 1].likes}&dislikes={Posts[num - 1].dislikes}";
                    var psi = new System.Diagnostics.ProcessStartInfo();
                    psi.UseShellExecute = true;
                    psi.FileName = uri;
                    System.Diagnostics.Process.Start(psi);
                }
                else
                {
                    Console.WriteLine($"{num} not in range");
                }
            }
        }
    }
}
