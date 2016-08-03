namespace CarsSystem.ConsoleClient
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using Models;
    using Newtonsoft.Json;

    public static class XmlCarsSearcher
    {
        public static void Search()
        {
            var directory = Directory.GetCurrentDirectory() + "/XmlFiles/";

            var xmlQueries = Directory
                .GetFiles(directory)
                .Where(f => f.EndsWith(".xml"))
                .Select(f => XDocument.Load(f))
                .FirstOrDefault();

            var strReader = new StringReader(xmlQueries.ToString());
            var xmlSer = new XmlSerializer(typeof(QueriesXmlModel)).Deserialize(strReader);
        }
    }
}
