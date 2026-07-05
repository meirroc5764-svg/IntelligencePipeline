using IntelligencePipeline.Models.Reports;
using System;
using System.Text.RegularExpressions;
namespace IntelligencePipeline.Storage
{
    class RejectedReportRepository
    {
        private List<Report> _rejectedReports;

        public RejectedReportRepository()
        {
            _rejectedReports = new List<Report>();
        }
        public void Add(Report report)
        {
            _rejectedReports.Add(report);
        }
        public List<Report> GetAll()
        {
            return _rejectedReports;
        }
        public int GetTotalCount()
        {
            return _rejectedReports.Count;
        }
        public List<Report> GetByReason(string reasonKeyword)
        {
            List<Report> result = new List<Report>();
            foreach (Report regectReport in _rejectedReports)
            {
                if (Regex.IsMatch(regectReport.Description, $@"\b{reasonKeyword}\b", RegexOptions.IgnoreCase))
                {
                    result.Add(regectReport);
                }
            }

            return result;
        }
    }
}
