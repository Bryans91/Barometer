using Barometer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barometer.Controllers
{
    public class ProjectDocentController : Controller
    {
        BaroDB _db = new BaroDB();

        //
        // GET: /ProjectDocent/

        public ActionResult MakeProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MakeProject(HttpPostedFileBase file)
        {
            // Read the CSV file name & file path  
            // I am usisg here Kendo UI Uploader  
            string path = null;

            List<Student> students = new List<Student>();

            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                path = AppDomain.CurrentDomain.BaseDirectory + "upload\\" + fileName;
                file.SaveAs(path);

                // Read the CSV file data  
                StreamReader sr = new StreamReader(path);
                string line = sr.ReadLine();
                string[] value = line.Split(';');
                DataTable dt = new DataTable();
                DataRow row;
                foreach (string dc in value)
                {
                    dt.Columns.Add(new DataColumn(dc));
                }
                while (!sr.EndOfStream)
                {
                    value = sr.ReadLine().Split(';');
                    if (value.Length == dt.Columns.Count)
                    {
                        row = dt.NewRow();
                        row.ItemArray = value;
                        dt.Rows.Add(row);
                    }
                }
                // Insert CSV data in List  

                var myEnumerable = dt.AsEnumerable();
                foreach (var item in myEnumerable)
                {
                    // set the CSV file column with my class  
                    // here it is Important that all field should be string when your inset in DB  

                    Student stud = new Student(
                        int.Parse(item.Field<String>("StudentNr")),
                        item.Field<String>("FirstName"),
                        item.Field<String>("LastName"),
                        int.Parse(item.Field<String>("Year")), 
                        null); // mentor

                    //Student stud = new Student();
                    //stud.Id = int.Parse(item.Field<String>("Id"));
                    //stud.FirstName = item.Field<String>("FirstName");
                    //stud.LastName = item.Field<String>("LastName");
                    //stud.StudentNr = int.Parse(item.Field<String>("StudentNr"));

                    students.Add(stud);
                }

                foreach (Student stud in students)
                {
                    _db.Students.Add(stud);
                }

                // Insert in database from List  

                _db.SaveChanges();
                //return RedirectToAction("ShowStudents", students);
            }
            return RedirectToAction("ShowStudents", students);
        }


        //Tijdelijke View voor studenten te show van de DB
        public ActionResult ShowStudents()
        {
            return View(_db.Students);
        }

        public ActionResult MakeQuestionList()
        {
            return View();
        }

        public ActionResult CheckProjectGroups()
        {
            return View();
        }

        public ActionResult AddTutorToGroup()
        {
            return View();
        }

        public ActionResult DetermineFillDates()
        {
            return View();
        }

    }
}
