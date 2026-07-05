using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using System;
using System.Net.NetworkInformation;
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
        public Report GetById(int reportId)
        public void UpdateStatus(int reportId, ReportStatus newStatus)
        public int GetTotalCount()
        public int GetCountByStatus(ReportStatus status)
    }
    
}
