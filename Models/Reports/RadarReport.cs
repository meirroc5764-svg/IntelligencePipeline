using System;
namespace IntelligencePipeline.Models.Reports
{
    class RadarReport : Report
    {
        private int _speed;
        private int _direction;
        private int _distantion;

        public int Speed { get => _speed; protected set => _speed = value; }
        public int Direction { get => _direction; protected set => _direction = value; }
        public int Distance { get => _distantion; protected set => _distantion = value; }

        public RadarReport(int reportId, DateTime timestamp, double latitude,double longitude, string description, int speed, int direction, int distance) 
            : base(reportId, timestamp, latitude, longitude, description)
        {
            Speed = speed;
            Direction = direction;
            Distance = distance;
        }

        public override string GetSourceType() => "Radar";
        // return Type
        public override int CalculateReliabilityScore()
            // cheak base
        {
            int Base = 6;

            if (Distance > 500 & Distance < 30000)
                Base += 2;
            if (Speed > 10 & Speed < 900)
                Base += 1;
            else if (Distance > 70000)
                Base -= 2;
            else if (Speed > 1500)
                Base -= 2;
            return Base;
        }
    }
}
