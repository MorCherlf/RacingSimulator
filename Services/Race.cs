using System;
using System.Collections.Generic;
using RacingSimulator.Weather;
using RacingSimulator.Transports;
using RacingSimulator.Models;

namespace RacingSimulator.Services
{
    public class Race
    {
        private double _distance;   
        private Type _raceType;     // Racing Type (Land, Air, Mix)
        private WeatherCondition _weather;  // Weather
        private List<ITransport> _participants = new List<ITransport>(); 
        
        // Abstract Racing
        public Race(double distance, Type raceType, WeatherCondition weather)
        {
            _distance = distance;
            _raceType = raceType;
            _weather = weather;
        }

        public void AddParticipant(ITransport transport)
        {
            // Check Type of Vehicle is Available for Racing Type
            if (_raceType.IsAssignableFrom(transport.GetType()))
            {
                _participants.Add(transport);
            }
            else
            {
                throw new InvalidOperationException("The Vehicle Type is not acceptable For the Race");
            }
        }

        public (ITransport?, double) Start()
        {
            ITransport? winner = null;    // Save Winner
            double bestTime = double.MaxValue;  // Save BestTime

            foreach (var participant in _participants)
            {
                double adjustedSpeed = participant.Speed * _weather.GetSpeedAdjustment(participant);
                double timeToFinish = _distance / adjustedSpeed;

                if (timeToFinish < bestTime)
                {
                    bestTime = timeToFinish;
                    winner = participant;
                }
            }

            return (winner, bestTime);
        }
    }
}
