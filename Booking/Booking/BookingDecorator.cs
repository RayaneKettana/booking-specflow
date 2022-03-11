using Booking.Car;
using Booking.Customer;

namespace Booking.Booking;

public class BookingDecorator : IBooking
{
    public Guid Id => _booking.Id;
    public ICar Car => _booking.Car;
    public ICustomer Customer => _booking.Customer;
    public DateTime From => _booking.From;
    public DateTime To => _booking.To;
    public Bill ForecastBill => _booking.ForecastBill;
    public short ForecastKilometers => _booking.ForecastKilometers;
    public Status Status { get; set; }
    private IBooking _booking;

    public BookingDecorator(IBooking booking)
    {
        _booking = booking;
    }

}