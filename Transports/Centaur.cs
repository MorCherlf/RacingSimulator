using RacingSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingSimulator.Transports
{
    public class Centaur : LandTransport
    {
        public override double Speed => 15;
        public override string Name => "Centaur";

        public override double RestInterval => 8;

        public override double RestDuration(int restNumber)
        {
            if (restNumber == 1)
                return 2;
            else
                return 5;
        }
    }
}

