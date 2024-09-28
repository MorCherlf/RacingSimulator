using RacingSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingSimulator.Transports
{
    public class Broomstick : AirTransport
    {
        public override double Speed => 20; 
        public override string Name => "Broomstick";

        public override double GetSpeedCoefficient(double distance) => 1.0;
    }
}
