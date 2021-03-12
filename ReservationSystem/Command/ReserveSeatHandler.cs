using System;
using System.Collections.Generic;

namespace ReservationSystem.Command
{
    public class ReserveSeatHandler
    {
        private readonly ScreeningReservation _screeningReservation;

        public ReserveSeatHandler(List<dynamic> events, Action<object> publish)
        {
            var state = new ScreeningReservationState(events);
            _screeningReservation = new ScreeningReservation(state, e =>
                {
                    if (e is SeatReserved sr)
                    {
                        state.Apply(sr);
                    }
                    publish(e);
                }
            );
        }

        public void Handle(ReserveSeatCommand command)
        {
            _screeningReservation.Reserve(command.CustomerId, command.Seat);
        }
    }
}