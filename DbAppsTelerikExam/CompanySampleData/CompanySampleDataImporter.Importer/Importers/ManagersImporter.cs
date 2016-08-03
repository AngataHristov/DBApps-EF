﻿namespace CompanySampleDataImporter.Importer.Importers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CompanySampleDataImporter.Importer.Interfaces;
    using CompanySampleDataImporter.Data;

    public class ManagersImporter : IImporter
    {

        public string Message
        {
            get
            {
                return "Importing managers...";
            }
        }

        public int Order
        {
            get
            {
                return 3;
            }
        }

        public Action<CompanyEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    var levels = new int[] { 5, 5, 10, 10, 10, 15, 15, 15, 15 };

                    var allEmployeeIds = db.Employees
                        .OrderBy(e => Guid.NewGuid())
                        .Select(e => e.Id)
                        .ToList();

                    var currentPercentage = 0;
                    List<int> previousManagers = null;

                    for (int i = 0; i < levels.Length; i++)
                    {
                        var level = levels[i];

                        var skip = (int)((currentPercentage * allEmployeeIds.Count) / 100.0);
                        var take = (int)((level * allEmployeeIds.Count) / 100.0);

                        var currenEmployeesIds = allEmployeeIds
                            .Skip(skip)
                            .Take(take)
                            .ToList();

                        var employees = db.Employees
                            .Where(e => currenEmployeesIds.Contains(e.Id))
                            .ToList();


                        foreach (var emp in employees)
                        {
                            emp.ManagerId =
                                previousManagers == null ?
                                null :
                                (int?)previousManagers[RandomGenerator.GetRandomNumber(0, previousManagers.Count - 1)];
                        }

                        tr.Write(".");

                        db.SaveChanges();
                        db.Dispose();
                        db = new CompanyEntities();

                        previousManagers = currenEmployeesIds;

                        currentPercentage += level;
                    }

                    db.SaveChanges();
                };
            }
        }
    }
}
