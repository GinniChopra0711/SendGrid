using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Web_Security_Lab_Day3.Data;
using Web_Security_Lab_Day3.Models;

namespace Web_Security_Lab_Day3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;

     


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Home page shows list of items.
        // Item price is set through the ViewBag.
        public IActionResult Index()
        {
            return View("Index", "3.55|CAD");
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

        // This method receives and stores
        // the Paypal transaction details.
        [HttpPost]
        public JsonResult PaySuccess([FromBody] IPN ipn)
        {
            try
            {
                _context.IPNs.Add(ipn);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            return Json(ipn);
        }

        // Home page shows list of items.
        // Item price is set through the ViewBag.
        [Authorize]
        public IActionResult Confirmation(string confirmationId)
        {
             IPN transaction = _context.IPNs.FirstOrDefault(t => t.paymentID == confirmationId);

            return View("Confirmation", transaction);

            // dummy data
            //System.Console.WriteLine("confirmationId      " + confirmationId);
            //IPN iPN = new IPN
            //{
            //    create_time = DateTime.Now.ToString("dd'/'MM'/'yyyy, HH:mm"),
            //    payerFirstName = "Ginni",
            //    payerEmail = "gchopra2@my.bcit.ca",
            //    amount = "$3.55 CAD",
            //    paymentMethod = "paypal",
            //    //paymentID = "MPIH5HA4J269406WS7648845"
            //    paymentID = confirmationId
            //};


            //return View("Confirmation", iPN);
        }


    }
}