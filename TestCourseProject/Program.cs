using ComputerStore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCourseProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(CompContext db = new CompContext())
            {
                db.Company.Select(i => i).ToList();
            }
        }
    }
}
