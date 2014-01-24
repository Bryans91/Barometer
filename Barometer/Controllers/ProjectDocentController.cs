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
                //var myEnumerable = dt.AsEnumerable();
                //foreach (var item in myEnumerable)
                //{

                //    Student stud = new Student(
                //        int.Parse(item.Field<String>("StudentNr")),
                //        item.Field<String>("FirstName"),
                //        item.Field<String>("LastName"),
                //        int.Parse(item.Field<String>("Year")), 
                //        null); // mentor
                //    stud.ProjectGroup.Add(
                //        new ProjectGroup(null, item.Field<String>("ProjectGroup"),null ,null )); 
                //        // moet nog aangevuld worden

                //    students.Add(stud);
                //}

                ProjectGroup currentGroup;
                var myEnumerable = dt.AsEnumerable();
                foreach (var item in myEnumerable)
                {
                    string pgroup = item.Field<String>("ProjectGroup");

                    var model = from r in _db.ProjectGroups
                                where r.ClassCode == pgroup
                                select r;
                    currentGroup = model.FirstOrDefault();
                }
                //List<Student> studentsToAdd = students;
                //foreach (Student stud in students)
                //{
                //    var model = from r in _db.Students
                //                where r.Studentnr == stud.Studentnr
                //                select r;
                //    studentsToAdd.Remove(model.FirstOrDefault());
                //    //model.FirstOrDefault().ProjectGroup.Add(stud.ProjectGroup);
                //}

                //// Insert non-existing students into database
                //foreach (Student s in studentsToAdd)
                //{
                //    _db.Students.Add(s);
                //}

                //foreach (Student st in students)
                //{

                //}

                //

                //_db.SaveChanges();
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
