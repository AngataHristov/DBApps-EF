namespace CompanySampleDataImporter.Importer.Interfaces
{
    using CompanySampleDataImporter.Data;
    using System;
    using System.IO;

    public interface IImporter
    {
        string Message { get; }

        int Order { get; }

        Action<CompanyEntities, TextWriter> Get { get; }
    }
}
