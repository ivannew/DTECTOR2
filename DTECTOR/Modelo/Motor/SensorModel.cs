using System;
using System.Collections.Generic;
using System.Text;

namespace DTECTOR.Modelo.Motor
{
    class SensorModel
    {
        public string Id = string.Empty;
        public int numero { get; set; }
        public string modelo { get; set; } = string.Empty;
        public DateTime fecha { get; set; } 
        public string ubicacion { get; set; } = string.Empty;
    }
}
