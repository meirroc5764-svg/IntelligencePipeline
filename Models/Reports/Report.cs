using IntelligencePipeline.Models.Enums;
using System;
namespace IntelligencePipeline.Models.Reports
{
    public abstract class Report
    {
        private int _reportId;
        private DateTime _timestamp;
        private double _latitude;
        private double _longitude;
        private string _description;
        private ReportStatus _status;
        private Priority _priority;
        private Classification _classification;
        private int _reliabilityScore;
        private string _rejectionReason;

        public int ReportId { get => _reportId; }

        public DateTime Timestamp
        {
            get => _timestamp;
            set
            {
                _timestamp = value; 
            }  
        }

        public double Latitude { get => _latitude; protected set => _latitude = value; }

        public double Longitude { get => _longitude; protected set => _longitude = value; }

        public string Description { get => _description; protected set => _description = value; }

        public ReportStatus Status { get => _status; protected set => _status = value; }

        public Priority Priority { get => _priority; protected set => _priority = value; }

        public Classification Classification { get => _classification; protected set => _classification = value; }

        public int ReliabilityScore { get => _reliabilityScore ; protected set => _reliabilityScore = value; }

        public string RejectionReason { get => _rejectionReason; protected set => _rejectionReason = value; }

        protected Report(int reportId, DateTime timestamp, double latitude, double longitude, string description)
        {
            _reportId = reportId;
            Timestamp = timestamp;
            Latitude = latitude;
            Longitude = longitude;
            Description = description;
            Status = ReportStatus.New;
        }
        public abstract string GetSourceType();

        public abstract int CalculateReliabilityScore();

        public virtual string GetSummary()
        {
            return $"reportId: {ReportId}, timestamp: {Timestamp}, latitude: {Latitude}, longitude: {Longitude}, description: {Description}, status: {Status}";
        }
        public override string ToString()
        {
            return $"Report ID: {ReportId}, Timestamp: {Timestamp}, Latitude: {Latitude}, Longitude: {Longitude}, Description: {Description}, Status: {Status}, Priority: {Priority}, Classification: {Classification}, Reliability Score: {ReliabilityScore}, Rejection Reason: {RejectionReason}";
        }

    }
}
