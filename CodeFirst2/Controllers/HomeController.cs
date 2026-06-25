using CodeFirst2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace CodeFirst2.Controllers
{
    public class HomeController : Controller
    {
        private readonly CustomerDBContext context;

        public HomeController(CustomerDBContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            var ctmrinfo = context.Customers.ToList();

            return View(ctmrinfo);
        }


        [HttpGet]

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Customer ctsr)
        {
            if (ModelState.IsValid)
            {
                await context.Customers.AddAsync(ctsr);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");

            }

            return View(ctsr);
        }

        [HttpGet]

        public async Task<IActionResult> Edit_Customer(int? id)
        {
            if (id == null || context.Customers == null)
            {
                return NotFound();
            }
            var ctmrinfo = await context.Customers.FindAsync(id);

            if (ctmrinfo == null)
            {
                return NotFound();
            }
            return View(ctmrinfo);

        }


        [HttpPost]

        public async Task<IActionResult> Edit_Customer(int? id, Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                context.Customers.Update(customer);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            return View(customer);
        }

        [HttpGet]

        public async Task<IActionResult> Details(int? id)
        {
            var ctmrdetais = await context.Customers.FirstOrDefaultAsync(x => x.Id == id);


            return View(ctmrdetais);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var dctmr =await context.Customers.FirstOrDefaultAsync(x=>x.Id == id);
            return View(dctmr);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dctmr = await context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (dctmr != null)
            {
                context.Customers.Remove(dctmr);
                await context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Home");
        }




















        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
