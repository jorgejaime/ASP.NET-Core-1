using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Appsensor.Services;
using Appsensor.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Appsensor.Controllers
{
    public class HomeController : Controller
    {

        private ISensorService _sensorService;

        public HomeController(ISensorService sensorSensor)
        {
            _sensorService = sensorSensor;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var modelo = new Dashboard
            {
                Temperaturas = _sensorService.GetSensorData(),
                Mensaje = ""
            };
            return View(modelo);
        }

        
        public IActionResult EnviarMensaje(string mensaje)
        {
            var modelo = new Dashboard
            {
                Temperaturas = _sensorService.GetSensorData(),
                Mensaje = mensaje
            };
            return View("Index",modelo);
        }

    }
}
