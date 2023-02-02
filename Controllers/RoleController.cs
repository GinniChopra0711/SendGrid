using Microsoft.AspNetCore.Mvc;
using Web_Security_Lab_Day3.Data;
using Web_Security_Lab_Day3.Repositories;
using Web_Security_Lab_Day3.ViewModels;

namespace Web_Security_Lab_Day3.Controllers
{
    public class RoleController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RoleController(ApplicationDbContext context)
        {            
            _context = context;
        }



        // GET: Role
        public ActionResult Index()
        {
            RoleRepo roleRepo = new RoleRepo(_context);
            return View(roleRepo.GetAllRoles());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RoleVM newRole)
        {

            RoleRepo roleRepo = new RoleRepo(_context);

            bool result = roleRepo.CreateRole(newRole.RoleName);

            if (!result)
            {
                return View(newRole);
            }
            else
            {

                return RedirectToAction("Index");

            }
        }
    }
}
