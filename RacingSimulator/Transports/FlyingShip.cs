using RacingSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingSimulator.Transports
{
    public class FlyingShip : AirTransport
    {
        public override double Speed => 18;
        public override string Name => "Flying Ship";

        public override double GetSpeedCoefficient(double distance)
        {
            return 0.95;
        }
    }
}
