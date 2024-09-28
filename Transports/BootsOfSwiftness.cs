using RacingSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingSimulator.Transports
{
    public class BootsOfSwiftness : LandTransport
    {
        public override double Speed => 10;
        public override string Name => "Boots of Swiftness";

        public override double RestInterval => 6; 

        public override double RestDuration(int restNumber)
        {
            if (restNumber == 1)
                return 1;
            else
                return 3;
        }
    }
}
