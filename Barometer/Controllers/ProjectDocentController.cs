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
        public ActionResult MakeProject(HttpPostedFileBase file, String projectName)
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
                int columnCount = 0;
                foreach (string dc in value)
                {
                    if (dc.Equals("FirstName") || dc.Equals("LastName") || dc.Equals("StudentNr") || dc.Equals("Year") || dc.Equals("ProjectGroup"))
                    {
                        dt.Columns.Add(new DataColumn(dc));
                        columnCount++;
                    }
                    //else
                        //errorScherm
                }
                //if(columnCount != 5)
                    //errorScherm
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

                Project currentProject = new Project(projectName,null, new DateTime(2014, 1, 1), new DateTime(2014, 1, 1), null);
                ProjectGroup currentGroup = null;
                ProjectGroup dbGroup = null;
                Student currentStudent = null;
                List<ProjectGroup> groupsToAdd = new List<ProjectGroup>();
                List<Student> studentsToAdd = new List<Student>();
                var myEnumerable = dt.AsEnumerable();
                foreach (var item in myEnumerable)
                {
                    string pgroup = item.Field<String>("ProjectGroup");
                    int studnr = int.Parse(item.Field<String>("StudentNr"));

                    currentStudent = _db.Students.Find(studnr);

                    var groupModel = from r in _db.ProjectGroups
                                     where r.ClassCode == pgroup
                                     select r;
                    dbGroup = groupModel.FirstOrDefault();

                    if (dbGroup == null)
                    {
                        if (currentGroup == null)
                        {
                            ProjectGroup newGroup = new ProjectGroup(pgroup, currentProject);
                            groupsToAdd.Add(newGroup);
                            currentGroup = newGroup;
                        }
                        else
                        {
                            if (!currentGroup.ClassCode.Equals(pgroup))
                            {
                                ProjectGroup newGroup = new ProjectGroup(pgroup, currentProject);
                                currentProject.ProjectGroups.Add(newGroup);
                                groupsToAdd.Add(newGroup);
                                currentGroup = newGroup;
                            }
                        }
                    }
                    else
                        currentGroup = dbGroup;

                    if (currentStudent == null)
                    {
                        Student newStudent = new Student(
                            int.Parse(item.Field<String>("StudentNr")),
                            item.Field<String>("FirstName"),
                            item.Field<String>("LastName"),
                            int.Parse(item.Field<String>("Year")),
                            null); // mentor

                        studentsToAdd.Add(newStudent);
                        currentStudent = newStudent;
                    }

                    if (currentStudent != null && currentGroup != null)
                    {
                        currentStudent.ProjectGroup.Add(currentGroup);
                        if (currentGroup.ProjectStudents == null)
                            currentGroup.ProjectStudents = new List<Student>();
                        currentGroup.ProjectStudents.Add(currentStudent);
                    }
                }

                _db.Projects.Add(currentProject);

                foreach (Student stud in studentsToAdd)
                {
                    _db.Students.Add(stud);
                }
                foreach (ProjectGroup group in groupsToAdd)
                {
                    _db.ProjectGroups.Add(group);
                }
                
                _db.SaveChanges();
                return RedirectToAction("ShowStudents");
            }
            return RedirectToAction("ShowStudents");
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
