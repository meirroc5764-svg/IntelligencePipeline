using IntelligencePipeline.Models.Reports;
using System;
using IntelligencePipeline.Validation;
namespace IntelligencePipeline.Calculators
{
    class ReliabilityCalculator
    {
        public int Calculate(Report report)
        {
            int result = report.CalculateReliabilityScore();

            if (result < 1)
                
                result = 1;
            
            
            if (result > 10)

                result = 10;
            
            return result;
        }
    }
}