using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Serilog;
using SerilogApp.Entities;

namespace SerilogApp.Controllers
{
    public class PersonController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDiagnosticContext _diagnosticContext;

        public PersonController(IDiagnosticContext diagnosticContext, ILogger<HomeController> logger)
        {
            _diagnosticContext = diagnosticContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost()]
        public IActionResult Index(Person person)
        {
            
            try
            {
                int x = int.Parse(person.Email);
            }
            catch (Exception)
            {
                _diagnosticContext.Set("person", person.ToJson());
                _logger.LogError("Error person",person.ToJson());
                
            }
           
           
            return View(person);
        }
    }
}
