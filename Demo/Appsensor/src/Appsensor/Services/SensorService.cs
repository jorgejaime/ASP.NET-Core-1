using Appsensor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appsensor.Services
{
    public class SensorService : ISensorService
    {

        public IEnumerable<TemperatureSensor> GetSensorData()
        {
            return new List<TemperatureSensor>
            {
                new TemperatureSensor
                {
                    SensorId = 1,
                    TemperatureValue = 25,
                    DateSample = DateTime.Now
                },
                 new TemperatureSensor
                {
                    SensorId = 1,
                    TemperatureValue = 26,
                    DateSample = DateTime.Now
                },
                  new TemperatureSensor
                {
                    SensorId = 1,
                    TemperatureValue = 28,
                    DateSample = DateTime.Now
                },
                   new TemperatureSensor
                {
                    SensorId = 1,
                    TemperatureValue = 29,
                    DateSample = DateTime.Now
                },
                      new TemperatureSensor
                {
                    SensorId = 1,
                    TemperatureValue = 30,
                    DateSample = DateTime.Now
                }
            };
            
        }

        public IEnumerable<string> GetAlerts()
        {
            var alerts = new List<string>
            {
                "Temperatura al máximo en el sensor 1",
                "Temperatura al mínimo en el sensor 2"
            };

            return alerts;
        }

    }
}
