using Booking.Car;

namespace Booking.Booking;

public class ClosedBooking : BookingDecorator
{
    public short ActualKilometers { get; }
    public Bill ActualBill { get; }

    public ClosedBooking(IBooking booking, short actualKilometers) : base(booking)
    {
        ActualKilometers = actualKilometers;
        ActualBill = new Bill(booking, actualKilometers);
    }
    
}