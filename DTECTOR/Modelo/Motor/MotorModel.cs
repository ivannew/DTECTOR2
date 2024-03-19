using System;
using System.Collections.Generic;
using System.Text;

namespace DTECTOR.Modelo.Motor
{
    class MotorModel
    {
        public string Id = string.Empty;
        public int numeroMotor { get; set; }
        public string ubicacionMotor { get; set; } = string.Empty;
        public DateTime fecha { get; set; }
    }
}
