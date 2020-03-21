﻿using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Reflection;
using OneLogin.Responses;

namespace OneLogin
{
    public static class ResponseExtensions
    {
        /// <summary>Throws an Exception if Status.Error is true.</summary>
        /// <returns>Returns the successful BaseStatusResponse.</returns>
        public static T EnsureSuccess<T>(this T source) where T : BaseStatusResponse
        {
            if (source.Status.Error)
            {
                throw new Exception(source.Status.Message);
            }

            return source;
        }

        /// <summary>
        /// Returns a string of the EventType data interpolated with the actualized Event.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <param name="eventType">The set of all event types to </param>
        /// <returns></returns>
        public static string InterpolateEvent(this Event @event, EventType eventType)
        {
            var matches = Regex.Matches(eventType.Description, @"%\w+%|%\w+(\s\w+)*%");

            var result = @eventType.Description;
            var properties = @event.GetType().GetTypeInfo().DeclaredProperties
                                   .ToDictionary(prop => prop.Name, prop => prop, StringComparer.CurrentCultureIgnoreCase);

            foreach (var match in matches.Cast<Match>().Where(mn => mn.Success))
            {
                var matchValue = match.Value.Replace("%", string.Empty);

                if (matchValue == "note" && properties.ContainsKey(nameof(Event.Notes)))
                {
                    var property = properties[nameof(Event.Notes)];
                    var propertyValue = property.GetValue(@event).ToString();

                    result = result.Replace("%note%", propertyValue);
                    continue;
                }

                if (properties.ContainsKey(matchValue))
                {
                    var property = properties[matchValue];
                    var propertyValue = property.GetValue(@event).ToString();

                    result = result.Replace(match.Value, propertyValue);
                    continue;
                }

                //check for same property with appended "_name"
                var propertyName = matchValue + "_name";
                if (properties.ContainsKey(propertyName))
                {
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
