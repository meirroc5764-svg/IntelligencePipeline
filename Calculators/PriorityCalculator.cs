using Enumerations;
using ReportHierarchy;
using System;
using System.Text.RegularExpressions;
using static System.Net.WebRequestMethods;
namespace CalculationLogic
{
    class PriorityCalculator
    {
        
        public Priority Calculate(Report report)
            
        {
            //chek if in description have (missile/explosion/attack/fire)
            if (Regex.IsMatch(report.Description.ToLower(), @"\bmissile\b") || Regex.IsMatch(report.Description.ToLower(), @"\bexplosion\b")
                || Regex.IsMatch(report.Description.ToLower(), @"\battack\b") || Regex.IsMatch(report.Description.ToLower(), @"\bfire\b")
                {

            }


             

         
                
        }
    }
}
