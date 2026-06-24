using CodeFirst1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Reflection.Metadata.Ecma335;

namespace CodeFirst1.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDBContext studentdb;

        public StudentController(StudentDBContext studentdb)
        {
            this.studentdb = studentdb;
        }

        public IActionResult Index()
        {
            var studentdata = studentdb.Students.ToList();
            return View(studentdata);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]


        public async Task<IActionResult> Create(Student std)
        {
            if (ModelState.IsValid)
            {
                await studentdb.Students.AddAsync(std);
                await studentdb.SaveChangesAsync();
                TempData["insert_data"] = "Data Inserted Successfully";
                return RedirectToAction("Index", "Student");
            }

            return View(std);

        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null || studentdb.Students == null)
            {
                return NotFound();
            }

            var stddetails =  await studentdb.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (stddetails == null)
            {
                return NotFound();
            }

            return View(stddetails);
        }


        [HttpGet]

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null || studentdb.Students ==null)
            {
                return NotFound();
            }
            
            var stdedit = await studentdb.Students.FindAsync(id);
            if (stdedit == null)
            {
                return NotFound();
            }

            return View(stdedit);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int? id ,Student std)
        {
            if(id != std.Id)
            {
                return NotFound();
            }
              

            if (ModelState.IsValid)
            {
                 studentdb.Students.Update(std);
                await studentdb.SaveChangesAsync();
                TempData["update_data"] = "Data updated Successfully";
                return RedirectToAction("Index", "Student");
            }
            return View(std);

        }


        [HttpGet]

        public async Task<IActionResult> Delete(int? id)
        {
            var std = await studentdb.Students.FirstOrDefaultAsync(x => x.Id == id);
            return View(std);
        }

        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
           var stddata = await studentdb.Students.FindAsync(id);
            if (stddata != null)
            {
                studentdb.Students.Remove(stddata);
                await studentdb.SaveChangesAsync();
                TempData["Delete_Data"] = "Data deleted Successfully";
                return RedirectToAction("Index", "Student");
            }
            return NotFound();

        }

    }
}
