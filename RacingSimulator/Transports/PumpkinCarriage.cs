using RacingSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingSimulator.Transports
{
    public class PumpkinCarriage : LandTransport
    {
        public override double Speed => 7;
        public override string Name => "Pumpkin Carriage";

        public override double RestInterval => 10;

        public override double RestDuration(int restNumber)
        {
            if (restNumber == 1)
                return 3;
            else
                return 6;
        }
    }
}
