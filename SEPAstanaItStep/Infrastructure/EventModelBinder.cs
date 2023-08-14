using Microsoft.AspNetCore.Mvc.ModelBinding;
using SEPAstanaItStep.Models;

namespace SEPAstanaItStep.Infrastructure
{
    public class EventModelBinder : IModelBinder 
    {
        public Task BindModelAsync(ModelBindingContext bindingContext) {

            var datepartValues = bindingContext.ValueProvider.GetValue("Date");
            var timepartValues = bindingContext.ValueProvider.GetValue("Time");
            var namepartValues = bindingContext.ValueProvider.GetValue("Name");
            var idpartValues = bindingContext.ValueProvider.GetValue("Id");

            string? date = datepartValues.FirstValue;
            string? time = timepartValues.FirstValue;
            string? name = namepartValues.FirstValue;
            string? id = idpartValues.FirstValue;

            if (string.IsNullOrEmpty(id)) {
                id = Guid.NewGuid().ToString();
            }
                             
            if (string.IsNullOrEmpty(name)) {
                name = "Unkown event";
            }

            DateTime.TryParse(date, out var parsedDateValue);
            DateTime.TryParse(time, out var parsedTimeValue);

            DateTime fullDateTime = new DateTime(
                parsedDateValue.Year,
                parsedDateValue.Month,
                parsedDateValue.Day,
                parsedTimeValue.Hour,
                parsedTimeValue.Minute,
                parsedTimeValue.Second);

            bindingContext.Result = ModelBindingResult.Success(new Event { Id=id, EventDate = fullDateTime, Name = name});
            return Task.CompletedTask;
        }
    }
}
