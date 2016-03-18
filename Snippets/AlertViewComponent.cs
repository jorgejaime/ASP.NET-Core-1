using Appsensor.Services;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appsensor.ViewComponents
{
    public class AlertViewComponent : ViewComponent
    {

        private ISensorService _sensorService;

        public AlertViewComponent(ISensorService sensorSensor)
        {
            _sensorService = sensorSensor;
        }

        public IViewComponentResult Invoke()
        {
            return View(_sensorService.GetAlerts());
        }
    }
}
