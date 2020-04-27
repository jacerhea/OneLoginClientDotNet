# OneLogin Dot Net Client
This is a portable library for consuming the OneLogin REST-API in (almost) any C# application.
If you find bugs or have any suggestions, feel free to create an issue.

# Quickstart

## Including OneLogin Dot Net Client
The OneLogin API is available through [NuGet](https://www.nuget.org/packages/OneLogin.API/):

```
> Install-Package OneLogin.API
```

## Supported Plattforms
OneLogin API is built on top of the new [.NET Standard](https://github.com/dotnet/standard) targeting netstandard versions 1.3 - therefore it should work on the following plaforms:
* .NET Framework 4.6 and newer
* .NET Core 1.1 or newer
* Universal Windows Platform (uap)
* Windows 8.0 and newer
* Windows Phone (WinRT, not Silverlight)
* Mono / Xamarin

## Quickstart: Using the API Wrapper

```c#
// Initialize
var client = new OneLoginClient("Your Onelogin client id", "Your Onelogin client secret");
```
That's it! The token will be generated and managed for you by the OneLoginClient.

```c#
// Users
var userResponse = await _oneLoginClient.GetUserById(userId);
var userAppsResponse = await _oneLoginClient.GetAppsForUser(userId);

// Events
var eventTypesResponse = await client.GetEventTypes();
var eventById = (await _oneLoginClient.GetEventById(eventId);
var manyEvents = await _oneLoginClient.CreateEvent(new CreateEventRequest
{
    EventTypeId = eventTypeId,
    UserId = userId,
    AppId = appId,
});

// Interpolate Event data
var eventsResponse = await _oneLoginClient.GetEvents());
var allEventTypes = await _oneLoginClient.GetEventTypes();

var results = eventsResponse
    .SelectMany(response => response.Data)
    .Select(@event => @event.InterpolateEvent(allEventTypes.Data))
    .ToList();
```

## Contribution Guidelines
We're very happy to get input from the community on this project! To keep the code clean we ask you to follow a few simple contribution guidelines.

First, create an issue describing what feature you want to add or what problem you're trying to solve, just to make sure no one is already working on that. That also gives us a chance to debate whether a feature is wihtin the scope of this project.

Second, please try to stick to the official C# coding guidelines. https://msdn.microsoft.com/en-us/library/ms229002(v=vs.110).aspx

Also, make sure to write some tests covering your new or modified code.
