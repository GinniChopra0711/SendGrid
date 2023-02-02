using Web_Security_Lab_Day3.Data;
using Web_Security_Lab_Day3.Models;

namespace Web_Security_Lab_Day3.Repositories
{
    public class ShopRepo
    {

        ApplicationDbContext _context;

        public ShopRepo(ApplicationDbContext context)
        {
            this._context = context;
           
        }


      
    }
}
