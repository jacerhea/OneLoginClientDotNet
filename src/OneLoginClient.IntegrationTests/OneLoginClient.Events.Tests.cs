using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using OneLogin.Requests;
using Xunit;

namespace OneLogin.IntegrationTests
{
    public class OneLoginClientEventsTests
    {
        private static readonly OneLoginClient OneLoginClient;


        [Fact]
        public async Task Many_Event_Types_Exist()
        {
            var eventTypes = (await OneLoginClient.GetEventTypes());
            Action ensureSuccess = () => eventTypes.EnsureSuccess();
            ensureSuccess.Should().NotThrow();
            eventTypes.Data.Should().HaveCountGreaterThan(20);
            var x = eventTypes.Data.Where(et => string.IsNullOrWhiteSpace(et.Description));
        }

        [Fact]
        public async Task Many_Events_Exist()
        {
            var eventsResponse = (await OneLoginClient.GetEvents())
                .EnsureSuccess();
            Action ensureSuccess = () => eventsResponse.EnsureSuccess();
            ensureSuccess.Should().NotThrow();
            eventsResponse.Data.Should().HaveCountGreaterThan(20);
        }

        [Fact]
        public async Task Events_Can_Be_Interpolated()
        {
            var eventsResponse = (await OneLoginClient.GetEvents())
                .EnsureSuccess();
            var eventTypes = (await OneLoginClient.GetEventTypes());

            var tenEventPages = await OneLoginClient.GetNextPages(eventsResponse, 20);

            var results = tenEventPages
                .SelectMany(re => re.Data)
                .Select(d => d.InterpolateEvent(eventTypes.Data.ToList()))
                .ToList();
        }

        [Fact]
        public async Task Event_Can_Be_Retrieved_By_Id()
        {
            var manyEvents = (await OneLoginClient.GetEvents())
                .EnsureSuccess();
            var idToTest = manyEvents.Data.First().Id;
            var eventById = (await OneLoginClient.GetEventById(6868406110))
                .EnsureSuccess();
            eventById.Data.Should().HaveCount(1);
            eventById.Data.Single().Id.Should().Be(idToTest);
        }

        [Fact]
        public async Task An_Event_Can_Be_Created()
        {
            var manyEvents = (await OneLoginClient.CreateEvent(new CreateEventRequest
            {
                EventTypeId = 300,
                UserId = 32715399,
                AppId = 644193,

            }));
        }
    }
}
