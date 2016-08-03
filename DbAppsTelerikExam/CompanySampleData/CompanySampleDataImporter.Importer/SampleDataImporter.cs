namespace CompanySampleDataImporter.Importer
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using CompanySampleDataImporter.Data;
    using CompanySampleDataImporter.Importer.Interfaces;

    public class SampleDataImporter
    {
        private TextWriter textWriter;

        private SampleDataImporter(TextWriter writer)
        {
            this.textWriter = writer;
        }

        public static SampleDataImporter Create(TextWriter writer)
        {
            return new SampleDataImporter(writer);
        }

        public void Import()
        {
            var assembly = Assembly.GetExecutingAssembly();

            assembly.GetTypes()
               .Where(t => typeof(IImporter).IsAssignableFrom(t) && !t.IsInterface)
               .Select(t => (IImporter)Activator.CreateInstance(t))
               .OrderBy(t => t.Order)
               .ToList()
               .ForEach(i =>
                   {
                       var db = new CompanyEntities();
                       textWriter.Write(i.Message);
                       i.Get(db, textWriter);

                       textWriter.WriteLine();
                   }
               );
        }
    }
}
