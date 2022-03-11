using Booking.Car;
using Booking.Customer;

namespace Booking.Booking;

public interface IBooking : IEntity
{
    ICar Car { get; }
    
    ICustomer Customer { get; }
    DateTime From { get; }
    DateTime To { get; }
    Bill ForecastBill { get; }
    short ForecastKilometers { get; }
    Status Status { get; set; }
}