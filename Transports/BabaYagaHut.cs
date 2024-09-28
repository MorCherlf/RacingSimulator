using RacingSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingSimulator.Transports
{
    public class BabaYagaHut : LandTransport
    {
        public override double Speed => 5;
        public override string Name => "Baba Yaga's Hut";

        public override double RestInterval => 12;

        public override double RestDuration(int restNumber)
        {
            if (restNumber == 1)
                return 4;
            else
                return 8;
        }
    }
}

