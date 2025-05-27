using Library.Abstractions;
using Library.Abstractions.Models;
using Library.Realisation.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Library.Realisation.FileHandlers
{
    public class JsonFileHandler : IFileHandler
    {
        public override IEnumerable<T> Load<T>(string loadPath)
        {
            try
            {
                var json = File.ReadAllText(loadPath);
                return JsonSerializer.Deserialize<IEnumerable<T>>(json);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public override void Save<T>(IEnumerable<T> obj, string savePath)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            var json = JsonSerializer.Serialize(obj, options);
            File.WriteAllText(savePath, json);
        }

        public JsonFileHandler() : base(){ }
    }
}
