using Booking.Customer;

namespace Booking.Booking;

public class BookingDecorator : IBooking
{
    public Guid Id => _booking.Id;
    public Registration.Registration RegistrationCar => _booking.RegistrationCar;
    public ICustomer Customer => _booking.Customer;
    public DateTime From => _booking.From;
    public DateTime To => _booking.To;
    public Boolean isOpen { get; set; }
    private IBooking _booking;

    public BookingDecorator(IBooking booking)
    {
        _booking = booking;
    }

}