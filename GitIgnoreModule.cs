﻿using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace PopTool
{
    public class GitIgnoreModule
    {
        public static void Start()
        {
            string input;
            bool isInputValid;

            do
            {
                Console.WriteLine("Create .gitignore file? (y/n) [y]");
                input = (Console.ReadLine() ?? string.Empty).ToLower();
                if (input == string.Empty)
                {
                    input = "y";
                }

                isInputValid = input == "y" || input == "n";
            }
            while (!isInputValid);

            var doCreateFile = input == "y";
            if (doCreateFile)
            {
                DoCreateFile();
            }
        }

        private static void DoCreateFile()
        {
            string input;
            bool isInputValid;

            do
            {
                Console.WriteLine("Available types:");
                Console.WriteLine("[1] basic");
                Console.WriteLine("[2] legacy");

                Console.WriteLine("Select a type...");
                input = Console.ReadLine();
                isInputValid = input == "1" || input == "2";
            } while (!isInputValid);

            var file = input == "1" ? "basic.txt" : "legacy.txt";
            var embeddedFilePath = $"PopTool.content.gitignore.{file}";
            var fileContent = ReadEmbeddedFile(embeddedFilePath);
            
            var path = Path.Combine(Environment.CurrentDirectory, ".gitignore");
            Console.WriteLine("File written to: " + path);
            File.WriteAllText(path, fileContent);
        }

        private static string ReadEmbeddedFile(string embeddedFilePath)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceStream = assembly.GetManifestResourceStream(embeddedFilePath);

            using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }
}