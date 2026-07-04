using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using System;
using System.Net.NetworkInformation;
namespace ProgramEntryPoint
{
    class Program
    {
        static void Main()
        {
            List<Report> listreport = new();
            DateTime date = new DateTime(2026, 7, 1, 14, 30, 0);
            DroneReport test1 = new DroneReport(1, date, 10.0, 20.0, "this is test", 500, 80);
            SoldierReport test2 = new SoldierReport(2, date, 10.0, 20.0, "this is test", "meir", "1234", "8200", 3);
            listreport.Add(test1);
            listreport.Add(test2);
            foreach(Report report in listreport)
            {
                Console.WriteLine(report.GetSummary());
            }
            //string t = test1.GetSummary();
            //string t2 = test2.GetSummary();
            //Console.WriteLine(t);
            //Console.WriteLine(t2);
        }
    }
}