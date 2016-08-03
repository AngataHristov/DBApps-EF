namespace CarsSystem.ConsoleClient.Models
{
    using System;
    using System.Xml.Serialization;

    [Serializable]
    public class WhereClauseXlmModel
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string Type { get; set; }
    }
}
