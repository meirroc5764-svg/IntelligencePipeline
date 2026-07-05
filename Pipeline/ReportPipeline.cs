using IntelligencePipeline.Calculators;
using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Storage;
using IntelligencePipeline.Validation;
using System;
namespace ProcessingPipeline
{
    class ReportPipeline
    {
        private ReportRepository _validatedReports;
        private RejectedReportRepository _rejectedReports;
        private int _nextReportId;

        public ReportPipeline()
        {
            _validatedReports = new ReportRepository();
            _rejectedReports = new RejectedReportRepository();
            _nextReportId = _validatedReports.GetTotalCount() + 1;
        }
        public void ProcessReport(Report report)
        {
            report.Status = ReportStatus.New;

            report.Status = ReportStatus.Validating;

            ValidateReport(report);

            if (report.Status == ReportStatus.Rejected)
                return;

            CalculateMetrics(report);

            StoreReport(report);
        }
        public ReportRepository GetValidatedReports()
        {
            return _validatedReports;
        }
        public RejectedReportRepository GetRejectedReports()
        {
            return _rejectedReports;
        }
        public void DisplayStatistics()
        {
            Console.WriteLine($"count valid Report: {_validatedReports.GetTotalCount()}");
            Console.WriteLine($"Count invalid Report: {_rejectedReports.GetTotalCount()}");
            foreach (ReportStatus status in Enum.GetValues <ReportStatus>())
            Console.WriteLine($"valid Report with status:{status} count:{_validatedReports.GetByStatus(status).Count}");
        }

        private IValidator GetValidator(Report report)
        {
            if (report is DroneReport)
            {
                return new DroneValidator();
            }
            
            if (report is SoldierReport)
            {
                return new SoldierValidator();
            }

            if (report is RadarReport)
            {
                return new RadarValidator();
            }

            if (report is SignalReport)
            {
                return new SignalValidator();
            }
            throw new Exception("Unknown report type");

        }
        private void ValidateReport(Report report)
        {
            IValidator validator = GetValidator(report);
            ValidationResult result = validator.Validate(report);

            if (! result.IsValid)
            {
                report.Status = ReportStatus.Rejected;
                report.RejectionReason = result.ErrorMessage;
                _rejectedReports.Add( report );
                Console.WriteLine(result.ErrorMessage);
                return;
            }
            report.Status = ReportStatus.Validated;

        }
        private void CalculateMetrics(Report report)
        {
            ReliabilityCalculator culculator = new ReliabilityCalculator();
            report.ReliabilityScore = culculator.Calculate(report);

            PriorityCalculator priorityCalculator = new PriorityCalculator();
            report.Priority = priorityCalculator.Calculate(report);

            ClassificationCalculator classificationCalculator = new ClassificationCalculator();
            report.Classification = classificationCalculator.Calculate(report);
        }
        private void StoreReport(Report report)
        {
            //report.ReportId = _nextReportId
            _validatedReports.Add(report);
        }
    }
}