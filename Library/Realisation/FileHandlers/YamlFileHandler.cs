using Library.Abstractions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Library.Realisation.FileHandlers
{
    public class YamlFileHandler : IFileHandler
    {
        public override IEnumerable<T> Load<T>(string loadPath)
        {
            var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();

            var yamlFromFile = File.ReadAllText(loadPath);
            var data = deserializer.Deserialize<IEnumerable<T>>(yamlFromFile);

            return data;
        }
        public override void Save<T>(IEnumerable<T> obj, string savePath)
        {
            var serializer = new SerializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();
            var yaml = serializer.Serialize(obj);
            File.WriteAllText(savePath, yaml);
        }

        public YamlFileHandler() : base() { }
    }
}
