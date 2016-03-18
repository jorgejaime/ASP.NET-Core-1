using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appsensor.Models
{
    public class Dashboard
    {
        public IEnumerable<TemperatureSensor> Temperaturas { get; set; }
        public string Mensaje { get; set; }
    }
}
