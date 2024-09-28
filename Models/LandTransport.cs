namespace RacingSimulator.Models
{
    public abstract class LandTransport : ITransport
    {
        public abstract double Speed { get; }
        public abstract string Name { get; }
        public abstract double RestInterval { get; } // Time interval for rest after driving
        public abstract double RestDuration(int restNumber); 

        public double CalculateTime(double distance)
        {
            double time = 0;
            double currentDistance = 0;
            int restCount = 0;

            while (currentDistance < distance)
            {
                double nextDistance = Speed * RestInterval;
                if (currentDistance + nextDistance > distance)
                {
                    nextDistance = distance - currentDistance;
                }
                time += nextDistance / Speed;
                currentDistance += nextDistance;

                if (currentDistance < distance)
                {
                    restCount++;
                    time += RestDuration(restCount);
                }
            }

            return time;
        }
    }
}
