using NHibernate;
using NHibernate.Linq;
using NhibernateHelper;
using SimpleWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var data = session.CreateCriteria<Student>().List<Student>().ToList();

                var test = session.Query<Student>()
                    .Where(x => x.Subject == "CS")
                    .InsertInto(c => new Student { Name = c.Name + "dog", Subject = "test linq" });
            }
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
