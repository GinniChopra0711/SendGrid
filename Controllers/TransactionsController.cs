using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Security_Lab_Day3.Data;
using Web_Security_Lab_Day3.Models;

namespace Web_Security_Lab_Day3.Controllers
{
    public class TransactionsController : Controller
    {

        private ApplicationDbContext _context;
        

        public TransactionsController(ApplicationDbContext context)
        {
            _context = context;
            
        }




        // Home page shows list of items.
        // Item price is set through the ViewBag.
        [Authorize]
        public IActionResult Transactions()
        {
            DbSet<IPN> items = _context.IPNs;

            foreach (var item in items)
            {
                DateTime createDT = Convert.ToDateTime(item.create_time);
                string stringCreateDT = createDT.ToString("dd'/'MM'/'yyyy, HH:mm");
                item.create_time = stringCreateDT;
            }

            return View(items);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
