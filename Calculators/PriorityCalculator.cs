using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;
using static System.Net.WebRequestMethods;
namespace IntelligencePipeline.Calculators
{
    class PriorityCalculator
    {

        public Priority Calculate(Report report)

        {
            //chek if in description have (missile/explosion/attack/fire)
            //if (Regex.IsMatch(report.Description.ToLower(), @"\bmissile\b") || Regex.IsMatch(report.Description.ToLower(), @"\bexplosion\b")
            //    || Regex.IsMatch(report.Description.ToLower(), @"\battack\b") || Regex.IsMatch(report.Description.ToLower(), @"\bfire\b"))
            
            if (ContainsKeyword(report.Description, "missile", "explosion" , "attack" , "fire"))
            {
                if (report is RadarReport radarReport)
                {
                    if (radarReport.Speed >= 800) return Priority.Critical;
                }

                if (report is SignalReport signalReport)
                {
                    if ((ContainsKeyword(signalReport.Content, "attack")) & (ContainsKeyword(signalReport.Content, "target"))) return Priority.Critical;
                }

            }
            
            else if (ContainsKeyword(report.Description, "weapon", "suspicious", "border"))
            {
                if (report is DroneReport droneReport)
                {
                    if (droneReport.Altitude > 500) return Priority.High;
                }
                if (report is RadarReport radarReport)
                {
                    if (radarReport.Speed >= 400) return Priority.High;
                }
                if (report is SoldierReport soldierReport)
                {
                    if ((ContainsKeyword(soldierReport.Description, "movement")) & (soldierReport.ConfidenceLevel >= 4)) return Priority.High;
                }
            }
            
            else if ((ContainsKeyword(report.Description, "movement", "vehicle", "activity")))
            {
                if (report is RadarReport radarReport)
                {
                    if (radarReport.Speed >= 120) return Priority.Medium;

                    if (radarReport.ReliabilityScore >= 7) return Priority.Medium;
                }
            }
            
            return Priority.Low;
        }
        private bool ContainsKeyword(string text, params string[] keywords)
        {
            foreach (string keyword in keywords)
            {
                if (Regex.IsMatch(text, $@"\b{keyword}\b", RegexOptions.IgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }





    
    }
}
