namespace CompanySampleDataImporter.Importer.Importers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CompanySampleDataImporter.Importer.Interfaces;
    using CompanySampleDataImporter.Data;

    public class EmployeesImporter : IImporter
    {
        private const int NumberOfEmployees = 5000;

        public string Message
        {
            get
            {
                return "Importing employees...";
            }
        }

        public int Order
        {
            get
            {
                return 2;
            }
        }

        public Action<CompanyEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    var departmentIds = db
                        .Departments
                        .Select(d => d.Id)
                        .ToList();

                    for (int i = 0; i < NumberOfEmployees; i++)
                    {
                        var randomDepIndex = RandomGenerator.GetRandomNumber(0, departmentIds.Count - 1);
                        var randomDepartment = departmentIds[randomDepIndex];


                        db.Employees.Add(new Employee()
                        {
                            FirstName = RandomGenerator.GetRandomString(5, 20),
                            LastName = RandomGenerator.GetRandomString(5, 20),
                            YearSalary = RandomGenerator.GetRandomNumber(50000, 200000),
                            DepartmentId = randomDepartment
                        });

                        if (i % 10 == 0)
                        {
                            tr.Write(".");
                        }

                        if (i % 100 == 0)
                        {
                            db.SaveChanges();
                            db.Dispose();
                            db = new CompanyEntities();
                        }
                    }

                    db.SaveChanges();
                };
            }
        }
    }
}
