﻿using System;

namespace PopTool
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Pop Tool...");

            GitIgnoreModule.Start();

            Console.WriteLine("Done");
        }
    }
}
