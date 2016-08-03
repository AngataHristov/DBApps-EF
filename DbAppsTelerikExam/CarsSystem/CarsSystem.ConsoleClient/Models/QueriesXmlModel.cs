namespace CarsSystem.ConsoleClient.Models
{
    using System;
    using System.Xml.Serialization;

    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class QueriesXmlModel
    {
        [XmlElement("Query")]
        public QueryXmlModel[] Query { get; set; }
    }
}
