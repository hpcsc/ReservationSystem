using System;
using System.Collections.Generic;
using System.Linq;
using ReservationSystem;
using ReservationSystem.Command;
using ReservationSystem.Query;
using Xunit;

namespace Tests
{
    public class TestBase
    {
        protected Guid Jon = Guid.NewGuid();
        protected Guid Dalzy = Guid.NewGuid();
        
        protected ScreeningReservation _screeningReservation;

        private List<object> _publishedEvents = new List<object>();
        private List<object> _pastEvents;
        private ScreeningReservationReadModel _readModel;
        private object _actual;


        protected void Given(params dynamic[] events)
        {
            _pastEvents = events.ToList();
            _readModel = new ScreeningReservationReadModel(_pastEvents);
        }
        
        protected void When(ReserveSeatCommand command)
        {
            var handler = new ReserveSeatHandler(_pastEvents, e =>
                {
                    _publishedEvents.Add(e);
                    if (e is SeatReserved sr)
                    {
                        _readModel.Apply(sr);
                    }
                }
            );

            handler.Handle(command);
        }
        
        protected void WhenQuery(ListAvailableSeats query)
        {
            var handler = new ListAvailableSeatsHandler(_readModel, response => _actual = response);

            handler.Handle(query);
        }

        protected void Then<T>(T @event)
        {
            Assert.True(_publishedEvents.OfType<T>().Any(e => e.Equals(@event)));
        }
        
        protected void ThenExpects<T>(T expectedResponse)
        {
            Assert.Equal(expectedResponse, _actual);
        }
    }

}