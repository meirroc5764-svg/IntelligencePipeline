using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Storage;
using ProcessingPipeline;
using System;
using System.Net.NetworkInformation;
namespace ProgramEntryPoint
{
    class Program
    {
        static void Main()
        {
            //List<Report> listreport = new();
            //DateTime date = new DateTime(2026, 7, 1, 14, 30, 0);
            //DroneReport test1 = new DroneReport(1, date, 10.0, 20.0, "this is test", 500, 80);
            //SoldierReport test2 = new SoldierReport(2, date, 10.0, 20.0, "this is test", "meir", "1234", "8200", 3);
            //listreport.Add(test1);
            //listreport.Add(test2);
            //foreach(Report report in listreport)
            //{
            //    Console.WriteLine(report.GetSummary());
            //}
            ReportPipeline pipeline = new ReportPipeline();

            Report drone = new DroneReport(1, DateTime.Now, 30.5, 34.8, "enemy movement detected", 1200, 85);
            Report soldier = new SoldierReport(2, DateTime.Now, 31.2, 35.1, "weapon spotted near border", "John Doe", "1234567", "UnitA", 5);
            Report radar = new RadarReport(3, DateTime.Now, 32.0, 35.0, "radar contact", 500, 90, 1000);
            Report signal = new SignalReport(4, DateTime.Now, 31.5, 34.9, "attack on target confirmed", 100.5, "attack target", Language.English, -50);

            pipeline.ProcessReport(drone);
            pipeline.ProcessReport(soldier);
            pipeline.ProcessReport(radar);
            pipeline.ProcessReport(signal);

            pipeline.DisplayStatistics();
        
            //string t = test1.GetSummary();
            //string t2 = test2.GetSummary();
            //Console.WriteLine(t);
            //Console.WriteLine(t2);
        }
        private static void DisplayReport(Report report)
        {
            report.GetSummary();
        }
        private static void DisplayValidatedReports(ReportRepository repository)
        {
            foreach(Report report in repository.GetAll())
                Console.WriteLine(report);
        }
        private static void DisplayRejectedReports(RejectedReportRepository repository)
        {
            foreach (Report report in repository.GetAll())
                Console.WriteLine(report);
        }
    }
}