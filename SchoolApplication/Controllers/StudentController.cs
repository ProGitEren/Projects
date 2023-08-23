using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApplication.Data;
using SchoolApplication.Models;
using Microsoft.EntityFrameworkCore;
namespace SchoolApplication.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public StudentController(ApplicationDbContext db) 
        {
            _db = db;      
        }
        // GET: StudentController
        public IActionResult Index()
        {
            IEnumerable<Models.Student> obj = _db.Students.ToList(); 
            return View(obj);
        }

        // GET: StudentController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (student.Price < 250000) 
            {
                ModelState.AddModelError("CustomError", "The Price you have will not be enough to register our school please gain more money and then come back. See You!!");
            }
            if (ModelState.IsValid)
            {
                _db.Students.Add(student);
                _db.SaveChanges();
                TempData["success"] = "Student Created successfully";
                return RedirectToAction("Index");
            }
            return View(student);
            }

        // GET: StudentController/Edit/5
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0) 
            {
                return NotFound();
            }
            Student? stufromdb=_db.Students.Find(id);
            //var stufrom = _db.Students.FirstOrDefault(s=>s.Id==id);
            //var stufrom2 = _db.Students.SingleOrDefault(s=>s.Id==id);
            if (stufromdb == null) { return NotFound(); }

            return View(stufromdb);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student stu)
        {
            if (stu.Price < 250000) 
            {
                ModelState.AddModelError("CustomError", "The Price you have will not be enough to register our school please gain more money and then come back. See You!!");
            }
            if (ModelState.IsValid) 
            {
                _db.Students.Update(stu);
                _db.SaveChanges();
                TempData["success"] = "Student Updated successfully";
                return RedirectToAction("Index");
            }
            return View(stu);
        }

        // GET: StudentController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Student? student = _db.Students.Find(id);
            if (student == null) 
            {
                return NotFound();
            }
            
            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            Student? student = _db.Students.Find(id);

            if (student == null) 
            {
                return NotFound();
            }

            _db.Students.Remove(student);
            _db.SaveChanges();
            TempData["success"] = "Student Deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
