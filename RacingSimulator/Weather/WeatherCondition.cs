using RacingSimulator.Models;
using System;

namespace RacingSimulator.Weather
{
    public enum WeatherType
    {
        Sunny,
        Rainy,
        Windy,
        Foggy
    }

    public class WeatherCondition
    {
        public WeatherType Type { get; private set; }

        // Abstartct
        public WeatherCondition(WeatherType type)
        {
            Type = type;
        }

        // Adjustment For Weather 
        public double GetSpeedAdjustment(ITransport transport)
        {
            switch (Type)
            {
                case WeatherType.Sunny:
                    return 1.0;
                case WeatherType.Rainy:
                    if (transport is LandTransport)
                        return 0.8;
                    if (transport is AirTransport)
                        return 0.9;
                    break;
                case WeatherType.Windy:
                    if (transport is AirTransport)
                        return 0.7; 
                    if (transport is LandTransport)
                        return 1.0; 
                    break;
                case WeatherType.Foggy:
                    if (transport is AirTransport)
                        return 0.6; 
                    if (transport is LandTransport)
                        return 0.85;
                    break;
                default:
                    return 1.0; 
            }
            return 1.0;
        }

        public override string ToString()
        {
            return Type switch
            {
                WeatherType.Sunny => "Sunny",
                WeatherType.Rainy => "Rainy",
                WeatherType.Windy => "Windy",
                WeatherType.Foggy => "Foggy",
                _ => "Unknown Weather"
            };
        }
    }
}
