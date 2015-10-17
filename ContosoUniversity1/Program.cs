using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ContosoUniversityEntities())
            {
                //var data = from p in db.Course
                //           where p.Title.StartsWith("Git")
                //           select p;

                //foreach (var item in data)
                //{
                //    Console.WriteLine(item.CourseID + "\t" + item.Title);
                //}

                var Departments = db.Department.Include("Course");
                foreach (var dept in Departments)
                {
                    Console.WriteLine("#"+dept.Name);
                    foreach (var item in dept.Course)
                    {
                        Console.WriteLine("#############" + item.Title);
                    }

                }
                foreach (var c in db.Course)
                {
                    //c.ModifyedON = DateTime.Now;

                }
                var c1 = new Course()
                {
                    ModifyedON = DateTime.Now
                    ,DepartmentID = 1
                    ,Title ="test"



                };
                //db.Course.Add(c1);
                
                //db.SaveChanges();


                var c2 = db.Course.Find(7);
                
                c2.Instructor.Add(db.Person.Find(5));
               db.SaveChanges();

               
            }
        }
    }
}
