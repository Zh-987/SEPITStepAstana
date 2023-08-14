using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SEPAstanaItStep.Infrastructure
{
    public class CustomdateTimeModelBinder : IModelBinder
    {
        private readonly IModelBinder fallbackBinder;

        public CustomdateTimeModelBinder(IModelBinder fallbackBinder) { 
            this.fallbackBinder = fallbackBinder;
        }
        public Task BindModelAsync(ModelBindingContext bindingContext) {

            var datepartValues = bindingContext.ValueProvider.GetValue("Date"); 
            var timepartValues = bindingContext.ValueProvider.GetValue("Time");

            if (datepartValues == ValueProviderResult.None || timepartValues == ValueProviderResult.None) { 
                return fallbackBinder.BindModelAsync(bindingContext);
            }

            string? date = datepartValues.FirstValue;
            string? time = timepartValues.FirstValue;

            DateTime.TryParse(date, out var parsedDateValue);
            DateTime.TryParse(time, out var parsedTimeValue);

            var result = new DateTime(
                parsedDateValue.Year,
                parsedDateValue.Month,
                parsedDateValue.Day,
                parsedTimeValue.Hour,
                parsedTimeValue.Minute,
                parsedTimeValue.Second);
            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }
    }
}
