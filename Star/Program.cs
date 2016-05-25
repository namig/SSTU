using BrightstarDB;
using BrightstarDB.Client;
using BrightstarDB.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VDS.RDF;
using VDS.RDF.Parsing;
using VDS.RDF.Query;
//using VDS.RDF.Query.Algebra;
using VDS.RDF.Storage;
using VDS.RDF.Storage.Management;
using VDS.RDF.Storage.Management.Provisioning;

namespace Star
{
    class Program
    {
        static void Main(string[] args)
        {
            StartStar();
            Console.WriteLine("\nPress Key");
            Console.ReadKey();
        }

        static void StartStarOld()
        {
            // define a connection string
            const string connectionString = "type=embedded;storesdirectory=.\\;storename=Films";

            // if the store does not exist it will be automatically
            // created when a context is created
            var ctx = new MyEntityContext(connectionString);

            var client = BrightstarService.GetClient(connectionString);
            //var importJob = client.StartImport("Films", "films.rdf", "http://www.films.org", importFormat: RdfFormat.RdfXml);

            // create some films
            var bladeRunner = ctx.Films.Create();
            bladeRunner.Name = "BladeRunner";


            var starWars = ctx.Films.Create();
            starWars.Name = "Star Wars";


            // create some actors and connect them to films
            var ford = ctx.Actors.Create();
            ford.Name = "Harrison Ford";
            ford.DateOfBirth = new DateTime(1942, 7, 13);
            ford.Films.Add(starWars);
            ford.Films.Add(bladeRunner);


            var hamill = ctx.Actors.Create();
            hamill.Name = "Бондарчук";
            hamill.DateOfBirth = new DateTime(1951, 9, 25);
            hamill.Films.Add(starWars);

            ctx.SaveChanges();

            BrightstarService.GetClient(connectionString).StartExport("Films", "films_gen.rdf", "http://films.org", RdfFormat.RdfXml);
        }

        static void StartStar()
        {
            string uri = "http://films.org";
            string storeName = "Films";
            string connectionString = "type=embedded;storesdirectory=.\\;storename=" + storeName;

            var ctx = new MyEntityContext(connectionString);
            var client = BrightstarService.GetClient(connectionString);

            var importJob = client.StartImport(storeName, "films.rdf", uri, null, RdfFormat.RdfXml);

            // create film
            var starWars = ctx.Films.Create();
            starWars.Name = "Forsag";

            // create some actors and connect them to films
            var ford = ctx.Actors.Create();
            ford.Name = "Harrison Ford";
            ford.DateOfBirth = new DateTime(1942, 7, 13);
            ford.Films.Add(starWars);

            ctx.SaveChanges();

            var exportGraphJob = client.StartExport(storeName, "films_generated.rdf", null, RdfFormat.RdfXml);
        }



    }
}


// TODO: проверить русские ID
// TODO: сделать одинаковые ссылки
// TODO: проверить base URI
// TODO: попробовать select by name
// TODO: сделать автоудаление папки store
