namespace CarsSystem.ConsoleClient.Models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [Serializable]
    public class QueryXmlModel
    {
        [XmlAttribute]
        public string OutputFileName { get; set; }

        public string OrderBy { get; set; }

        [XmlArrayItem(ElementName = "WhereClause")]
        public WhereClauseXlmModel[] WhereClauses { get; set; }
    }
}
