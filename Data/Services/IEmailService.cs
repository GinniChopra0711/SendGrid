using Web_Security_Lab_Day3.Models;
using SendGrid;
using System.Threading.Tasks;


namespace Web_Security_Lab_Day3.Data.Services
{
    public interface IEmailService
    {

            Task<Response> SendSingleEmail(ComposeEmailModel payload);

    }
}
