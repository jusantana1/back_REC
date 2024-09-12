using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Csharp.DataBase;
using Csharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Csharp.Controllers
{
    [Route("[controller]")]
    public class CadUserController : Controller
    {
        private readonly ILogger<CadUserController> _logger;
        private Usua_Repositorio _repository = new Usua_Repositorio();

        public CadUserController(ILogger<CadUserController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            List<CadUserModel> cadUserModels = _repository.ListarClientes();

            return View(cadUserModels);
        }
        
        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create (CadUserModel cadUserModel) 
        {
            if(ModelState.IsValid)
            {
                _repository.InserirCliente(cadUserModel);
                return RedirectToAction("Index"); 
            }
            return View(cadUserModel); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}