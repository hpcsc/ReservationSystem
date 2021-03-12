using System;

namespace ReservationSystem.Command
{
    public class SeatReserved
    {
        public Guid Customer { get; }
        public Seat Seat { get; }

        public SeatReserved(Guid customer, Seat seat)
        {
            Customer = customer;
            Seat = seat;
        }

        public override bool Equals(object? obj)
        {
            return obj is SeatReserved e && e.Customer == Customer && e.Seat == Seat;
        }
    }
}