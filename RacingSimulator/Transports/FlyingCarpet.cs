using RacingSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RacingSimulator.Transports
{
    public class FlyingCarpet : AirTransport
    {
        public override double Speed => 12;
        public override string Name => "Flying Carpet";

        public override double GetSpeedCoefficient(double distance)
        {
            if (distance < 1000)
                return 1.0;
            else if (distance < 5000)
                return 1.2;
            else
                return 1.5;
        }
    }
}
