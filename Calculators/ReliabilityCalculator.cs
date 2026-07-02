using ReportHierarchy;
using System;
using IntelligencePipeline.Validation;
namespace IntelligencePipeline.Calculators
{
    class ReliabilityCalculator
    {
        public int Calculate(Report report)
        {
            int result = report.CalculateReliabilityScore();

            if (result < 1 || result > 10)
                ValidationResult.Failure(" sum is invalid");
            
            return result;
        }
    }
}