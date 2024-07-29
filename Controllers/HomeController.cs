using Microsoft.AspNetCore.Mvc;
using PhilaniBiography.Models;
using System.Diagnostics;
using PhilaniBiography.Helpers;
using SmartBreadcrumbs.Attributes;


namespace PhilaniBiography.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger , IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        public IActionResult Index()
        {
            return View();
        }      

        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Education()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View();
        }


        public IActionResult About()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Submit(ContactForm model)
        {
            EmailDTO emailDTO = new EmailDTO
            {
                UserName = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Comment = model.Message
            };

            Mail m = new Mail(Configuration, _logger);

            List<string> recipients = new List<string>
            {
                "philaniprnc@gmail.com"
            };

            foreach (var recipient in recipients)
            {
                bool result = m.SendAdminSupportRequestMail(recipient, model);
                if (!result)
                {
                    break;
                }
            }

            return View("Index", model);
        }


        public IActionResult DownloadCV()
        {               
                var downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                var filePath = Path.Combine(downloadsPath, "SupportPortalUserManual.pdf");
            
                var fileBytes = System.IO.File.ReadAllBytes(filePath);
              
                return File(fileBytes, "application/pdf", "SupportPortalUserManual.pdf");
        }

        public IActionResult ViewCV()
        {             
               var downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                var filePath = Path.Combine(downloadsPath, "SupportPortalUserManual.pdf");
               
                var fileBytes = System.IO.File.ReadAllBytes(filePath);
               
                Response.Headers.Add("Content-Disposition", "inline; filename=SupportPortalUserManual.pdf");
                return File(fileBytes, "application/pdf");
        }       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
