using ReservationSystem;
using ReservationSystem.Command;
using ReservationSystem.Query;
using Xunit;

namespace Tests
{
    public class ListAvailableSeatsTests : TestBase
    {
        [Fact]
        public void ListAvailableSeats_WhenNoReservationMade_ReturnsAllSeats()
        {
            Given();

            WhenQuery(new ListAvailableSeats());

            var expected = new AvailableSeats(
                Seat.A,
                Seat.B,
                Seat.C,
                Seat.D,
                Seat.E);
            ThenExpects(expected);
        }
        
        [Fact]
        public void ListAvailableSeats_WhenSeatsAreReserved_ReturnsRemainingSeats()
        {
            Given(
                new SeatReserved(Jon, Seat.A),
                new SeatReserved(Dalzy, Seat.B)
                );

            WhenQuery(new ListAvailableSeats());

            var expected = new AvailableSeats(
                Seat.C,
                Seat.D,
                Seat.E);
            ThenExpects(expected);
        }
    }
}