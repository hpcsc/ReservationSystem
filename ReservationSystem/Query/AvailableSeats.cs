using System.Linq;
using ReservationSystem.Command;

namespace ReservationSystem.Query
{
    public class AvailableSeats
    {
        public Seat[] Seats { get; }

        public AvailableSeats(params Seat[] seats)
        {
            Seats = seats;
        }

        public override bool Equals(object? obj)
        {
            return obj is AvailableSeats availableSeats &&
                   !availableSeats.Seats.Except(Seats).Any() &&
                   !Seats.Except(availableSeats.Seats).Any();
        }
    }
}