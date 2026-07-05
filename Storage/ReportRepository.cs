using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using System;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
namespace IntelligencePipeline.Storage
{
    class ReportRepository
    {
        private List<Report> _reports;
        public ReportRepository()
        {
            _reports = new List<Report>();
        }
        public void Add(Report report)
        {
            _reports.Add(report);
        }
        public List<Report> GetAll()
        {
            return _reports;
        }
        public List<Report> GetByStatus(ReportStatus status)
        {
            List<Report> result = new List<Report>();
            foreach (Report report in _reports)
            {
                if (report.Status == status)
                    result.Add(report);
            }
            return result;
        }
        public List<Report> GetByPriority(Priority priority)
        {
            List<Report> result = new List<Report>();
            foreach (Report report in _reports)
            {
                if (report.Priority == priority)
                    result.Add(report);
            }
            return result;
        }
            
        public List<Report> Search(string keyword)
        {
            List<Report> result = new List<Report> ();
            foreach (Report report in _reports)
            {
                if (Regex.IsMatch(report.Description, $@"\b{keyword}\b", RegexOptions.IgnoreCase))
                {
                    result.Add(report);
                }
            }

            return result;
        }

        public Report GetById(int reportId)
        {
            List<Report> result = new List<Report>();
            foreach (Report report in _reports)
            {
                if (report.ReportId == reportId)
                    result.Add(report);
            }
            return result;
        }
        public void UpdateStatus(int reportId, ReportStatus newStatus)
        {
            List<Report> result = new List<Report>();
            foreach (Report report in _reports)
            {
                if (report.ReportId == reportId)
                    report.Status =  newStatus;
            }
        }
        public int GetTotalCount()
        {
            return _reports.Count;
        }
        public int GetCountByStatus(ReportStatus status)
        {
            List<Report> list_report_by_status = GetByStatus(status);
            return list_report_by_status.Count;
        }

    }
    
}
