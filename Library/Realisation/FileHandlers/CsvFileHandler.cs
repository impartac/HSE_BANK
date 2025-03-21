using CsvHelper;
using Library.Abstractions;
using Library.Abstractions.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Library.Realisation.FileHandlers
{
    public class CsvFileHandler : IFileHandler
    {
        public override IEnumerable<T> Load<T>(string loadPath)
        {
            using (var fileStream = new FileStream(loadPath, FileMode.OpenOrCreate, FileAccess.Read))
            using (var reader = new StreamReader(fileStream ))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                var records = csv.GetRecords<T>();
                return records.ToList();
            }
        }
        public override void Save<T>(IEnumerable<T> obj, string savePath)
        {
            using (var fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.Write))
            using (var reader = new StreamWriter(fileStream))
            using (var csv = new CsvWriter(reader, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(obj);
            }
        }

        public CsvFileHandler() : base() { }
    }
}
