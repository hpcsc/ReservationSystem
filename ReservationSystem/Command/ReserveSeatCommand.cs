using System;

namespace ReservationSystem.Command
{
    public class ReserveSeatCommand
    {
        public Guid CustomerId { get; }
        public Seat Seat { get; }

        public ReserveSeatCommand(Guid customerId, Seat seat)
        {
            CustomerId = customerId;
            Seat = seat;
        }
    }
}