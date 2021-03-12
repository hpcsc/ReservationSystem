using System;

namespace ReservationSystem.Command
{
    public class SeatReservationFailed
    {
        public Guid Customer { get; }
        public Seat Seat { get; }

        public SeatReservationFailed(Guid customer, Seat seat)
        {
            Customer = customer;
            Seat = seat;
        }
        
        public override bool Equals(object? obj)
        {
            return obj is SeatReservationFailed e && e.Customer == Customer && e.Seat == Seat;
        }
    }
}