using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using OneLogin.Responses;

namespace OneLogin
{
    public static class ResponseExtensions
    {
        public static T EnsureSuccess<T>(this T source) where T : BaseStatusResponse
        {
            if (source.Status.Error)
            {
                throw new Exception(source.Status.Message);
            }

            return source;
        }

        public static string InterpolateEvent(this Event @event, List<EventType> eventTypes){
            var eventType = eventTypes.Single(et => et.Id == @event.EventTypeId);
            var matches = Regex.Matches(eventType.Description, @"%\w+%|%\w+(\s\w+)*%");

            var result = @eventType.Description;
            var properties = @event.GetType().GetProperties()
                                   .ToDictionary(prop => prop.Name, prop => prop, StringComparer.CurrentCultureIgnoreCase);

            foreach(var match in matches.Cast<Match>().Where(mn => mn.Success)){
                var matchValue = match.Value.Replace("%", string.Empty);

                if (matchValue == "note" && properties.ContainsKey(nameof(Event.Notes)))
                {
                    var property = properties[nameof(Event.Notes)];
                    var propertyValue = property.GetValue(@event).ToString();

                    result = result.Replace("%note%", propertyValue);
                    continue;
                }

                if(properties.ContainsKey(matchValue)){
                    var property = properties[matchValue];
                    var propertyValue = property.GetValue(@event).ToString();

                    result = result.Replace(match.Value, propertyValue);
                    continue;
                }

                //check for same property with appended "_name"
                var propertyName = matchValue + "_name";
                if(properties.ContainsKey(propertyName)){
                    var property = properties[propertyName];
                    var propertyValue = property.GetValue(@event).ToString();

                    result = result.Replace(match.Value, propertyValue);
                    continue;
                }
      
            }

            return result;
        }
    }
}
