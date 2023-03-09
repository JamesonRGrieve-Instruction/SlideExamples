using EXSM3944_Slides.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EXSM3944_Slides.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>();

        // GET: StudentController
        public ActionResult Index()
        {
            return View(students);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View(students.Single(student => student.ID == id));
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm]Student student)
        {
            student.FirstName = student.FirstName.Trim();
            student.LastName = student.LastName.Trim();
            
            if (student.FirstName == "John" && student.LastName == "Doe")
            {
                ModelState.AddModelError("", "Please do not use fake names.");
            }

            ActionResult returnChoice = View(student);
            if (ModelState.IsValid)
            {
                returnChoice = RedirectToAction(nameof(Index));
            }
            else
            {
                students.Add(student);
            }

            return returnChoice;
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(students.Single(student => student.ID == id));
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm] Student student)
        {
            try
            {
                Student target = students.Single(findStudent => findStudent.ID == id);
                target.ID = student.ID;
                target.FirstName = student.FirstName.Trim();
                target.LastName = student.LastName.Trim();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(students.Single(student => student.ID == id));
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [FromForm] Student student)
        {
            try
            {
                students.Remove(students.Single(deleteStudent => deleteStudent.ID == id));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
