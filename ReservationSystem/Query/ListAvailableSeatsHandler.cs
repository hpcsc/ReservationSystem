using System;

namespace ReservationSystem.Query
{
    public class ListAvailableSeatsHandler
    {
        private readonly ScreeningReservationReadModel _readModel;
        private readonly Action<object> _publish;

        public ListAvailableSeatsHandler(ScreeningReservationReadModel readModel, Action<object> publish)
        {
            _readModel = readModel;
            _publish = publish;
        }

        public void Handle(ListAvailableSeats query)
        {
            var availableSeats = _readModel.GetAvailableSeats();
            _publish(new AvailableSeats(availableSeats));
        }
    }
}