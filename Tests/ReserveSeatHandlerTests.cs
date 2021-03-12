using System.Collections.Generic;
using ReservationSystem.Command;
using Xunit;

namespace Tests
{
    public class ReserveSeatHandlerTests : TestBase
    {
        private List<dynamic> NoSeatsReserved()
        {
            return new List<dynamic>();
        }
        
        [Fact]
        public void Handle_WhenSeatIsAvailable_SeatIsReserved()
        {
            Given(NoSeatsReserved());

            When(new ReserveSeatCommand(Jon, Seat.C));

            Then(new SeatReserved(Jon, Seat.C));
        }

        [Fact]
        public void Handle_WhenSeatIsUnavailable_ReservationRemainsUnchanged()
        {
            Given(new SeatReserved(Jon, Seat.A));

            When(new ReserveSeatCommand(Dalzy, Seat.A));

            Then(new SeatReservationFailed(Dalzy, Seat.A));
        }
        
        [Fact]
        public void Handle_WhenDifferentSeatIsReserved_ReservationIsSuccessful()
        {
            Given(new SeatReserved(Jon, Seat.A));

            When(new ReserveSeatCommand(Dalzy, Seat.B));

            Then(new SeatReserved(Dalzy, Seat.B));
        }
    }
}