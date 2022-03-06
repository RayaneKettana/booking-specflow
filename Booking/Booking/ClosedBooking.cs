namespace Booking.Booking;

public class ClosedBooking : BookingDecorator
{
    private readonly short _actualKilometers;

    public ClosedBooking(IBooking booking, short actualKilometers) : base(booking)
    {
        _actualKilometers = actualKilometers;
    }
    
}