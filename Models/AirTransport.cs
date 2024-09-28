using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingSimulator.Models
{
    public abstract class AirTransport : ITransport
    {
        public abstract double Speed { get; }
        public abstract string Name { get; }
        public abstract double GetSpeedCoefficient(double distance); 

        public double CalculateTime(double distance)
        {
            double time = distance / (Speed * GetSpeedCoefficient(distance));
            return time;
        }
    }
}

