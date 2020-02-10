using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace PopTool
{
    public class Util
    {
        public static string ReadEmbeddedFile(string embeddedFilePath)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceStream = assembly.GetManifestResourceStream(embeddedFilePath);
            if (resourceStream == null)
            {
                throw new Exception($"Resource file {embeddedFilePath} not found");
            }

            using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
