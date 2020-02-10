using System;
using System.IO;

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
                CheckForExistingFile();
            }
        }

        public static void CheckForExistingFile()
        {
            var path = Path.Combine(Environment.CurrentDirectory, ".gitignore");
            var fileAlreadyExists = File.Exists(path);
            if (!fileAlreadyExists)
            {
                DoCreateFile();
            }
            else
            {
                string input;
                bool isInputValid;

                do
                {
                    Console.WriteLine("A .gitignore file already exists in this directory. Overwrite? (y/n) [n]");
                    input = (Console.ReadLine() ?? string.Empty).ToLower();
                    if (input == string.Empty)
                    {
                        input = "n";
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
            var fileContent = Util.ReadEmbeddedFile(embeddedFilePath);
            
            var path = Path.Combine(Environment.CurrentDirectory, ".gitignore");
            Console.WriteLine("File written to: " + path);
            File.WriteAllText(path, fileContent);
        }
    }
}
