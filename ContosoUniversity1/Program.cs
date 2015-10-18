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

                //var c =db.GetCourse("%Git%");
                var c = db.Course;
                foreach (var item in c)
                {
                    Console.WriteLine(item.Credits+item.Title);    
                }
                
            }





        }

        private static void 並行模式()
        {
            using (var db = new ContosoUniversityEntities())
            {
                var c = db.Course.Find(1);
                c.Credits = CourseCredits.one;
                Console.ReadKey();
                db.SaveChanges();
            }
        }

        private static void 離線模式()
        {
            Course c;
            using (var db = new ContosoUniversityEntities())
            {
                c = db.Course.Find(1);
                Console.WriteLine(c.Credits);
                c.Credits = CourseCredits.two;
                Console.WriteLine(db.Entry(c).State);
            }
            using (var db = new ContosoUniversityEntities())
            {
                //Console.WriteLine(db.Entry(c).State);
                //db.Course.Attach(c);
                //db.Entry(c).State = System.Data.Entity.EntityState.Modified;
                Console.WriteLine(db.Entry(c).State);
                //db.SaveChanges();

                Console.WriteLine(c.Credits);
            }
        }

        private static void d1()
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

                //                var Departments = db.Department.Include("Course");
                //                foreach (var dept in Departments)
                //                {
                //                    Console.WriteLine("#" + dept.Name);
                //                    foreach (var item in dept.Course)
                //                    {
                //                        Console.WriteLine("#############" + item.Title);
                //                    }

                //                }
                //                foreach (var c in db.Course)
                //                {
                //                    //c.ModifyedON = DateTime.Now;

                //                }
                //                var c1 = new Course()
                //                {
                //                    ModifyedON = DateTime.Now
                //                    ,
                //                    DepartmentID = 1
                //                    ,
                //                    Title = "test"



                //                };
                //                //db.Course.Add(c1);

                //                //db.SaveChanges();


                //                // var c2 = db.Course.Find(7);

                //                // c2.Instructor.Add(db.Person.Find(5));
                //                //db.SaveChanges();
                //                var dddd = db.Database.SqlQuery<Course2>(@"select d.Name as deptName,c.Title from [dbo].[Department]  d 
                //                inner join Course  c
                //                on d.DepartmentID =c.DepartmentID");

                //                foreach (var item in dddd)
                //                {
                //                    Console.WriteLine("aaaa" + item.deptName);
                //                }
                var cc = db.Course.Find(1);
                //cc.Credits = 2;

                //cc.Credits=2;
                //var ce = db.Entry(cc);

                //if (ce.State == System.Data.Entity.EntityState.Modified) { 
                //Console.WriteLine("Changed"+cc.Credits);
                //Console.WriteLine("Ori"+ce.OriginalValues.GetValue<int>("Credits"));
                //Console.WriteLine("");

                //}

                db.SaveChanges();


            }
        }
    }
}
