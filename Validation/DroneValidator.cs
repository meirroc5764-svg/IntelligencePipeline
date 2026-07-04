using IntelligencePipeline.Models.Reports;
using System;
namespace IntelligencePipeline.Validation
{
    class DroneValidator : BaseValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {

            if (report is not DroneReport droneReport)
            {
                return ValidationResult.Failure("Invalid report type");
            }
            if ( droneReport.Altitude !> 10000 || droneReport.Altitude !< 100)
            {
                return ValidationResult.Failure("Altitude not validate");
            }
            if (droneReport.ImageQuality !> 100 || droneReport.ImageQuality !< 1)
                return ValidationResult.Failure("ImageQuality not validate");
            
            return ValidationResult.Success();
        }
    }
}