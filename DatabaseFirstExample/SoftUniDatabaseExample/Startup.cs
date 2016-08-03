namespace SoftUniDatabaseExample
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var context = new SoftUniEntities1();

            var employee = context.Employees.First();

            var entity = context.Entry(employee);
            entity.State=EntityState.Unchanged;

            //context.SaveChanges();
        }
    }
}
