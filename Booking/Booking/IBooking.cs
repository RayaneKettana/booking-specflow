using Booking.Customer;

namespace Booking.Booking;

public interface IBooking : IEntity
{
    Registration.Registration RegistrationCar { get; }

    
    ICustomer Customer { get; }
    DateTime From { get; }
    DateTime To { get; }
    Boolean isOpen { get; set; }
}