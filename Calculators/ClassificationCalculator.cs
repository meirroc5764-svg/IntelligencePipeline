using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using System;
using System.Text.RegularExpressions;
namespace IntelligencePipeline.Calculators

{
    class ClassificationCalculator
    {
        public Classification Calculate(Report report)
        {
            //its classificition Top Secret
            if (ContainsKeyword(report.Description, "target", "attack", "missile")) return Classification.TopSecret;

            if (report.Priority == Priority.Critical) return Classification.TopSecret;

            // its Classification=Secret
            if (ContainsKeyword(report.Description, "border ", "weapon")) return Classification.Secret;

            if (report is SignalReport signalReport) return Classification.Secret;

            if (report.Priority == Priority.High) return Classification.Secret;

            // its Classification=Restricted
            if (report.Priority == Priority.Medium) return Classification.Restricted;

            if (report is SoldierReport soldierReport) return Classification.Restricted;

            //else
            return Classification.Unclassified;
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
