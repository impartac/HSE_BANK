using Library.Realisation;
using Microsoft.Extensions.DependencyInjection;
using Library.Realisation.Models;
using Library.Abstractions.Models;
using Library.Abstractions;
using System.Xml;
using Library.Realisation.Storages;
using Library.Realisation.FileHandlers;
using System.Text.Json;




public class Program
{
    public static void Main()
    {

        App app = new App();
        app.Start();
    }
}