using System;
using System.IO;
using System.Text.Json;
using TaskXMLtoJSON.Model;
using TaskXMLtoJSON.Process;


namespace TaskXMLtoJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            XMLProcess xMLProcess = new XMLProcess(Directory.GetCurrentDirectory() + "\\XML\\New Text Document.XML");
            JSONModel jSON = xMLProcess.XMLReader();

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize<JSONModel>(jSON, options);
            Console.WriteLine(jsonString);
            Console.ReadLine();
        }
    }
}
