using IntelligencePipeline.Models.Reports;
using System;
namespace IntelligencePipeline.Validation
{
    class RadarValidator : BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            if (report is not RadarReport  radarReport)
                return ValidationResult.Failure("object is invalid class");
            
            if (radarReport.Speed! < 2001 & radarReport.Speed! > 0)
                return ValidationResult.Failure("spedd is invalid");
            
            if (radarReport.Direction! > 0 & radarReport.Direction! < 361)
                return ValidationResult.Failure("Direction is invalid");

            if (radarReport.Distance! > 99 & radarReport.Distance! < 100001)
                return ValidationResult.Failure("Ditance is invalid");

            return ValidationResult.Success();
        }
    }
}
