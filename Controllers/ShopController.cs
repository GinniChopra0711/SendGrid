using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Security_Lab_Day3.Data;
using Web_Security_Lab_Day3.Models;
using Web_Security_Lab_Day3.Repositories;

namespace Web_Security_Lab_Day3.Controllers
{
    public class ShopController : Controller
    {

        private ApplicationDbContext _context;
        public ShopController(ApplicationDbContext context)
        {
            _context = context;

        }

        public IActionResult Index()
        {
            DbSet<Product> products = _context.Product;
            return View(products);
        }

     
    }
}
