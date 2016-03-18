using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appsensor.Models
{
    public class TemperatureSensor
    {
        public int SensorId { get; set; }
        public decimal TemperatureValue { get; set; }
        public DateTime DateSample { get; set; }
    }
}
