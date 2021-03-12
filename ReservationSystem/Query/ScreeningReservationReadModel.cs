using System.Collections.Generic;
using System.Linq;
using ReservationSystem.Command;

namespace ReservationSystem.Query
{
    public class ScreeningReservationReadModel
    {
        private HashSet<Seat> _availableSeats;
        
        public ScreeningReservationReadModel(List<object> events)
        {
            _availableSeats = new HashSet<Seat>
            {
                Seat.A,
                Seat.B,
                Seat.C,
                Seat.D,
                Seat.E
            };
            events.OfType<SeatReserved>().ToList().ForEach(Apply);
        }

        public void Apply(SeatReserved @event)
        {
            _availableSeats.Remove(@event.Seat);
        }

        public Seat[] GetAvailableSeats()
        {
            return _availableSeats.ToArray();
        }
    }
}