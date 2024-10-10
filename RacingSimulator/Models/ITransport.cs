using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingSimulator.Models
{
    public interface ITransport
    {
        string Name { get; }
        double Speed { get; }
        double CalculateTime(double distance);  
    }

}
