using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using System;
namespace IntelligencePipeline.Validation
{
    class SignalValidator : BaseValidator, IValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            if (report is not SignalReport signalReport)
                return ValidationResult.Failure("calss is invalid");

            if (signalReport.Frequency < 1.0 || signalReport.Frequency > 3000.0)
                return ValidationResult.Failure("frequency is invalid");

            if (signalReport.Content.Length < 5 || signalReport.Content.Length > 1000)
                return ValidationResult.Failure("content is invalid");

            if (!Enum.IsDefined(typeof(Language), signalReport.Language))
                return ValidationResult.Failure("Language is invalid");
            
                return ValidationResult.Success();
        }
    }
}
