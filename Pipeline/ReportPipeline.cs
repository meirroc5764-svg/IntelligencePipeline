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
            
        }

        //private IValidator GetValidator(Report report)
        //{

        //}
        private void ValidateReport(Report report)
        {

        }
        private void CalculateMetrics(Report report)
        {

        }
        private void StoreReport(Report report)
        {

        }
    }
}