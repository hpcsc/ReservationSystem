using ReservationSystem;
using ReservationSystem.Command;
using ReservationSystem.Query;
using Xunit;

namespace Tests
{
    public class IntegrationTests : TestBase
    {
        [Fact]
        public void GivenSomeSeatsReserved_WhenReserveNewSeat_ReturnRemainingSeats()
        {
            Given(
                new SeatReserved(Dalzy, Seat.A),
                new SeatReserved(Jon, Seat.B)
            );

            When(new ReserveSeatCommand(Dalzy, Seat.C));
            WhenQuery(new ListAvailableSeats());

            var response = new AvailableSeats(
                Seat.D,
                Seat.E
                );
            ThenExpects(response);
        }
    }
}