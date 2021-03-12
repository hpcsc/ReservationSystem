using System;
using System.Collections.Generic;

namespace ReservationSystem.Command
{
    public class ScreeningReservation
    {
        private readonly ScreeningReservationState _state;
        private readonly Action<object> _publish;

        public ScreeningReservation(ScreeningReservationState state, Action<object> publish)
        {
            _state = state;
            _publish = publish;
        }
        
        public void Reserve(Guid customer, Seat seat)
        {
            if (_state.IsReserved(seat))
            {
                _publish(new SeatReservationFailed(customer, seat));
            }
            else
            {
                _publish(new SeatReserved(customer, seat));
            }
        }
    }
    
    public class ScreeningReservationState
    {
        public ScreeningReservationState(List<dynamic> events)
        {
            _reservation = new Dictionary<Seat, Guid>();
            events.ForEach(e => Apply(e));
        }
        
        public void Apply(object e) {}

        public void Apply(SeatReserved e)
        {
            _reservation[e.Seat] = e.Customer;
        }

        private Dictionary<Seat, Guid> _reservation { get; set; }

        public bool IsReserved(Seat seat)
        {
            return _reservation.ContainsKey(seat);
        }
    }
}