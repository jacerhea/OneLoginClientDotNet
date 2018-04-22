using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OneLogin.Responses;

namespace OneLogin
{
    public static class ResponseExtensions
    {
        public static T EnsureSuccess<T>(this T source) where T : BaseStatusResponse
        {
            if (source.Status.Error)
            {
                throw new Exception("Call failed.");
            }

            return source;
        }

        public static string InterpolateEvent(this Event @event, List<EventType> eventTypes){
            var eventType = eventTypes.Single(et => et.id == @event.event_type_id);
            var x = Regex.Matches(eventType.description, @"%\w+%|%\w+(\s\w+)*%");

            var result = @eventType.description;
            var properties = @event.GetType().GetProperties()
                                   .ToDictionary(prop => prop.Name);

            foreach(var y in x.Cast<Match>().Where(mn => mn.Success)){
                var matchValue = y.Value.Replace("%", string.Empty);

                if (matchValue == "note" && properties.ContainsKey("notes"))
                {
                    var property = properties["notes"];
                    var propertyValue = property.GetValue(@event).ToString();

                    result = result.Replace("%note%", propertyValue);
                    continue;
                }

                if(properties.ContainsKey(matchValue)){
                    var property = properties[matchValue];
                    var propertyValue = property.GetValue(@event).ToString();

                    result = result.Replace(y.Value, propertyValue);
                    continue;
                }

                //check for same property with appended "_name"
                var propertyName = matchValue + "_name";
                if(properties.ContainsKey(propertyName)){
                    var property = properties[propertyName];
                    var propertyValue = property.GetValue(@event).ToString();

                    result = result.Replace(y.Value, propertyValue);
                    continue;
                }
      
            }

            return result;
        }
    }
}
