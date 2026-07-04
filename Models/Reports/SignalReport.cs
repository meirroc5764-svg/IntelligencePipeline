using IntelligencePipeline.Models.Enums;
using System;
using System.Text.RegularExpressions;
namespace IntelligencePipeline.Models.Reports
{
    class SignalReport : Report
    {
        private double _frequency;
        private string _content;
        private Language _language;
        private int _signalsterngth;

        public double Frequency { get => _frequency; protected set => _frequency = value; }
        public string Content { get => _content; protected set => _content = value; }
        public Language Language { get => _language; protected set => _language = value; }
        public int SignalStrength { get => _signalsterngth; protected set => _signalsterngth = value;}

        public SignalReport(int reportId, DateTime timestamp, double latitude, double longitude, string description, double frequency, string content, Language language, int signalStrength)
            : base(reportId, timestamp, latitude, longitude, description)
        {
            Frequency = frequency;
            Content = content;
            Language = language;
            SignalStrength = signalStrength;
        }
        public override string GetSourceType() => "Signal";
        // return object type
        public override int CalculateReliabilityScore()
            //calculate a Base
        {
            int Base = 5;

            if (SignalStrength >= -40)
                Base += 3;
            else if (SignalStrength >= -70)
                Base += 2;

            //attack/target/border/vehicle:
            if (Regex.IsMatch(Content, @"\battack\b") || Regex.IsMatch(Content, @"\btarget\b")
                || Regex.IsMatch(Content, @"\bborder\b") || Regex.IsMatch(Content, @"\bvehicle\b"))
                Base += 1;
            if (SignalStrength < -100)
                Base -= 2;

            return Base;
        }

    }
}
